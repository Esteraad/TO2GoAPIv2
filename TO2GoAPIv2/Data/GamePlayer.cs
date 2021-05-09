using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Data
{
    public class GamePlayer
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public string ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }
        public bool BlackColor { get; set; }
        public bool GameOwner { get; set; }
        public bool Ready { get; set; }
    }
}
