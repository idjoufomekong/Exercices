namespace ADO
{
    partial class FormProduits
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
            this.btAjoutProduit = new System.Windows.Forms.Button();
            this.btSuprProduit = new System.Windows.Forms.Button();
            this.dgvAfichProduit = new System.Windows.Forms.DataGridView();
            this.btEnrListProduits = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfichProduit)).BeginInit();
            this.SuspendLayout();
            // 
            // btAjoutProduit
            // 
            this.btAjoutProduit.Location = new System.Drawing.Point(13, 13);
            this.btAjoutProduit.Name = "btAjoutProduit";
            this.btAjoutProduit.Size = new System.Drawing.Size(40, 23);
            this.btAjoutProduit.TabIndex = 0;
            this.btAjoutProduit.Text = "+";
            this.btAjoutProduit.UseVisualStyleBackColor = true;
            // 
            // btSuprProduit
            // 
            this.btSuprProduit.Location = new System.Drawing.Point(59, 13);
            this.btSuprProduit.Name = "btSuprProduit";
            this.btSuprProduit.Size = new System.Drawing.Size(40, 23);
            this.btSuprProduit.TabIndex = 0;
            this.btSuprProduit.Text = "-";
            this.btSuprProduit.UseVisualStyleBackColor = true;
            // 
            // dgvAfichProduit
            // 
            this.dgvAfichProduit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAfichProduit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAfichProduit.Location = new System.Drawing.Point(13, 56);
            this.dgvAfichProduit.Name = "dgvAfichProduit";
            this.dgvAfichProduit.Size = new System.Drawing.Size(597, 294);
            this.dgvAfichProduit.TabIndex = 1;
            // 
            // btEnrListProduits
            // 
            this.btEnrListProduits.Location = new System.Drawing.Point(120, 6);
            this.btEnrListProduits.Name = "btEnrListProduits";
            this.btEnrListProduits.Size = new System.Drawing.Size(102, 37);
            this.btEnrListProduits.TabIndex = 2;
            this.btEnrListProduits.Text = "Enregistrer";
            this.btEnrListProduits.UseVisualStyleBackColor = true;
            // 
            // FormProduits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 362);
            this.Controls.Add(this.btEnrListProduits);
            this.Controls.Add(this.dgvAfichProduit);
            this.Controls.Add(this.btSuprProduit);
            this.Controls.Add(this.btAjoutProduit);
            this.Name = "FormProduits";
            this.Text = "Produit";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfichProduit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btAjoutProduit;
        private System.Windows.Forms.Button btSuprProduit;
        private System.Windows.Forms.DataGridView dgvAfichProduit;
        private System.Windows.Forms.Button btEnrListProduits;
    }
}