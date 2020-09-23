using Bourse.Modele;
using Bourse.Outils;
using Bourse.Modele;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                    
                    if(_societeSelectionnee != null)
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
                OnPropertyChanged("ProprietaireSelectione");
            }
        }

        private Societe _societeSelectionnee;
        public Societe SocieteSelectionnee
        {
            get
            {
                return _societeSelectionnee;
            }
            set
            {
                if (value != null)
                {
                    _societeSelectionnee = value;
                    string Trxtxt = "";

                    if (_proprietaireSelectionne != null)
                    {
                        Trxtxt += _proprietaireSelectionne.Nom + " achète du " + _societeSelectionnee.RaisonSociale;
                    }
                    else
                    {
                        Trxtxt += "? achète du " + _societeSelectionnee.RaisonSociale;
                    }
                }
                else
                {
                    _societeSelectionnee = null;
                }
                OnPropertyChanged("SocieteSelectionnee");
            }
        }

        private string _transactionTexte;
        public string TransactionTexte
        {
            get { return _transactionTexte; }

            set 
            {
                _transactionTexte = value;
                OnPropertyChanged("TransactionTexte");
            }
        }

        private string _qttAcquise;
        public string QttAcquise 
        {
            get { return _qttAcquise; }

            set
            {
                _qttAcquise = value;
                OnPropertyChanged("QttAcquise");
            }
        }

        private ObservableCollection<Societe> _listeSocietes;
        public ObservableCollection<Societe> ListeSocietes
        {
            get { return _listeSocietes; }

            set 
            {
                _listeSocietes = value;
                OnPropertyChanged("ListeSocietes");
            }
        }

        private ObservableCollection<Proprietaire> _listeProprietaires;
        public ObservableCollection<Proprietaire> ListeProprietaires
        {
            get { return _listeProprietaires; }

            set
            {
                _listeProprietaires = value;
                OnPropertyChanged("ListeProprietaires");
            }
        }

        private ObservableCollection<Transaction> _listeTrx;
        public ObservableCollection<Transaction> ListeTrx
        {
            get { return _listeTrx; }

            set
            {
                _listeTrx = value;
                OnPropertyChanged("ListeTrx");
            }
        }

        public Transaction_VM()
        {
            cmdAjouterTrx = new Commande(AquisitionDActions);
            cmdViderChamps = new Commande(ViderChamps);
        }

        public void ViderChamps(object param)
        {
            ProprietaireSelectione = null;
            SocieteSelectionnee = null;
            TransactionTexte = "";
        }

        public void AquisitionDActions(object param)
        {
            Transaction t = new Transaction();
            t.Acheteur = _proprietaireSelectionne;
            t.CIEVendue = _societeSelectionnee;

            t.NbActions = Convert.ToInt32(QttAcquise);
            t.CoutUnitaire = _societeSelectionnee.ValeurUnitaire;
            t.Total = t.NbActions * t.CoutUnitaire;

            ListeTrx.Add(t);
            OutilEF.BrsCtx.RegistreTrx.Add(t);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
            }
        }
    }
}
