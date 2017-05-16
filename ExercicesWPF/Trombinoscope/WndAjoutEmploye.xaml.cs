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
using System.Windows.Shapes;

namespace Trombinoscope
{
    /// <summary>
    /// Interaction logic for WndAjoutEmploye.xaml
    /// </summary>
    public partial class WndAjoutEmploye : Window
    {
        public WndAjoutEmploye(Employe employe)
        {
            InitializeComponent();

            btOK.Click += BtOK_Click;
            DataContext = employe;
        }

        private void BtOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
