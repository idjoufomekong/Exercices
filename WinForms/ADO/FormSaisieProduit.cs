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
        public Produit ProduitSaisi { get; set; }
        public FormSaisieProduit()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(DialogResult == DialogResult.OK)
            {
                ProduitSaisi = new Produit();
                ProduitSaisi.Nom = tbNom.Text;
                ProduitSaisi.Categorie = int.Parse(mtbCategorie.Text);
                ProduitSaisi.QuantityPerUnit = tbUnitQuantity.Text;
                ProduitSaisi.UnitPrice = decimal.Parse(mtbUnitPrice.Text);
                ProduitSaisi.UnitsInStock = int.Parse(mtbUnitInStock.Text);
                ProduitSaisi.Fournisseur = int.Parse(mtbFournisseur.Text);
            }
                        
                  
            base.OnClosing(e);
        }
    }

    //TODO: Aligner labels à droite
}
