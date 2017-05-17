using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private ICollectionView _view;
        public MainWindow()
        {
            InitializeComponent();
            Language = System.Windows.Markup.XmlLanguage.GetLanguage(System.Threading.Thread.CurrentThread.CurrentCulture.Name);
            _meteo = new DALMeteo();

            btChargerFichier.Click += SelectFichierChargerDonnees;
            cbVue.SelectionChanged += ChoisirVue;

            ccDetail.Visibility = Visibility.Hidden;

            

        }

        private void ChoisirVue(object sender, SelectionChangedEventArgs e)
        {
            if (cbVue.SelectedIndex == 0)//Sélection du 1er élément de la liste : Vignettes
            {
                _view.SortDescriptions.Clear();
                _view.GroupDescriptions.Clear();
                gStats.Visibility = System.Windows.Visibility.Visible;
                ccDetail.Visibility = Visibility.Hidden;
                lbMeteo.ItemTemplate = (DataTemplate)Resources["dtListMeteo"];
            }
            else
            {
                _view = CollectionViewSource.GetDefaultView(_meteo.Data);
                _view.SortDescriptions.Add(new SortDescription("Année", ListSortDirection.Ascending));
                _view.SortDescriptions.Add(new SortDescription("Mois", ListSortDirection.Ascending));
                _view.GroupDescriptions.Add(new PropertyGroupDescription("Année"));
                lbMeteo.ItemTemplate = (DataTemplate)Resources["dtListGroupee"];
                gStats.Visibility = System.Windows.Visibility.Hidden;
                ccDetail.Visibility = Visibility.Visible;
            }
            //Au lieu des if
            //lbMeteo.ItemTemplate = (DataTemplate)Resources[cbVue.SelectedValue];
        }

        private void SelectFichierChargerDonnees(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog obj = new Microsoft.Win32.OpenFileDialog();
            obj.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;//Faire parent directory pour remonter d'un cran
            obj.ShowDialog();
            try
            {
            _meteo.ChargerDonnées(obj.FileName);
            tbChoisirFichier.Text = obj.FileName;
                lbMeteo.DataContext = _meteo.Data;
                DataContext = _meteo.Stats;
                ccDetail.DataContext = _meteo.Data;
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message+ "\n"+"", "Erreur", MessageBoxButton.OK);
            }
            
        }
    }
}
