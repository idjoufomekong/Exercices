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
            //cbVue.SelectionChanged += ChoisirVue;
            //cbTrie.SelectionChanged += ChoisirVue;
            //cbSensTri.SelectionChanged += ChoisirVue;
            btFiltre.Click += Filtrer;

            ccDetail.Visibility = Visibility.Hidden;

            dpTri.AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent,
            new RoutedEventHandler(ChoisirVue));



        }

        private void Filtrer(object sender, RoutedEventArgs e)
        {
            // Applique le filtre à la liste
            CollectionViewSource.GetDefaultView(_meteo.Data).Filter = FiltrerSurTMin;
        }

        // Filtre
        private bool FiltrerSurTMin(object o)
        {
            double seuil;
            if (double.TryParse(tbFiltre.Text, out seuil))
                return ((DonnéesMois)o).TMin >= seuil;

            return true;
        }


        private void ChoisirVue(object sender, RoutedEventArgs e)//SelectionChangedEventArgs e)
        {
            _view = CollectionViewSource.GetDefaultView(_meteo.Data);
            if (cbVue.SelectedIndex == 0)//Sélection du 1er élément de la liste : Vignettes
            {
                _view.SortDescriptions.Clear();
                _view.GroupDescriptions.Clear();
                gStats.Visibility = System.Windows.Visibility.Visible;
                ccDetail.Visibility = Visibility.Hidden;
                lbMeteo.ItemTemplate = (DataTemplate)Resources["dtListMeteo"];
                TrierListe();
            }
            else
            {
                _view.SortDescriptions.Clear();
                _view.GroupDescriptions.Clear();
                _view.SortDescriptions.Add(new SortDescription("Année", ListSortDirection.Ascending));
                _view.SortDescriptions.Add(new SortDescription("Mois", ListSortDirection.Ascending));
                _view.GroupDescriptions.Add(new PropertyGroupDescription("Année"));
                lbMeteo.ItemTemplate = (DataTemplate)Resources["dtListGroupee"];
                gStats.Visibility = System.Windows.Visibility.Hidden;
                ccDetail.Visibility = Visibility.Visible;
                TrierListe();
            }
            //Au lieu des if
            //lbMeteo.ItemTemplate = (DataTemplate)Resources[cbVue.SelectedValue];
        }

        private void TrierListe()//object sender, SelectionChangedEventArgs e)
        {
            int res = cbTrie.SelectedIndex;
            var sens = cbSensTri.SelectedIndex == 0 ? ListSortDirection.Ascending : ListSortDirection.Descending;
            _view.SortDescriptions.Clear();

            if (res == 0)
            {
                _view.SortDescriptions.Add(new SortDescription("Année", sens));
                _view.SortDescriptions.Add(new SortDescription("Mois", sens));
            }
            else if (res == 1)
            {
                _view.SortDescriptions.Add(new SortDescription("TMin", sens));
            }
            else if (res == 2)
            {
                _view.SortDescriptions.Add(new SortDescription("TMax", sens));
            }
            else if (res == 3)
            {
                _view.SortDescriptions.Add(new SortDescription("Précipitations", sens));
            }
            else if (res == 4)
            {
                _view.SortDescriptions.Add(new SortDescription("Ensoleillement", sens));
            }
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

                MessageBox.Show(exp.Message + "\n" + "", "Erreur", MessageBoxButton.OK);
            }

        }
    }
}
