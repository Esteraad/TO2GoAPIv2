using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TO2GoAPIv2.Data;

namespace TO2GoAPIv2.Models
{
    public class CreateGamePlayerDTO
    {
        [Required]
        public bool BlackColor { get; set; }
    }

    public class GamePlayerDTO
    {
        public int GameId { get; set; }
        public GetUserDTO ApiUser { get; set; }
        public bool BlackColor { get; set; }
        public bool GameOwner { get; set; }
        public bool Ready { get; set; }
    }
}
