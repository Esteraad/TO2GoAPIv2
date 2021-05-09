using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Data
{
    public enum BoardSize
    {
        _9x9,
        _13x13,
        _19x19
    }

    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<GamePlayer> GamePlayers { get; set; }
        public BoardSize BoardSize { get; set; }
        public int TimeLimit { get; set; }
        public DateTime CreatedDate { get; set; }
        public GameStart GameStart { get; set; }
        public GameFinish GameFinish { get; set; }
        public GameWinner GameWinner { get; set; }
    }
}
