namespace ADO
{
    partial class FormDetailsCommande
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCommandes = new System.Windows.Forms.DataGridView();
            this.dgvDetCommandes = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.tbIdClient = new System.Windows.Forms.TextBox();
            this.btOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetCommandes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Commandes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lignes de commandes";
            // 
            // dgvCommandes
            // 
            this.dgvCommandes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommandes.Location = new System.Drawing.Point(5, 60);
            this.dgvCommandes.Name = "dgvCommandes";
            this.dgvCommandes.Size = new System.Drawing.Size(172, 192);
            this.dgvCommandes.TabIndex = 2;
            // 
            // dgvDetCommandes
            // 
            this.dgvDetCommandes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetCommandes.Location = new System.Drawing.Point(230, 60);
            this.dgvDetCommandes.Name = "dgvDetCommandes";
            this.dgvDetCommandes.Size = new System.Drawing.Size(279, 192);
            this.dgvDetCommandes.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Recherche";
            // 
            // tbIdClient
            // 
            this.tbIdClient.Location = new System.Drawing.Point(70, 1);
            this.tbIdClient.Name = "tbIdClient";
            this.tbIdClient.Size = new System.Drawing.Size(136, 20);
            this.tbIdClient.TabIndex = 5;
            this.tbIdClient.Text = "Entrer l\'ID du client";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(230, 1);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 6;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            // 
            // FormDetailsCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 323);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.tbIdClient);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDetCommandes);
            this.Controls.Add(this.dgvCommandes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormDetailsCommande";
            this.Text = "FormDetailsCommande";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetCommandes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCommandes;
        private System.Windows.Forms.DataGridView dgvDetCommandes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbIdClient;
        private System.Windows.Forms.Button btOK;
    }
}