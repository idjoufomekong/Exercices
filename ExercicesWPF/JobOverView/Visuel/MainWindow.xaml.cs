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
using JobOverView.Visuel;

namespace JobOverView
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WLogiciel _wLogiciel; 
        public MainWindow()
        {
            InitializeComponent();
            menuLogiciel.Click += MenuLogiciel_Click;
        }

        private void MenuLogiciel_Click(object sender, RoutedEventArgs e)
        {
            //if (_wLogiciel == null)
            //{
               _wLogiciel = new WLogiciel();
            //}
            _wLogiciel.Show();
        }
    }
}
