using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFight.Model
{
    public class Combat
    {
        public int Id { get; set; }
        public Personnage Winner { get; set; }
        public Personnage Loser { get; set; }

    }
}
