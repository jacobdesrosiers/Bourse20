using Bourses.Vues;
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

namespace Bourses
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmd_proprio(object sender, RoutedEventArgs e)
        {
            img_logo.Visibility = Visibility.Collapsed;
            presenteurContenu.Content = new EcranProprio();
        }

        private void cmd_societe(object sender, RoutedEventArgs e)
        {
            img_logo.Visibility = Visibility.Collapsed;
            presenteurContenu.Content = new EcranSociete();
        }

        private void cmd_transaction(object sender, RoutedEventArgs e)
        {

        }

        private void cmd_quitter(object sender, RoutedEventArgs e)
        {

        }

    }
}
