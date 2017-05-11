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
    /// Interaction logic for UCEmployes.xaml
    /// </summary>
    public partial class UCEmployes : UserControl
    {
        private List<Employe> _listEmpl;
        public UCEmployes()
        {
            InitializeComponent();

            lbEmp.SelectionChanged += LbEmp_SelectionChanged;

            _listEmpl = DAL.GetEmployees();
            lbEmp.ItemsSource = _listEmpl;
                
                lbEmp.DisplayMemberPath = "NomComplet";
                //lbEmp.SelectedValuePath = "Id";
        }

        private void LbEmp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int id = (int)lbEmp.SelectedValue;
            //            var p = _listEmpl.Where(x => x.Id == id).FirstOrDefault();
            var p = (Employe) lbEmp.SelectedItem;
            tbId.Text ="Id: "+p.Id.ToString();
            tbNom.Text = "Nom: "+p.Nom;
            tbPrenom.Text = "Prénom: "+ p.Prenom;
        }
    }
}
