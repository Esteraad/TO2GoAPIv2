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
        public MoveType Type { get; set; }
        /// <summary>
        /// Required if MoveType = 0 (PutStone)
        /// </summary>
        public short PosX { get; set; }
        /// <summary>
        /// Required if MoveType = 0 (PutStone)
        /// </summary>
        public short PosY { get; set; }
    }

    public class MoveDTO : CreateMoveDTO
    {
        public int Id { get; set; }
        public GetUserDTO ApiUser { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
