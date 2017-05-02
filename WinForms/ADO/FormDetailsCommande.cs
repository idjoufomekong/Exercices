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
    public partial class FormDetailsCommande : Form
    {
        private List<Commande> ListCommEtDetails;
        public FormDetailsCommande()
        {
            InitializeComponent();

            ListCommEtDetails = new List<Commande>();
            //Il vaut mieux utiliser l'évènement selected changevalue ou cellClick
            //dgvCommandes.Click += DgvCommandes_Click;
            //dgvCommandes.CellClick += DgvCommandes_CellClick;
            dgvCommandes.SelectionChanged += DgvCommandes_SelectionChanged;
            btOK.Click += BtOK_Click;
        }


        protected override void OnLoad(EventArgs e)
        {
            ListCommEtDetails = DAL.GetListeCommandes();
            dgvCommandes.DataSource = ListCommEtDetails;
            //dgvCommandes.Columns["ListeDetails"].Visible = false; PARCE QUE la dgv n'affiche pas les listes
            base.OnLoad(e);
        }

        private void DgvCommandes_Click(object sender, EventArgs e)
        {
            var commande = (Commande)dgvCommandes.CurrentRow.DataBoundItem;
            int idCommande = commande.IdCommande;
            List<DetailsCommande> detail = new List<DetailsCommande>();
            //Une requête Linq renvoie toujours une liste d'objets
            detail = ListCommEtDetails.Where(x => x.IdCommande == idCommande).Select(x => x.ListeDetails).First();
            dgvDetCommandes.DataSource = detail;     
        }
        private void DgvCommandes_SelectionChanged(object sender, EventArgs e)
        {
            var commande = (Commande)dgvCommandes.CurrentRow.DataBoundItem;
            int idCommande = commande.IdCommande;
            List<DetailsCommande> detail = new List<DetailsCommande>();
            //Une requête Linq renvoie toujours une liste d'objets
            detail = ListCommEtDetails.Where(x => x.IdCommande == idCommande).Select(x => x.ListeDetails).First();
            dgvDetCommandes.DataSource = detail;
        }
        private void DgvCommandes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var commande = (Commande)dgvCommandes.CurrentRow.DataBoundItem;
            int idCommande = commande.IdCommande;
            List<DetailsCommande> detail = new List<DetailsCommande>();
            //Une requête Linq renvoie toujours une liste d'objets
            detail = ListCommEtDetails.Where(x => x.IdCommande == idCommande).Select(x => x.ListeDetails).First();
            dgvDetCommandes.DataSource = detail;
        }
        private void BtOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbIdClient.Text))
            {
                var p = MessageBox.Show("Veuillez entrer un Id Client", "Attention!", MessageBoxButtons.OK);
            }
            else
            {
                var p = ListCommEtDetails.Where(x => x.IdClient == tbIdClient.Text).ToList();
                dgvCommandes.DataSource = p;
            }
        }
    }
}
