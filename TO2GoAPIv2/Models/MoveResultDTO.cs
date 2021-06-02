using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Models
{
    public class MoveResultDTO
    {
        public MoveDTO MoveDTO { get; set; }
        public List<StoneDTO> CapturedStones { get; set; }
    }
}
