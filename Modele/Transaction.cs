using Bourse.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourse.Modele
{
    public class Transaction
    {
        public int Id { get; set; }
        public int NbActions { get; set; }
        public int CoutUnitaire { get; set; }
        public DateTime DateTrx { get; set; }
        private int _total;
        public int Total 
        { 
            get { return CoutUnitaire * NbActions; }
            set { _total = value; } 
        }
        public Proprietaire Acheteur {get;set;}
        public Societe CIEVendue { get; set; }
        public Transaction()
        {
            
        }
    }
}
