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
    public partial class FormCommandes : Form
    {
        public FormCommandes()
        {
            InitializeComponent();
            btVoirCom.Click += (object sender, EventArgs e) =>
            {
                dgvListCom.DataSource = DAL.GetInfosCommandes(tbCodeClient.Text);
            };
            foreach (var a in DAL.GetListeClients())
                lbClient.Items.Add(a.Code + " - " + a.Nom);


            lbClient.SelectedValueChanged += (object sender, EventArgs e) =>
            {
                //dgvListCom.DataSource = DAL.GetInfosCommandes(lbClient.SelectedItem.ToString().Substring(0,5));
                dgvListCom.DataSource = DAL.GetInfosCommandes(lbClient.SelectedItem.ToString().Split(' ')[0]);


            };
        }
    }
}
