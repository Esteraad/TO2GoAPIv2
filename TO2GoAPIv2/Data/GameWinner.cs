using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Data
{
    public class GameWinner
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public string ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }
    }
}
