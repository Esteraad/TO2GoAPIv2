using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Logic
{
    public class Chain
    {
        public List<Stone> Stones { get; set; } = new List<Stone>();

        public Chain(Stone stone) {
            Stones.Add(stone);
        }
        public int GetLiberties() {
            int total = 0;
            foreach (Stone stone in Stones) {
                total += stone.Liberties;
            }
            return total;
        }

        public void Join(Chain chain) {
            foreach(Stone stone in chain.Stones) {
                if(Stones.Count(s => s.X == stone.X && s.Y == stone.Y) == 0) {
                    Stones.Add(stone);
                    stone.Chain = this;
                }
            }
        }
    }
}
