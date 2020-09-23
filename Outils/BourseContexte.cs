using Bourse.Modele;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourse.Outils
{
    class BourseContexte : DbContext
    {
        public DbSet<Proprietaire> Capitalistes { get; set; }
        public DbSet<Societe> LEconomie { get; set; }
        public DbSet<Transaction> RegistreTrx { get; set; }

        public BourseContexte() : base("Name = connexionBourse20")
        {
            // Database.SetInitializer<BourseContexte>(new DropCreateDatabaseAlways<BourseContexte>());
            Database.SetInitializer<BourseContexte>(new CreateDatabaseIfNotExists<BourseContexte>());
        }

    }
}
