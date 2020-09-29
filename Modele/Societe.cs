using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourse.Modele
{
    public class Societe
    {
        public int ID { get; set; }
        public string RaisonSociale { get; set; }
        public int NbActions { get; set; }
        public int ValeurUnitaire { get; set; }
        public DateTime DateCreation { get; set; }
        public ObservableCollection<Transaction> Actionnaires { get; set; }


        public Societe() { Actionnaires = new ObservableCollection<Transaction>(); }
        public Societe(DataRow dr)
        {
            ID = (int)dr["id"];
            RaisonSociale = (string)dr["raisonSociale"];
            NbActions = (int)dr["nbActions"];
            ValeurUnitaire = (int)dr["valeurUnitaire"];
            DateCreation = (DateTime)dr["dateCreation"];
        }
    }
}
