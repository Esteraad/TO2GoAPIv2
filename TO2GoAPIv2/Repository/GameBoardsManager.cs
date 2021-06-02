using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TO2GoAPIv2.Controllers;
using TO2GoAPIv2.Data;
using TO2GoAPIv2.IRepository;
using TO2GoAPIv2.Logic;

namespace TO2GoAPIv2.Repository
{
    public class GameBoardsManager : IGameBoardsManager
    {
        private List<GameBoard> gameBoards = new List<GameBoard>();
        public async Task<GameBoard> GetGameBoard(int gameId, IUnitOfWork unitOfWork, ILogger<MoveController> logger) {
            var gameBoard = gameBoards.FirstOrDefault(g => g.GameId == gameId);
            if (gameBoard != null) {
                return gameBoard;
            }
            var game = await unitOfWork.Games.Get(q => q.Id == gameId, new List<string> { "GamePlayers.ApiUser", "GameStart", "GameFinish", "GameWinner" });
            string blackPlayerId = game.GamePlayers.FirstOrDefault(p => p.BlackColor).ApiUser.Id;
            int boardSize;
            if (game.BoardSize == BoardSize._9x9) boardSize = 9;
            else if (game.BoardSize == BoardSize._13x13) boardSize = 13;
            else boardSize = 19;
            var newGameBoard = new GameBoard(gameId, boardSize, logger);

            var moves = await unitOfWork.Moves.GetAll(q => q.GameId == gameId, includes: new List<string> { "ApiUser" });

            foreach (Move move in moves) {
                if (move.Type == MoveType.pass) newGameBoard.Pass(move.ApiUser.Id == blackPlayerId ? true : false);
                else if (move.Type == MoveType.putStone) newGameBoard.AddStone(move.PosX, move.PosY, move.ApiUser.Id == blackPlayerId ? true : false);
            }
            gameBoards.Add(newGameBoard);
            return newGameBoard;
        }
    }
}
