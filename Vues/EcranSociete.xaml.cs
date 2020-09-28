using System;
using System.Collections.Generic;
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
using Bourse.Outils;
using Bourse.VuesModele;

namespace Bourse.Vues
{
    /// <summary>
    /// Logique d'interaction pour EcranSociete.xaml
    /// </summary>
    public partial class EcranSociete : UserControl
    {
        public EcranSociete()
        {
            InitializeComponent();
            EvenementBourse.ChangementImageSociete += AjusteImageSociete;
            DataContext = new Societe_VM();
        }

        public void AjusteImageSociete(object sender, ChangementImageSocieteEventArgs e)
        {
            BitmapImage bmiSociete = new BitmapImage();
            bmiSociete.BeginInit();
            bmiSociete.UriSource = new Uri("pack://application:,,,/Images/Societes/Societe" + e.SocieteId + ".jpg");
            bmiSociete.EndInit();

            img_Societe.Source = bmiSociete;
        }
    }
}
