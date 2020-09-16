using Bourses.Outils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bourses.Modele
{
    class ProprietaireADO
    {
        private BDBase MaBD;

        public ProprietaireADO() { MaBD = new BDBase(); }

        public ObservableCollection<Proprietaire> Recuperer()
        {
            ObservableCollection<Proprietaire> establishment = new ObservableCollection<Proprietaire>();
            string sel = "select * from proprietaires";
            DataSet SetProprietaire = MaBD.Selection(sel);
            DataTable TableProprietaire = SetProprietaire.Tables[0];

            foreach (DataRow RowProprietaire in TableProprietaire.Rows)
            {
                establishment.Add(new Proprietaire(RowProprietaire));
            }
            return establishment;
        }

        public void Modifier(Proprietaire p)
        {
            string req = "update proprietaires set Nom = '" + p.Nom + "', Naissance = '" + p.Naissance + "', liquidite = " + p.Liquidite + " where ID =" + p.ID;
            MaBD.Commande(req);
        }

        public Proprietaire RecupererUn(int id)
        {
            string sel = "select * from proprietaires where ID = " + id;
            DataSet SetProprietaire = MaBD.Selection(sel);
            DataTable TableProprietaire = SetProprietaire.Tables[0];

            return new Proprietaire(TableProprietaire.Rows[0]);
        }

        public void Supprimer(int id)
        {
            string req = "delete from proprietaires where ID = " + id;
            MaBD.Commande(req);
        }

        public void OpperationComplexe()
        {
            try
            {
                MaBD.TransactionDebut();
                Proprietaire p = new Proprietaire();
                p.Nom = "Vincent";
                p.Naissance = new DateTime(1998, 07, 28);
                p.Liquidite = 18000;
                Ajouter(p);

                p.Nom = "Joe Blo";
                p.Naissance = new DateTime(1908, 01, 28);
                p.Liquidite = 180000;
                Ajouter(p);

                Supprimer(5);
                MaBD.TransactionAnnulee();
            }
            catch (Exception)
            {
                MaBD.TransactionAnnulee();
                MessageBox.Show("Un problème transactionnel est survenu.");
                throw;
            }
        }

        public void Ajouter(Proprietaire p)
        {
            string req = "insert into proprietaires values(NULL,'" + p.Nom + "', '" + p.Naissance + "', " + p.Liquidite + ")";
            MaBD.Commande(req);
        }
    }
}
