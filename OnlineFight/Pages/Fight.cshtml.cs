using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OnlineFight.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineFight.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public void CreateFight(Personnage personnage1 , Personnage personnage2)
        {
            Combat combat = new Combat();
            combat.Loser = personnage1;
            combat.Winner = personnage2;

            using (var db = new DbFightContext())
            {
                db.Combats.Add(combat);
                db.SaveChanges();
            }
        }


        public void CreatePersonnage(int pv , int degat , int defense)
        {
            Personnage personnage = new Personnage();
            personnage.Pv = pv;
            personnage.Attaque = degat;
            personnage.PvMax = pv;
            personnage.Defense = defense;

            using (var db = new DbFightContext())
            {
                db.Personnages.Add(personnage);
                db.SaveChanges();
            }

        }
        public void CreateRandomPersonnage(Personnage personnage)
        {
            Personnage personnageRandom = new Personnage();
            
            personnageRandom.Pv = (int) Math.Floor(new Random().NextDouble() * ((personnage.PvMax * 0.2 + personnage.PvMax) -
                                                                                (personnage.PvMax * 0.2 - personnage.PvMax) - personnage.PvMax * 0.2 - personnage.PvMax));
            personnageRandom.Attaque = (int)Math.Floor(new Random().NextDouble() * ((personnage.Attaque * 0.2 + personnage.Attaque) -
                                                                                    (personnage.Attaque * 0.2 - personnage.Attaque) - personnage.Attaque * 0.2 - personnage.Attaque));
            personnageRandom.PvMax = personnageRandom.Pv;
            personnageRandom.Defense = (int)Math.Floor(new Random().NextDouble() * ((personnage.Attaque * 0.2 + personnage.Attaque) -
                                                                                    (personnage.Attaque * 0.2 - personnage.Attaque) - personnage.Attaque * 0.2 - personnage.Attaque));

            using var db = new DbFightContext();
            db.Personnages.Add(personnageRandom);
            db.SaveChanges();
        }

        public int DealDamage(Personnage personnageA, Personnage personnageD,int turn,int combatid)
        {
            Historique historique = new Historique();
            personnageD.Pv -= personnageA.Attaque - personnageD.Defense;
            historique.personnageACtif = personnageA;
            historique.personnagePassif = personnageD;
            historique.Degat = personnageA.Attaque - personnageD.Defense;
            historique.Turn = turn;
            using (var db = new DbFightContext())
            {
                db.Historiques.Add(historique);
                db.SaveChanges();
            }
            if (personnageD.Pv < 0)
            {
                personnageD.Pv = 0;
                using (var db = new DbFightContext())
                {
                    var combat = db.Combats.Where(x => x.Id == combatid).First();
                    db.Combats.Update(combat);
                    db.SaveChanges();
                }


            }

            return personnageD.Pv;

        }

        public int BotAttaque(Personnage personnageA, Personnage personnageD, int turn,int combatid)
        {
            Historique historique = new Historique();
            personnageD.Pv -= personnageA.Attaque - personnageD.Defense;
            historique.personnageACtif = personnageA;
            historique.personnagePassif = personnageD;
            historique.Degat = personnageA.Attaque - personnageD.Defense;
            historique.Turn = turn;
            historique.CombatId = combatid;
            using (var db = new DbFightContext())
            {
                db.Historiques.Add(historique);

            }

            if (personnageD.Pv < 0)
            {
                personnageD.Pv = 0;
                using (var db = new DbFightContext())
                {
                    var combat = db.Combats.Where(x=> x.Id == combatid).First();
                    db.Combats.Update(combat);
                    db.SaveChanges();
                }
                

            } 

            return personnageD.Pv;

        }
        public int UsePotions(Personnage personnageA,Personnage personnageB,int turn,int combatid)
        {

            Historique historique = new Historique();
            historique.personnageACtif = personnageA;
            historique.personnagePassif = personnageB;
            historique.Degat = -20;
            historique.Turn = turn;
            historique.CombatId = combatid;


            personnageA.Pv += 20;
            using (var db = new DbFightContext())
            {
                db.Historiques.Add(historique);
                db.SaveChanges();
            }

            return personnageA.Pv;

        }
        public List<Historique> GetHistoriques(int idcombat)
        {
            using (var db = new DbFightContext())
            {
                
            return db.Historiques.Where(x => x.CombatId == idcombat).ToList();
            }
        }

    }
}
