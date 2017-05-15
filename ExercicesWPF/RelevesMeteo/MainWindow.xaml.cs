using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace RelevesMeteo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DALMeteo _meteo;
        public MainWindow()
        {
            InitializeComponent();
           // Thread.CurrentThread.CurrentCulture = new CultureInfo("FR-FR");
            _meteo = new DALMeteo();

            btChargerFichier.Click += SelectFichierChargerDonnees;
            cbVue.SelectionChanged += ChoisirVue;
        }

        private void ChoisirVue(object sender, SelectionChangedEventArgs e)
        {
            if (cbVue.SelectedIndex == 0)//Sélection du 1er élément de la liste : Vignettes
            {
                gStats.Visibility = System.Windows.Visibility.Visible;
                lbMeteo.ItemTemplate = (DataTemplate)Resources["dtListMeteo"];
            }
            else
            {
                lbMeteo.ItemTemplate = (DataTemplate)Resources["dtListGroupee"];
                gStats.Visibility = System.Windows.Visibility.Hidden;
                //ccDetail.Visibility = Visibility.Visible;
            }
        }

        private void SelectFichierChargerDonnees(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog obj = new Microsoft.Win32.OpenFileDialog();
            obj.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            obj.ShowDialog();
            try
            {
            _meteo.ChargerDonnées(obj.FileName);
            tbChoisirFichier.Text = obj.FileName;
                lbMeteo.DataContext = _meteo.Data;
                DataContext = _meteo.Stats;
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message+ "\n"+"Veuillez choisir un fichier", "Erreur", MessageBoxButton.OK);
            }
            
        }
    }
}
