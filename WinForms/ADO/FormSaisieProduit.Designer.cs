namespace ADO
{
    partial class FormSaisieProduit
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
            this.lblNom = new System.Windows.Forms.Label();
            this.lblCategorie = new System.Windows.Forms.Label();
            this.lblUnitQuantity = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblUnitInstock = new System.Windows.Forms.Label();
            this.lblFournisseur = new System.Windows.Forms.Label();
            this.btEnrProduit = new System.Windows.Forms.Button();
            this.btAnnulEnrProduit = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.mtbUnitInStock = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.mtbCategorie = new System.Windows.Forms.MaskedTextBox();
            this.mtbFournisseur = new System.Windows.Forms.MaskedTextBox();
            this.mtbUnitPrice = new System.Windows.Forms.MaskedTextBox();
            this.tbUnitQuantity = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(35, 35);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(29, 13);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom";
            // 
            // lblCategorie
            // 
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Location = new System.Drawing.Point(35, 62);
            this.lblCategorie.Name = "lblCategorie";
            this.lblCategorie.Size = new System.Drawing.Size(52, 13);
            this.lblCategorie.TabIndex = 0;
            this.lblCategorie.Text = "Catégorie";
            // 
            // lblUnitQuantity
            // 
            this.lblUnitQuantity.AutoSize = true;
            this.lblUnitQuantity.Location = new System.Drawing.Point(35, 88);
            this.lblUnitQuantity.Name = "lblUnitQuantity";
            this.lblUnitQuantity.Size = new System.Drawing.Size(84, 13);
            this.lblUnitQuantity.TabIndex = 0;
            this.lblUnitQuantity.Text = "Quantité unitaire";
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(35, 114);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(61, 13);
            this.lblUnitPrice.TabIndex = 0;
            this.lblUnitPrice.Text = "Prix unitaire";
            // 
            // lblUnitInstock
            // 
            this.lblUnitInstock.AutoSize = true;
            this.lblUnitInstock.Location = new System.Drawing.Point(35, 139);
            this.lblUnitInstock.Name = "lblUnitInstock";
            this.lblUnitInstock.Size = new System.Drawing.Size(81, 13);
            this.lblUnitInstock.TabIndex = 0;
            this.lblUnitInstock.Text = "Unités en stock";
            // 
            // lblFournisseur
            // 
            this.lblFournisseur.AutoSize = true;
            this.lblFournisseur.Location = new System.Drawing.Point(35, 165);
            this.lblFournisseur.Name = "lblFournisseur";
            this.lblFournisseur.Size = new System.Drawing.Size(61, 13);
            this.lblFournisseur.TabIndex = 0;
            this.lblFournisseur.Text = "Fournisseur";
            // 
            // btEnrProduit
            // 
            this.btEnrProduit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btEnrProduit.Location = new System.Drawing.Point(195, 208);
            this.btEnrProduit.Name = "btEnrProduit";
            this.btEnrProduit.Size = new System.Drawing.Size(75, 23);
            this.btEnrProduit.TabIndex = 1;
            this.btEnrProduit.Text = "OK";
            this.btEnrProduit.UseVisualStyleBackColor = true;
            // 
            // btAnnulEnrProduit
            // 
            this.btAnnulEnrProduit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btAnnulEnrProduit.Location = new System.Drawing.Point(276, 208);
            this.btAnnulEnrProduit.Name = "btAnnulEnrProduit";
            this.btAnnulEnrProduit.Size = new System.Drawing.Size(75, 23);
            this.btAnnulEnrProduit.TabIndex = 1;
            this.btAnnulEnrProduit.Text = "Annuler";
            this.btAnnulEnrProduit.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(147, 62);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(123, 20);
            this.maskedTextBox1.TabIndex = 4;
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(147, 35);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(204, 20);
            this.tbNom.TabIndex = 2;
            // 
            // mtbUnitInStock
            // 
            this.mtbUnitInStock.Location = new System.Drawing.Point(147, 136);
            this.mtbUnitInStock.Mask = "99999";
            this.mtbUnitInStock.Name = "mtbUnitInStock";
            this.mtbUnitInStock.Size = new System.Drawing.Size(123, 20);
            this.mtbUnitInStock.TabIndex = 4;
            this.mtbUnitInStock.ValidatingType = typeof(int);
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.Location = new System.Drawing.Point(147, 165);
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.Size = new System.Drawing.Size(123, 20);
            this.maskedTextBox3.TabIndex = 4;
            // 
            // mtbCategorie
            // 
            this.mtbCategorie.Location = new System.Drawing.Point(147, 62);
            this.mtbCategorie.Mask = "99999";
            this.mtbCategorie.Name = "mtbCategorie";
            this.mtbCategorie.Size = new System.Drawing.Size(123, 20);
            this.mtbCategorie.TabIndex = 4;
            this.mtbCategorie.ValidatingType = typeof(int);
            // 
            // mtbFournisseur
            // 
            this.mtbFournisseur.Location = new System.Drawing.Point(147, 165);
            this.mtbFournisseur.Mask = "99999";
            this.mtbFournisseur.Name = "mtbFournisseur";
            this.mtbFournisseur.Size = new System.Drawing.Size(123, 20);
            this.mtbFournisseur.TabIndex = 4;
            this.mtbFournisseur.ValidatingType = typeof(int);
            // 
            // mtbUnitPrice
            // 
            this.mtbUnitPrice.Location = new System.Drawing.Point(147, 111);
            this.mtbUnitPrice.Mask = "0000.00";
            this.mtbUnitPrice.Name = "mtbUnitPrice";
            this.mtbUnitPrice.Size = new System.Drawing.Size(123, 20);
            this.mtbUnitPrice.TabIndex = 4;
            // 
            // tbUnitQuantity
            // 
            this.tbUnitQuantity.Location = new System.Drawing.Point(147, 89);
            this.tbUnitQuantity.Name = "tbUnitQuantity";
            this.tbUnitQuantity.Size = new System.Drawing.Size(123, 20);
            this.tbUnitQuantity.TabIndex = 5;
            // 
            // FormSaisieProduit
            // 
            this.AcceptButton = this.btEnrProduit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btAnnulEnrProduit;
            this.ClientSize = new System.Drawing.Size(389, 257);
            this.ControlBox = false;
            this.Controls.Add(this.tbUnitQuantity);
            this.Controls.Add(this.mtbFournisseur);
            this.Controls.Add(this.maskedTextBox3);
            this.Controls.Add(this.mtbUnitPrice);
            this.Controls.Add(this.mtbCategorie);
            this.Controls.Add(this.mtbUnitInStock);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.btAnnulEnrProduit);
            this.Controls.Add(this.btEnrProduit);
            this.Controls.Add(this.lblFournisseur);
            this.Controls.Add(this.lblUnitInstock);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.lblUnitQuantity);
            this.Controls.Add(this.lblCategorie);
            this.Controls.Add(this.lblNom);
            this.Name = "FormSaisieProduit";
            this.Text = "Saisie d\'un produit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblCategorie;
        private System.Windows.Forms.Label lblUnitQuantity;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label lblUnitInstock;
        private System.Windows.Forms.Label lblFournisseur;
        private System.Windows.Forms.Button btEnrProduit;
        private System.Windows.Forms.Button btAnnulEnrProduit;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.MaskedTextBox mtbUnitInStock;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
        private System.Windows.Forms.MaskedTextBox mtbCategorie;
        private System.Windows.Forms.MaskedTextBox mtbFournisseur;
        private System.Windows.Forms.MaskedTextBox mtbUnitPrice;
        private System.Windows.Forms.TextBox tbUnitQuantity;
    }
}