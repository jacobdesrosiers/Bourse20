using Bourse.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bourse.Outils
{
    class OutilEF
    {
        public static BourseContexte BrsCtx;

        public OutilEF()
        {
            try
            {
                BrsCtx = new BourseContexte();
                BrsCtx.Database.Initialize(force: true);
            }
            catch(Exception e)
            {
                if(e.Message != "La clé est trop longue. Longueur maximale: 1000")
                {
                    MessageBox.Show("Erreur de l'initialisation de l'ORM");
                }
            }

            //insertions();
        }

        private void insertions()
        {
            Proprietaire p = new Proprietaire();
            p.Nom = "Alberto";
            p.Naissance = DateTime.Now;
            p.Liquidite = 12345;
            BrsCtx.Capitalistes.Add(p);

            Proprietaire p1 = new Proprietaire();
            p1.Nom = "Bennito";
            p1.Naissance = new DateTime(1965, 6, 23, 10, 10, 10);
            p1.Liquidite = 54321;
            BrsCtx.Capitalistes.Add(p1);

            Societe s = new Societe();
            s.RaisonSociale = "Harvey's and Hamburgers";
            s.DateCreation = DateTime.Now;
            s.NbActions = 60000;
            s.ValeurUnitaire = 2344;
            BrsCtx.LEconomie.Add(s);

            s = new Societe();
            s.RaisonSociale = "Dollarama";
            s.DateCreation = DateTime.Now;
            s.NbActions = 60000;
            s.ValeurUnitaire = 2344;
            BrsCtx.LEconomie.Add(s);

            Transaction t = new Transaction();
            t.DateTrx = DateTime.Now;
            t.NbActions = 15;
            t.CoutUnitaire = 30;
            p.PorteFeuille.Add(t);
            s.Actionnaires.Add(t);

            t = new Transaction();
            t.DateTrx = DateTime.Now;
            t.NbActions = 11;
            t.CoutUnitaire = 58;
            p1.PorteFeuille.Add(t);
            s.Actionnaires.Add(t);

            t = new Transaction();
            t.DateTrx = DateTime.Now;
            t.NbActions = 12;
            t.CoutUnitaire = 67;
            p1.PorteFeuille.Add(t);
            s.Actionnaires.Add(t);

            BrsCtx.SaveChanges();
        }
    }
}
