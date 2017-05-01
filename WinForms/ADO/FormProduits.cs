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
        //public BindingList<Produit> ListeProduits { get; set; }
        //Une variable privée est mieux indiquée car on ne veut pas l'exposer à l'extérieur
        private BindingList<Produit> _listeProduits;
        private BindingList<Produit> _produitsAjoutés;
        private BindingList<Produit> _produitsSupprimés;
        public FormProduits()
        {
            InitializeComponent();
            _listeProduits = new BindingList<Produit>();
            _produitsAjoutés = new BindingList<Produit>();
            _produitsSupprimés = new BindingList<Produit>();

            btAjoutProduit.Click += (object sender, EventArgs e) =>
            {
                using(FormSaisieProduit formSaisie = new FormSaisieProduit())
                {
                    DialogResult result = formSaisie.ShowDialog();
                    if(result == DialogResult.OK)
                    {
                        try//Faire çà dans la DAL d'abord, puis renvoyer l'exception par un throx new exception
                        //On peut se créer une classe d'exception d'erreurs métier qui traduiront les erreurs techniques
                        {
                            //Ajout ligne par ligne
                            //DAL.AjouterProduitBD(formSaisie.ProduitSaisi);
                            //formSaisie.ProduitSaisi.IdProduit = DAL.GetIdProduit(formSaisie.ProduitSaisi);
                            //_listeProduits.Add(formSaisie.ProduitSaisi);

                            //Ajout de masse
                            _produitsAjoutés.Add(formSaisie.ProduitSaisi);
                            _listeProduits.Add(formSaisie.ProduitSaisi);
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 547)
                            {
                                DialogResult msg = MessageBox.Show("Attention, le fournisseur entré n'existe pas!", 
                                "Erreur", MessageBoxButtons.OK);
                            }
                            else
                                throw;
                        }
                    }
                   
                }
            };

            btSuprProduit.Click += (object sender, EventArgs e) =>
            {
                Produit prod = (Produit) dgvAfichProduit.CurrentRow.DataBoundItem;
                //Suppression produit ligne par ligne
                //_listeProduits.Remove(prod);//par souci d'économie, il vaut mieux passer en paramètre l'id du produit

                //Suppression de masse
                if (_produitsAjoutés.Contains(prod))
                {
                    _produitsAjoutés.Remove(prod);
                    _listeProduits.Remove(prod);
                }
                else
                {
                    _produitsSupprimés.Add(prod);
                    _listeProduits.Remove(prod);

                }


                try
                {
                    //Suppression produit ligne par ligne
                    //DAL.RemoveProduitBD(prod);

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {

                        DialogResult msg= MessageBox.Show("Attention, ce produit est reférencé dans une commande!",
                            "Erreur", MessageBoxButtons.OK);
                    }
                    else
                        throw;
                }
            };

            btEnrListProduits.Click += BtEnrListProduits_Click;

        }

        //Enregistrement ou suppression de masse des produits
        //TODO: Les produits ajoutés puis supprimés ne doivent pas être enregistrés dans la base
        private void BtEnrListProduits_Click(object sender, EventArgs e)
        {
            //Gérer les produits ajoutés puis supprimés immédiatement
            
            if (_produitsAjoutés.Count != 0)
            {
                DAL.AjoutMasseProduitsBD(_produitsAjoutés);
            }
            if(_produitsSupprimés.Count != 0)
            {
                List<int> listId = new List<int>();
                foreach (var b in _produitsSupprimés)
                    listId.Add(b.IdProduit);
                DAL.RemoveMasseProduitBD(listId);
            }
                
        }

        protected override void OnLoad(EventArgs e)
        {
            _listeProduits = DAL.GetListeProduits();
            dgvAfichProduit.DataSource = _listeProduits ;
            base.OnLoad(e);
        }
    }
}
