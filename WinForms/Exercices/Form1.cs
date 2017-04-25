using Explorateur_de_fichiers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercices
{
    public partial class Analyser : Form
    {
      
        public Analyser()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            InitializeComponent();
            chkNbFich.CheckStateChanged += ChkNbFich_CheckStateChanged;
            chkNbFichCs.CheckStateChanged += ChkNbFichCs_CheckStateChanged;
            chkFichLong.CheckStateChanged += ChkFichLong_CheckStateChanged;
            chkListFichProj.CheckStateChanged += ChkListFichProj_CheckStateChanged;
            btSelDos.Click += BtSelDos_Click;
            btAnalyser.Click += BtAnalyser_Click;
            
            //this.load += 
            this.FormClosing += Analyser_FormClosing;
        }

        private void BtAnalyser_Click(object sender, EventArgs e)
        {
            Analyseur ana = new Analyseur();
            ana.AnalyserFichier(tbDossier.Text);
            lblNbFich.Text = ana.NbFichiers.ToString();
            lblNbFichCs.Text = ana.NbFichiersCs.ToString();
            lblNLong.Text = ana.PlusLongFichier;

            foreach(var a in ana.ListeFichierprojet)
            {

                lvFichProj.Items.Add(a);

            }
        }

        private void Analyser_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Sauvegarder le répertoire et l'état des cases à cocher?",
        "Confirmer fermeture",MessageBoxButtons.YesNoCancel);
            //tester avec switch
            if(result == DialogResult.Yes)
            {
                Properties.Settings.Default.ckLFP = chkListFichProj.Checked;
                Properties.Settings.Default.ckLFP = chkFichLong.Checked;
                Properties.Settings.Default.ckLFP = chkNbFichCs.Checked;
                Properties.Settings.Default.ckLFP = chkNbFich.Checked;
                Properties.Settings.Default.TbChemin = tbDossier.Text;

                Properties.Settings.Default.Save();
            }
            if(result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void BtSelDos_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog expl = new FolderBrowserDialog();
            //if (expl.ShowDialog() == DialogResult.OK)
            //{
            //    tbDossier.Text = expl.SelectedPath;
            //}

            using (var fbd = new FolderBrowserDialog()) //Equivalent de try catch
            {
                DialogResult result = fbd.ShowDialog();
                if(result==DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tbDossier.Text = fbd.SelectedPath;
                    //Properties.Settings.Default.TbChemin = tbDossier.Text;
                    //Properties.Settings.Default.Save();
                    


                }
            }
        }

        private void ChkListFichProj_CheckStateChanged(object sender, EventArgs e)
        {
            pnlFicProj.Visible = chkListFichProj.Checked;
            lvFichProj.Visible = chkListFichProj.Checked;
            //Properties.Settings.Default.ckLFP = chkListFichProj.Checked;
            //Properties.Settings.Default.Save();
        }

        private void ChkFichLong_CheckStateChanged(object sender, EventArgs e)
        {
            lblNomLg.Visible = !lblNomLg.Visible;
            lblNLong.Visible = !lblNLong.Visible;
            //Properties.Settings.Default.ckLFP = chkFichLong.Checked;
            //Properties.Settings.Default.Save();
        }

        private void ChkNbFichCs_CheckStateChanged(object sender, EventArgs e)
        {
            lblNbFichCs.Visible = !lblNbFichCs.Visible;
            lblFichCs.Visible = !lblFichCs.Visible;
            //Properties.Settings.Default.ckLFP = chkNbFichCs.Checked;
            //Properties.Settings.Default.Save();
        }
    
        private void ChkNbFich_CheckStateChanged(object sender, EventArgs e)
        {
            lblNbFich.Visible = !lblNbFich.Visible;
            lblFich.Visible = !lblFich.Visible;
            Properties.Settings.Default.ckLFP = chkNbFich.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
