using Bourses.Modele;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bourses.Vues
{
    /// <summary>
    /// Logique d'interaction pour EcranProprio.xaml
    /// </summary>
    public partial class EcranProprio : UserControl, INotifyPropertyChanged
    {
        private ProprietaireADO proprietaireADO = new ProprietaireADO();
        private ObservableCollection<Proprietaire> _sommaireProprietaires;
        public ObservableCollection<Proprietaire> SommaireProprietaires
        {
            get { return _sommaireProprietaires; }

            set
            {
                _sommaireProprietaires = proprietaireADO.Recuperer();
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
                OnPropertyChanged("ProprietaireSeclectionne");
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
        public EcranProprio()
        {

            initProprio();
            InitializeComponent();

            DataContext = this;
        }

        private void initProprio()
        {
            SommaireProprietaires = proprietaireADO.Recuperer();
            
            /*
            Proprietaire prop = new Proprietaire();
            prop.Nom = "Lino Saputo";
            prop.ID = 1;
            prop.Naissance = new DateTime(1948, 01, 01);
            prop.Liquidite = 30000;
            SommaireProprietaires.Add(prop);
            */
        }

        private void cmdAjouter_Proprio(object sender, RoutedEventArgs e)
        {
            Proprietaire p = new Proprietaire();
            p.Nom = Nom;
            p.Naissance = Naissance;
            p.Liquidite = Liquidite;

            SommaireProprietaires.Add(p);
            proprietaireADO.Ajouter(p);
            ProprietaireSelectionne = p;
        }

        private void cmdModifier_Proprio(object sender, RoutedEventArgs e)
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
                SommaireProprietaires = listPropTmp;
                proprietaireADO.Modifier(pNeo);
                ProprietaireSelectionne = pNeo;
            }
        }

        private void cmdSupprimer_Proprio(object sender, RoutedEventArgs e)
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
