using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TO2GoAPIv2.Controllers;
using TO2GoAPIv2.Exceptions;
using TO2GoAPIv2.Models;

namespace TO2GoAPIv2.Logic
{
    public class GameBoard
    {
        public int GameId { get; set; }

        private ILogger<MoveController> logger;
        private int boardSize;
        private bool lastMoveBlack = false;
        private int passCount = 0;
        private List<string> boardStates = new List<string>();
        private Dictionary<(int x, int y), Stone> boardStones = new Dictionary<(int x, int y), Stone>();

        public GameBoard(int gameId, int boardSize, ILogger<MoveController> logger) {
            this.boardSize = boardSize;
            GameId = gameId;
            this.logger = logger;
        }
        public List<Stone> AddStone(int x, int y, bool isBlack) {
            if (lastMoveBlack == isBlack) throw new ForbidException("forbid", ForbidError.NotYourMove);
            if (!CorrectCoordinates(x, y)) throw new ForbidException("forbid", ForbidError.IncorrectCoords);
            Stone stone = new Stone { X = x, Y = y, stoneColor = isBlack ? StoneColor.black : StoneColor.white };
            List<Stone> neighbors = GetNeighbors(stone);
            if (!PositionAvailable(stone, neighbors)) throw new ForbidException("forbid", ForbidError.PositionNotAvailable);
            if (!CheckBoardState(GetBoardState(stone))) throw new ForbidException("forbid", ForbidError.KO);
            // stone can be placed
            boardStones.Add((x, y), stone);
            UpdateLiberties(stone, neighbors);
            UpdateChain(stone, neighbors);

            List<Stone> enemyCaptures = GetEnemyCaptures(stone, neighbors);
            RemoveStones(enemyCaptures);
            List<Stone> selfCaptures = GetSelfCaptures(stone, neighbors);
            RemoveStones(selfCaptures);

            boardStates.Add(GetBoardState());

            List<Stone> allCaptures = new List<Stone>();
            allCaptures.AddRange(enemyCaptures);
            allCaptures.AddRange(selfCaptures);

            //var boardStonesLog = boardStones.Select(x => (new { key = x.Key, chain = x.Value.Chain, stone = x.Value }));
            //string logText = "";
            //foreach(var item in boardStonesLog) {
            //    logText += Environment.NewLine + item.stone.ToString() + " chainCount: " + item.chain.Stones.Count() + " (liberties: " + item.chain.GetLiberties() + ")";
            //}
            //logger.LogInformation(logText);

            passCount = 0;
            lastMoveBlack = !lastMoveBlack;
            return allCaptures;
        }

        /// <summary>
        /// Returns true if game is over (2 consecutive passes)
        /// </summary>
        /// <param name="isBlack"></param>
        /// <returns></returns>
        public bool Pass(bool isBlack) {
            if (lastMoveBlack == isBlack) throw new ForbidException("forbid", ForbidError.NotYourMove);
            passCount++;
            lastMoveBlack = !lastMoveBlack;

            if (passCount == 2) return true;
            else return false;
        }

        public Score GetScore() {
            var territoryStones = PutNeutralTerritoryStones();
            foreach(Stone stone in territoryStones) {
                var neighbors = GetNeighbors(stone);
                UpdateChainOnly(stone, neighbors);
            }
            UpdateTerritory(territoryStones);
            var score = GetScore(territoryStones);
            RemoveTerritoryStones();
            return score;
        }

        private bool CorrectCoordinates(int x, int y) {
            if (x < 1 || x > boardSize || y < 1 || y > boardSize)
                return false;
            return true;
        }

        private bool PositionAvailable(Stone stone, List<Stone> neighbors) {
            if (boardStones.ContainsKey((stone.X, stone.Y)))
                return false;
            // suicide case
            if (neighbors.Count == 4 && neighbors.Count(s => s.stoneColor != stone.stoneColor) == 4)
                return false;

            return true;
        }


        private string GetBoardState() {
            string state = "";
            for(int i = 1; i <= boardSize; i++) {
                for(int j = 1; j <= boardSize; j++) {
                    if (boardStones.ContainsKey((i, j))) state += boardStones[(i, j)].ToString();
                }
            }
            return state;
        }

        private string GetBoardState(Stone stone) {
            string state = "";
            for (int i = 1; i <= boardSize; i++) {
                for (int j = 1; j <= boardSize; j++) {
                    if (boardStones.ContainsKey((i, j))) state += boardStones[(i, j)].ToString();
                    if (stone.X == i && stone.Y == j) state += stone.ToString();
                }
            }
            return state;
        }

        private bool CheckBoardState(string state) {
            foreach(string s in boardStates) {
                if (s == state) return false;
            }
            return true;
        }

        private List<Stone> GetNeighbors(Stone stone) {
            List<Stone> neighbors = new List<Stone>();
            if (boardStones.ContainsKey((stone.X - 1, stone.Y))) neighbors.Add(boardStones[(stone.X - 1, stone.Y)]);
            if (boardStones.ContainsKey((stone.X + 1, stone.Y))) neighbors.Add(boardStones[(stone.X + 1, stone.Y)]);
            if (boardStones.ContainsKey((stone.X, stone.Y + 1))) neighbors.Add(boardStones[(stone.X, stone.Y + 1)]);
            if (boardStones.ContainsKey((stone.X, stone.Y - 1))) neighbors.Add(boardStones[(stone.X, stone.Y - 1)]);
            return neighbors;
        }

