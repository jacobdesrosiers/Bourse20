using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Bourse.Outils;
using Bourse.Modele;

namespace Bourse.VuesModele
{
    class Proprietaire_VM : INotifyPropertyChanged
    {
        public ICommand cmdAjouter_Proprio { get; set; }
        public ICommand cmdModifier_Proprio { get; set; }
        public ICommand cmdSupprimer_Proprio { get; set; }
        public ICommand cmdOperationTransactionnelle { get; set; }

        public Proprietaire_VM()
        {
            cmdAjouter_Proprio = new Commande(cmdAjouter);
            cmdModifier_Proprio = new Commande(cmdModifier);
            cmdSupprimer_Proprio = new Commande(cmdSupprimer);
            cmdOperationTransactionnelle = new Commande(cmdTrx);
            initProprio();

        }


        #region Propriétés


        private ProprietaireADO proprietaireADO = new ProprietaireADO();

        private ObservableCollection<Proprietaire> _sommaireProprietaires;
        public ObservableCollection<Proprietaire> SommaireProprietaires
        {
            get { return _sommaireProprietaires; }
            set
            {
                _sommaireProprietaires = value;
                OnPropertyChanged("SommaireProprietaires");
            }
        }

        private Proprietaire _proprietaireSelectionne;
        public Proprietaire ProprietaireSelectionne
        {
            get { return _proprietaireSelectionne; }

            set
            {
                _proprietaireSelectionne = value;
                if (_proprietaireSelectionne == null)
                    return;
                Nom = _proprietaireSelectionne.Nom;
                Naissance = _proprietaireSelectionne.Naissance;
                Liquidite = _proprietaireSelectionne.Liquidite;
                if(_proprietaireSelectionne.ID < 4)
                {
                    EvenementBourse.OnChangementImageProprio(new ChangementImageProprioEventArgs(_proprietaireSelectionne.ID));
                }
                else
                {
                    EvenementBourse.OnChangementImageProprio(new ChangementImageProprioEventArgs(0));
                }
                OnPropertyChanged("ProprietaireSelectionne");
            }
        }

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                OnPropertyChanged("Nom");
            }

        }
        private DateTime _naissance;
        public DateTime Naissance
        {
            get { return _naissance; }
            set
            {
                _naissance = value;
                OnPropertyChanged("Naissance");
            }
        }

        private int _liquidite;
        public int Liquidite
        {
            get { return _liquidite; }
            set
            {
                _liquidite = value;
                OnPropertyChanged("Liquidite");
            }
        }
        #endregion

        private void initProprio()
        {
            SommaireProprietaires = new ObservableCollection<Proprietaire>();
            var pRequete = from proprio in OutilEF.BrsCtx.Capitalistes select proprio;

            foreach (Proprietaire prop in pRequete)
                SommaireProprietaires.Add(prop);

            // Activer la ligne suivante si vous voulez utiliser ADO et API mySQLi
            //SommaireProprietaires = proprietaireADO.Recuperer();

            //Proprietaire prop = new Proprietaire();
            //prop.Nom = "Lino Saputo";
            //prop.ID = 1;
            //prop.Naissance = new DateTime(1948, 1, 1);
            //prop.Liquidite = 30000;
            //SommaireProprietaires.Add(prop);
        }

        private void cmdAjouter(object param)
        {
            Proprietaire p = new Proprietaire();
            p.Nom = Nom;
            p.Naissance = Naissance;
            p.Liquidite = Liquidite;

            SommaireProprietaires.Add(p);
            proprietaireADO.Ajouter(p);
            ProprietaireSelectionne = p;
        }

        private void cmdModifier(object param)
        {
            if (ProprietaireSelectionne == null)
                return;

            Proprietaire pNeo = new Proprietaire();
            pNeo.ID = ProprietaireSelectionne.ID;
            pNeo.Nom = Nom;
            pNeo.Naissance = Naissance;
            pNeo.Liquidite = Liquidite;

            ObservableCollection<Proprietaire> listPropTmp = new ObservableCollection<Proprietaire>();
            foreach (Proprietaire p in SommaireProprietaires)
            {
                if (p.ID == pNeo.ID)
                    listPropTmp.Add(pNeo);
                else
                    listPropTmp.Add(p);
            }
            proprietaireADO.Modifier(pNeo);
            SommaireProprietaires = listPropTmp;
            ProprietaireSelectionne = pNeo;
        }

        private void cmdSupprimer(object param)
        {
            if (ProprietaireSelectionne == null)
                return;

            proprietaireADO.Supprimer(ProprietaireSelectionne.ID);
            SommaireProprietaires.Remove(ProprietaireSelectionne);
            ProprietaireSelectionne = null;
            Nom = null;
            Liquidite = 0;
            Naissance = new DateTime();
        }

        private void cmdTrx(object param)
        {
            proprietaireADO.OpperationComplexe();
        }

        private void cmdVider_Proprio(object sender, RoutedEventArgs e)
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }
    }
}
