using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourses.Modele
{
    public class Proprietaire
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public DateTime Naissance { get; set; }
        public int Liquidite { get; set; }

        public Proprietaire() { }
        public Proprietaire(DataRow dr)
        {
            ID = (int)dr["ID"];
            Nom = (string)dr["Nom"];
            Naissance = (DateTime)dr["Naissance"];
            Liquidite = (int)dr["Liquidite"];
        }
    }
}
