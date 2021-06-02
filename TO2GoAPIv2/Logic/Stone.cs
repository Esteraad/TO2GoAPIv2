using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Logic
{
    public enum StoneColor
    {
        black,
        white,
        territoryNeutral,
        territoryBlack,
        territoryWhite
    }

    public class Stone
    {
        public Chain Chain { get; set; }
        public int Liberties { get; set; } = 4;
        public int X { get; set; }
        public int Y { get; set; }
        public StoneColor stoneColor { get; set; }

        public override string ToString() {
            return X.ToString() + Y.ToString() + (stoneColor == StoneColor.black ? "b" : "w");
        }

    }
}
