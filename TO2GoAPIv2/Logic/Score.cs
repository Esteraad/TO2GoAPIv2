using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Logic
{
    public class Score
    {
        public int BlackTerritory { get; set; }
        public int WhiteTerritory { get; set; }
        public int NeutralTerritory { get; set; }

        public List<Stone> stones { get; set; } = new List<Stone>();
    }
}
