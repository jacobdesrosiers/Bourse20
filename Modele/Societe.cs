using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourses.Modele
{
    class Societe
    {
        public int ID { get; set; }
        public string RaisonSociale { get; set; }
        public int NbActions { get; set; }
        public int ValeurUnitaire { get; set; }
        public DateTime DateCreation { get; set; }

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
