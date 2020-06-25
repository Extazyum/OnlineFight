using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFight.Model
{
    public class Historique
    {
        public int Id { get; set; }
        public int Degat { get; set; }
        public int Turn { get; set; }
        public Personnage personnageACtif { get; set; }
        public Personnage personnagePassif { get; set; }
        public int CombatId { get; set; }
    }
}
