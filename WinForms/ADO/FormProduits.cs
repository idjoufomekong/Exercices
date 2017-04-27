using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO
{
    public partial class FormProduits : Form
    {
        public BindingList<Produit> ListeProduits { get; set; }
        public FormProduits()
        {
            InitializeComponent();
            ListeProduits = new BindingList<Produit>();
            btAjoutProduit.Click += (object sender, EventArgs e) =>
            {
                using(FormSaisieProduit formSaisie = new FormSaisieProduit())
                {
                    DialogResult result = formSaisie.ShowDialog();
                    if(result == DialogResult.OK)
                    {
                        DAL.AjouterProduitBD(formSaisie.ProduitSaisi);
                        formSaisie.ProduitSaisi.IdProduit = DAL.GetIdProduit(formSaisie.ProduitSaisi);
                        ListeProduits.Add(formSaisie.ProduitSaisi);
                    }
                   
                }
            };

            btSuprProduit.Click += (object sender, EventArgs e) =>
            {
                Produit prod = (Produit) dgvAfichProduit.CurrentRow.DataBoundItem;
                ListeProduits.Remove(prod);
                try
                {
                    DAL.RemoveProduitBD(prod);

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                        var msg= MessageBox.Show("Attention, ce produit est reférencé dans une commande!","Erreur", MessageBoxButtons.Yes);
                    else
                        throw;
                }
            };

        }

        protected override void OnLoad(EventArgs e)
        {
            ListeProduits = DAL.GetListeProduits();
            dgvAfichProduit.DataSource = ListeProduits ;
            base.OnLoad(e);
        }
    }
}
