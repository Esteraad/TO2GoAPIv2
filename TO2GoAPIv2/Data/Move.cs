using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Data
{
    public enum MoveType
    {
        putStone,
        pass,
        surrender,
        capture
    }

    public class Move
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public string ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }
        public MoveType Type { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
