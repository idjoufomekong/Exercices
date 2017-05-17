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

namespace Trombinoscope
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private UCTrombi _ucTrombi;
        //private UCEmployes _ucEmploye;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new VMMain();
            //menuTrombi.Click += MenuTrombi_Click;
            //menuEmpl.Click += MenuEmpl_Click;
        }

        //private void MenuEmpl_Click(object sender, RoutedEventArgs e)
        //{
        //    if (_ucEmploye == null)
        //    {
        //        _ucEmploye = new Trombinoscope.UCEmployes();
        //    }
        //        ccContent.Content = _ucEmploye;
        }

        //private void MenuTrombi_Click(object sender, RoutedEventArgs e)
        //{
        //    if (_ucTrombi == null)
        //    {
        //        _ucTrombi = new UCTrombi();
        //    }
        //        ccContent.Content = _ucTrombi;
        //}
    }

