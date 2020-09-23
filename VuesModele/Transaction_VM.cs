using Bourse.Modele;
using Bourse.Outils;
using Bourses.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bourse.VuesModele
{
    class Transaction_VM : INotifyPropertyChanged
    {
        public ICommand cmdAjouterTrx { get; set; }
        public ICommand cmdViderChamps { get; set; }

        private Proprietaire _proprietaireSelectionne;
        public Proprietaire ProprietaireSelectione 
        {
            get
            {
                return _proprietaireSelectionne;
            }
            set
            {
                if (value != null)
                {
                    _proprietaireSelectionne = value;
                    string Trxtxt = _proprietaireSelectionne.Nom + " achète du ";
                    
                    if(_societeSelectionnee)
                    {
                        Trxtxt += _societeSelectionnee.RaisonSociale;
                    }
                    else
                    {
                        Trxtxt += "?";
                    }
                }
                else
                {
                    _proprietaireSelectionne = null;
                }
                OnPropertyChanged();
            }
        }

        public object OnPropertyChanged { get; private set; }

        public Transaction_VM()
        {
            cmdAjouterTrx = new Commande(AquisitionDActions);
            cmdViderChamps = new Commande(ViderChamps);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AquisitionDActions(object param)
        {
            Transaction t = new Transaction();
            t.Acheteur = _proprietaireSelectionne;
            t.CIEVendue = _societeSelectionnee;

            t.NbActions = Convert.ToInt32(QttAquise);
            t.CoutUnitaire = _societeSelectionnee.valeurUnitaire;
            t.Total = t.NbActions * t.CoutUnitaire;
        }
    }
}