        private void UpdateLiberties(Stone stone, List<Stone> neighbors) {
            stone.Liberties = 4 - neighbors.Count();
            // Edges - there is no liberties outside the board
            if (stone.X == 1 || stone.X == 9) stone.Liberties--;
            if (stone.Y == 1 || stone.Y == 9) stone.Liberties--;
            foreach (Stone n in neighbors)
                n.Liberties--;
        }

        private void RemoveStones(List<Stone> stones) {
            foreach(Stone stone in stones) {
                List<Stone> neighbors = GetNeighbors(stone);
                boardStones.Remove((stone.X, stone.Y));
                foreach(Stone s in neighbors) {
                    s.Liberties++;
                }
            }
        }

        private void UpdateChain(Stone stone, List<Stone> neighbors) {
            stone.Chain = new Chain(stone);
            foreach(Stone n in neighbors) {
                if(n.stoneColor == stone.stoneColor) {
                    stone.Chain.Join(n.Chain);
                }
            }
        }

        private void UpdateChainOnly(Stone stone, List<Stone> neighbors) {
            foreach (Stone n in neighbors) {
                if (n.stoneColor == stone.stoneColor) {
                    stone.Chain.Join(n.Chain);
                }
            }
        }

        private List<Stone> GetEnemyCaptures(Stone stone, List<Stone> neighbors) {
            List<Stone> captured = new List<Stone>();
            foreach(Stone n in neighbors) {
                if(n.stoneColor != stone.stoneColor && n.Chain.GetLiberties() == 0) {
                    foreach(Stone cs in n.Chain.Stones) {
                        if (captured.Count(q => q.X == cs.X && q.Y == cs.Y) == 0) captured.Add(cs);
                    }
                }
            }
            return captured;
        }

        private List<Stone> GetSelfCaptures(Stone stone, List<Stone> neighbors) {
            List<Stone> captured = new List<Stone>();
            foreach (Stone s in neighbors) {
                if (s.stoneColor == stone.stoneColor && s.Chain.GetLiberties() == 0) {
                    foreach (Stone cs in s.Chain.Stones) {
                        if (captured.Count(q => q.X == cs.X && q.Y == cs.Y) == 0) captured.Add(cs);
                    }
                }
            }
            return captured;
        }

        private List<Stone> PutNeutralTerritoryStones() {
            List<Stone> territoryStones = new List<Stone>();
            for (int i = 1; i <= boardSize; i++) {
                for (int j = 1; j <= boardSize; j++) {
                    if (!boardStones.ContainsKey((i, j))) {
                        var stone = new Stone { X = i, Y = j, stoneColor = StoneColor.territoryNeutral };
                        stone.Chain = new Chain(stone);
                        boardStones.Add((i, j), stone);
                        territoryStones.Add(stone);
                    }
                }
            }
            return territoryStones;
        }

        private void RemoveTerritoryStones() {
            for (int i = 1; i <= boardSize; i++) {
                for (int j = 1; j <= boardSize; j++) {
                    if (boardStones[(i, j)].stoneColor == StoneColor.territoryNeutral ||
                        boardStones[(i, j)].stoneColor == StoneColor.territoryBlack ||
                        boardStones[(i, j)].stoneColor == StoneColor.territoryWhite) {

                        boardStones.Remove((i, j));
                    }
                        
                }
            }
        }

        private void UpdateTerritory(List<Stone> territoryStones) {
            var territoryChains = new List<Chain>();
            foreach(Stone stone in territoryStones) {
                if (!territoryChains.Contains(stone.Chain)) territoryChains.Add(stone.Chain);
            }
            // check every chain if it should be black, white or neutral
            foreach(Chain chain in territoryChains) {
                bool blackNeighbor = false;
                bool whiteNeighbor = false;
                StoneColor newStoneColor = StoneColor.territoryNeutral;
                // determine territory owner
                foreach(Stone stone in chain.Stones) {
                    var neighbors = GetNeighbors(stone);
                    foreach (Stone s in neighbors) {
                        if (s.stoneColor == StoneColor.black) blackNeighbor = true;
                        if (s.stoneColor == StoneColor.white) whiteNeighbor = true;
                    }
                    if (blackNeighbor && whiteNeighbor) break; // territory will be neutral for sure
                }
                if (blackNeighbor && whiteNeighbor) newStoneColor = StoneColor.territoryNeutral;
                else if (blackNeighbor) newStoneColor = StoneColor.territoryBlack;
                else if (whiteNeighbor) newStoneColor = StoneColor.territoryWhite;
                // update stones color
                foreach (Stone stone in chain.Stones) stone.stoneColor = newStoneColor;
            }
        }

        private Score GetScore(List<Stone> territoryStones) {
            int BlackTerritory = 0;
            int WhiteTerritory = 0;
            int NeutralTerritory = 0;
            foreach(Stone stone in territoryStones) {
                if (stone.stoneColor == StoneColor.territoryNeutral) NeutralTerritory++;
                if (stone.stoneColor == StoneColor.territoryBlack) BlackTerritory++;
                if (stone.stoneColor == StoneColor.territoryWhite) WhiteTerritory++;
            }
            return new Score { NeutralTerritory = NeutralTerritory, BlackTerritory = BlackTerritory, WhiteTerritory = WhiteTerritory, stones = territoryStones };
        }
    }
}
