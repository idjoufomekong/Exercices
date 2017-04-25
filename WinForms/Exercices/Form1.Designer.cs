namespace Exercices
{
    partial class Analyser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analyser));
            this.label1 = new System.Windows.Forms.Label();
            this.tbDossier = new System.Windows.Forms.TextBox();
            this.btSelDos = new System.Windows.Forms.Button();
            this.btAnalyser = new System.Windows.Forms.Button();
            this.lblNLong = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkListFichProj = new System.Windows.Forms.CheckBox();
            this.chkFichLong = new System.Windows.Forms.CheckBox();
            this.chkNbFichCs = new System.Windows.Forms.CheckBox();
            this.chkNbFich = new System.Windows.Forms.CheckBox();
            this.pnlFicProj = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lvFichProj = new System.Windows.Forms.ListView();
            this.lblNbFich = new System.Windows.Forms.Label();
            this.lblNbFichCs = new System.Windows.Forms.Label();
            this.lblFich = new System.Windows.Forms.Label();
            this.lblFichCs = new System.Windows.Forms.Label();
            this.lblNomLg = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.pnlFicProj.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tbDossier
            // 
            this.tbDossier.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Exercices.Properties.Settings.Default, "TbChemin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.tbDossier, "tbDossier");
            this.tbDossier.Name = "tbDossier";
            this.tbDossier.Text = global::Exercices.Properties.Settings.Default.TbChemin;
            // 
            // btSelDos
            // 
            resources.ApplyResources(this.btSelDos, "btSelDos");
            this.btSelDos.Name = "btSelDos";
            this.btSelDos.UseVisualStyleBackColor = true;
            // 
            // btAnalyser
            // 
            resources.ApplyResources(this.btAnalyser, "btAnalyser");
            this.btAnalyser.Name = "btAnalyser";
            this.btAnalyser.UseVisualStyleBackColor = true;
            // 
            // lblNLong
            // 
            resources.ApplyResources(this.lblNLong, "lblNLong");
            this.lblNLong.Name = "lblNLong";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkListFichProj);
            this.groupBox1.Controls.Add(this.chkFichLong);
            this.groupBox1.Controls.Add(this.chkNbFichCs);
            this.groupBox1.Controls.Add(this.chkNbFich);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chkListFichProj
            // 
            resources.ApplyResources(this.chkListFichProj, "chkListFichProj");
            this.chkListFichProj.Checked = global::Exercices.Properties.Settings.Default.ckLFP;
            this.chkListFichProj.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkListFichProj.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Exercices.Properties.Settings.Default, "ckLFP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkListFichProj.Name = "chkListFichProj";
            this.chkListFichProj.UseVisualStyleBackColor = true;
            // 
            // chkFichLong
            // 
            resources.ApplyResources(this.chkFichLong, "chkFichLong");
            this.chkFichLong.Checked = global::Exercices.Properties.Settings.Default.ckNFL;
            this.chkFichLong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFichLong.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Exercices.Properties.Settings.Default, "ckNFL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkFichLong.Name = "chkFichLong";
            this.chkFichLong.UseVisualStyleBackColor = true;
            // 
            // chkNbFichCs
            // 
            resources.ApplyResources(this.chkNbFichCs, "chkNbFichCs");
            this.chkNbFichCs.Checked = global::Exercices.Properties.Settings.Default.ckNFCs;
            this.chkNbFichCs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNbFichCs.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Exercices.Properties.Settings.Default, "ckNFCs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkNbFichCs.Name = "chkNbFichCs";
            this.chkNbFichCs.UseVisualStyleBackColor = true;
            // 
            // chkNbFich
            // 
            resources.ApplyResources(this.chkNbFich, "chkNbFich");
            this.chkNbFich.Checked = global::Exercices.Properties.Settings.Default.ckNbFT;
            this.chkNbFich.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNbFich.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Exercices.Properties.Settings.Default, "ckNbFT", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkNbFich.Name = "chkNbFich";
            this.chkNbFich.UseVisualStyleBackColor = true;
            // 
            // pnlFicProj
            // 
            this.pnlFicProj.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFicProj.Controls.Add(this.label2);
            resources.ApplyResources(this.pnlFicProj, "pnlFicProj");
            this.pnlFicProj.Name = "pnlFicProj";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lvFichProj
            // 
            resources.ApplyResources(this.lvFichProj, "lvFichProj");
            this.lvFichProj.Name = "lvFichProj";
            this.lvFichProj.UseCompatibleStateImageBehavior = false;
            // 
            // lblNbFich
            // 
            resources.ApplyResources(this.lblNbFich, "lblNbFich");
            this.lblNbFich.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblNbFich.Name = "lblNbFich";
            // 
            // lblNbFichCs
            // 
            resources.ApplyResources(this.lblNbFichCs, "lblNbFichCs");
            this.lblNbFichCs.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblNbFichCs.Name = "lblNbFichCs";
            // 
            // lblFich
            // 
            resources.ApplyResources(this.lblFich, "lblFich");
            this.lblFich.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblFich.Name = "lblFich";
            // 
            // lblFichCs
            // 
            resources.ApplyResources(this.lblFichCs, "lblFichCs");
            this.lblFichCs.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblFichCs.Name = "lblFichCs";
            // 
            // lblNomLg
            // 
            resources.ApplyResources(this.lblNomLg, "lblNomLg");
            this.lblNomLg.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblNomLg.Name = "lblNomLg";
            // 
            // Analyser
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.lblNomLg);
            this.Controls.Add(this.lblFichCs);
            this.Controls.Add(this.lblFich);
            this.Controls.Add(this.lblNbFichCs);
            this.Controls.Add(this.lblNbFich);
            this.Controls.Add(this.lvFichProj);
            this.Controls.Add(this.pnlFicProj);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblNLong);
            this.Controls.Add(this.btAnalyser);
            this.Controls.Add(this.btSelDos);
            this.Controls.Add(this.tbDossier);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Analyser";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlFicProj.ResumeLayout(false);
            this.pnlFicProj.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDossier;
        private System.Windows.Forms.Button btSelDos;
        private System.Windows.Forms.Button btAnalyser;
        private System.Windows.Forms.CheckBox chkNbFich;
        private System.Windows.Forms.CheckBox chkNbFichCs;
        private System.Windows.Forms.Label lblNLong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkListFichProj;
        private System.Windows.Forms.CheckBox chkFichLong;
        private System.Windows.Forms.Panel pnlFicProj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvFichProj;
        private System.Windows.Forms.Label lblNbFich;
        private System.Windows.Forms.Label lblNbFichCs;
        private System.Windows.Forms.Label lblFich;
        private System.Windows.Forms.Label lblFichCs;
        private System.Windows.Forms.Label lblNomLg;
    }
}

