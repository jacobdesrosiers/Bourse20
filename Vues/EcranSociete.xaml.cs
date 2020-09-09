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
    /// Logique d'interaction pour EcranSociete.xaml
    /// </summary>
    public partial class EcranSociete : UserControl, INotifyPropertyChanged
    {
        private SocieteADO societeADO = new SocieteADO();

        public EcranSociete()
        {
            InitializeComponent();
            DataContext = this;
            SommaireSocietes = societeADO.Recuperer();
        }

        private void cmdAjouter_Societe(object sender, RoutedEventArgs e)
        {

        }

        private void cmdModifier_Societe(object sender, RoutedEventArgs e)
        {

        }

        private void cmdSupprimer_Societe(object sender, RoutedEventArgs e)
        {

        }

        private void cmdVider_Societe(object sender, RoutedEventArgs e)
        {

        }

        private ObservableCollection<Societe> _sommaireSocietes;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }


        public ObservableCollection<Societe> SommaireSocietes
        {
            get
            {
                return _sommaireSocietes;
            }
            set
            {
                _sommaireSocietes = value;
                OnPropertyChanged("SommaireSocietes");
            }
        }
    }
}
