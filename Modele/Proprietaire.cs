using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourse.Modele
{
    public class Proprietaire
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public DateTime Naissance { get; set; }
        public int Liquidite { get; set; }
        public ICollection<Transaction> PorteFeuille { get; set; }

        public Proprietaire() { PorteFeuille = new Collection<Transaction>(); }
        public Proprietaire(DataRow dr)
        {
            ID = (int)dr["ID"];
            Nom = (string)dr["Nom"];
            Naissance = (DateTime)dr["Naissance"];
            Liquidite = (int)dr["Liquidite"];
        }
    }
}
