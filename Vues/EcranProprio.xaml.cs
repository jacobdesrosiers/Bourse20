using Bourse.Outils;
using Bourse.VuesModele;
using Bourse.Modele;
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

namespace Bourse.Vues
{
    /// <summary>
    /// Interaction logic for EcranProprio.xaml
    /// </summary>
    public partial class EcranProprio : UserControl
    {

        public EcranProprio()
        {
            InitializeComponent();
            EvenementBourse.ChangementImageProprio += AjusteImageProprio;
            DataContext = new Proprietaire_VM();
        }

        public void AjusteImageProprio(object sender, ChangementImageProprioEventArgs e)
        {
            BitmapImage bmiProprio = new BitmapImage();
            bmiProprio.BeginInit();
            bmiProprio.UriSource = new Uri("pack://application:,,,/Images/Proprios/proprio" + e.ProprioId + ".jpg");
            bmiProprio.EndInit();

            img_Proprio.Source = bmiProprio;
		  }
    }
}
