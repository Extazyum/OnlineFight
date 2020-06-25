using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFight.Model
{
    public class DbFightContext : DbContext
    {
        public DbSet<Historique> Historiques { get; set; }
        public DbSet<Personnage> Personnages { get; set; }
        public DbSet<Combat> Combats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($@"Data Source=OnlineFight.db");
    }

}

