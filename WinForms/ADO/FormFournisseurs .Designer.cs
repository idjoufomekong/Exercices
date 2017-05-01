namespace ADO
{
    partial class FormFournisseurs
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
            this.dgvFournisseur = new System.Windows.Forms.DataGridView();
            this.cbPaysFournisseur = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNbPdtFrsPaysSel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFournisseur)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFournisseur
            // 
            this.dgvFournisseur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFournisseur.Location = new System.Drawing.Point(45, 58);
            this.dgvFournisseur.Name = "dgvFournisseur";
            this.dgvFournisseur.Size = new System.Drawing.Size(759, 363);
            this.dgvFournisseur.TabIndex = 0;
            // 
            // cbPaysFournisseur
            // 
            this.cbPaysFournisseur.FormattingEnabled = true;
            this.cbPaysFournisseur.Items.AddRange(new object[] {
            "\" \""});
            this.cbPaysFournisseur.Location = new System.Drawing.Point(45, 12);
            this.cbPaysFournisseur.Name = "cbPaysFournisseur";
            this.cbPaysFournisseur.Size = new System.Drawing.Size(121, 21);
            this.cbPaysFournisseur.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de produits fournis par ces fournisseurs";
            // 
            // tbNbPdtFrsPaysSel
            // 
            this.tbNbPdtFrsPaysSel.Location = new System.Drawing.Point(532, 12);
            this.tbNbPdtFrsPaysSel.Name = "tbNbPdtFrsPaysSel";
            this.tbNbPdtFrsPaysSel.Size = new System.Drawing.Size(26, 20);
            this.tbNbPdtFrsPaysSel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(565, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "produits";
            // 
            // FormFournisseurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 556);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNbPdtFrsPaysSel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPaysFournisseur);
            this.Controls.Add(this.dgvFournisseur);
            this.Name = "FormFournisseurs";
            this.Text = "FormFournisseurs";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFournisseur)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFournisseur;
        private System.Windows.Forms.ComboBox cbPaysFournisseur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNbPdtFrsPaysSel;
        private System.Windows.Forms.Label label2;
    }
}