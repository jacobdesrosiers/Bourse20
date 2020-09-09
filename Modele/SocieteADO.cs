using Bourses.Outils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourses.Modele
{
    class SocieteADO
    {
        private BDBase MaBD;

        public SocieteADO() { MaBD = new BDBase(); }
        public List<Societe> Recuperer()
        {
            List<Societe> establishment = new List<Societe>();
            string sel = "select * from Societes";
            DataSet SetSociete = MaBD.Selection(sel);
            DataTable TableSociete = SetSociete.Tables[0];

            foreach (DataRow RowSociete in TableSociete.Rows)
            {
                establishment.Add(new Societe(RowSociete));
            }
            return establishment;
        }

        public void Modifier(Societe s)
        {
            string req = "update Societes set raisonSociale = '" + s.RaisonSociale + "', nbActions = " + s.NbActions + ", valeurUnitaire = " + s.ValeurUnitaire + ", dateCreation= '" + s.DateCreation + "' where ID =" + s.ID;
            MaBD.Commande(req);
        }

        public Societe RecupererUn(int id)
        {
            string sel = "select * from Societes where ID = " + id;
            DataSet SetSociete = MaBD.Selection(sel);
            DataTable TableSociete = SetSociete.Tables[0];

            return new Societe(TableSociete.Rows[0]);
        }

        public void Supprimer(int id)
        {
            string req = "delete from Societes where ID = " + id;
            MaBD.Commande(req);
        }
    }
}
