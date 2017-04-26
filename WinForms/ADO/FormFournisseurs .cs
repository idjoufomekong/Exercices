using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO
{
    public partial class FormFournisseurs : Form
    {
        public FormFournisseurs()
        {
            InitializeComponent();

            cbPaysFournisseur.DropDownStyle = ComboBoxStyle.DropDownList;
            //Afficher liste de pays
            cbPaysFournisseur.DataSource = DAL.GetPaysFournisseurs();
            //Afficher liste de fournisseurs du pays sélectionné
            cbPaysFournisseur.SelectedValueChanged += (object sender, EventArgs e) =>
            {
                dgvFournisseur.DataSource = DAL.GetFournisseurs(cbPaysFournisseur.SelectedValue.ToString());
                tbNbPdtFrsPaysSel.Text = DAL.GetNbProduitParPays(cbPaysFournisseur.SelectedValue.ToString()).ToString();
            };

        }
    }
}
