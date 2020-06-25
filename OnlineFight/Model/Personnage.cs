using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFight.Model
{
    public class Personnage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Attaque { get; set; }
        public int Defense { get; set; }
        public int Pv { get; set; }
        public int PvMax { get; set; }
        public enum Race
        {
            HotDog = 1,
            Lasagne =2,
            Girl =3
        }
    }
}
