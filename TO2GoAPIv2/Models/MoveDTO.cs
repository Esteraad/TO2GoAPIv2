using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TO2GoAPIv2.Data;

namespace TO2GoAPIv2.Models
{
    public class CreateMoveDTO
    {
        [Required]
        public int GameId { get; set; }
        [Required]
        public MoveType Type { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
    }

    public class MoveDTO : CreateGameDTO 
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
