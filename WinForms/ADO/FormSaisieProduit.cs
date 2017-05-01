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
    public partial class FormSaisieProduit : Form
    {
        public Produit ProduitSaisi { get; private set; }
        public FormSaisieProduit()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                ProduitSaisi = new Produit();
                ProduitSaisi.Nom = tbNom.Text;
                ProduitSaisi.Categorie = int.Parse(mtbCategorie.Text);

               // if (!string.IsNullOrEmpty(tbUnitQuantity.Text))
                    ProduitSaisi.QuantityPerUnit = tbUnitQuantity.Text;

                decimal prix;
                if (decimal.TryParse(mtbUnitPrice.Text, out prix))
                    ProduitSaisi.UnitPrice = prix;
                else
                    ProduitSaisi.UnitPrice = null;

                int unit;
                if (int.TryParse(mtbUnitInStock.Text,out unit))
                    ProduitSaisi.UnitsInStock = unit;
                else
                    ProduitSaisi.UnitsInStock = null;

                ProduitSaisi.Fournisseur = int.Parse(mtbFournisseur.Text);
            }


            base.OnClosing(e);
        }
    }

    //TODO: Aligner labels à droite
}
