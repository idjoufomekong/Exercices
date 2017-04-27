namespace ADO
{
    partial class FormCommandes
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
            this.lblCodeClient = new System.Windows.Forms.Label();
            this.tbCodeClient = new System.Windows.Forms.TextBox();
            this.btVoirCom = new System.Windows.Forms.Button();
            this.dgvListCom = new System.Windows.Forms.DataGridView();
            this.lbClient = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCom)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodeClient
            // 
            this.lblCodeClient.AutoSize = true;
            this.lblCodeClient.Location = new System.Drawing.Point(192, 38);
            this.lblCodeClient.Name = "lblCodeClient";
            this.lblCodeClient.Size = new System.Drawing.Size(75, 13);
            this.lblCodeClient.TabIndex = 0;
            this.lblCodeClient.Text = "Code du client";
            // 
            // tbCodeClient
            // 
            this.tbCodeClient.Location = new System.Drawing.Point(313, 30);
            this.tbCodeClient.Name = "tbCodeClient";
            this.tbCodeClient.Size = new System.Drawing.Size(86, 20);
            this.tbCodeClient.TabIndex = 1;
            // 
            // btVoirCom
            // 
            this.btVoirCom.Location = new System.Drawing.Point(432, 28);
            this.btVoirCom.Name = "btVoirCom";
            this.btVoirCom.Size = new System.Drawing.Size(132, 23);
            this.btVoirCom.TabIndex = 2;
            this.btVoirCom.Text = "Voir Les commandes";
            this.btVoirCom.UseVisualStyleBackColor = true;
            // 
            // dgvListCom
            // 
            this.dgvListCom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListCom.Location = new System.Drawing.Point(119, 74);
            this.dgvListCom.Name = "dgvListCom";
            this.dgvListCom.Size = new System.Drawing.Size(445, 279);
            this.dgvListCom.TabIndex = 3;
            // 
            // lbClient
            // 
            this.lbClient.FormattingEnabled = true;
            this.lbClient.Location = new System.Drawing.Point(12, 30);
            this.lbClient.Name = "lbClient";
            this.lbClient.Size = new System.Drawing.Size(101, 316);
            this.lbClient.TabIndex = 4;
            // 
            // FormCommandes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 382);
            this.Controls.Add(this.lbClient);
            this.Controls.Add(this.dgvListCom);
            this.Controls.Add(this.btVoirCom);
            this.Controls.Add(this.tbCodeClient);
            this.Controls.Add(this.lblCodeClient);
            this.Name = "FormCommandes";
            this.Text = "FormCommandes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodeClient;
        private System.Windows.Forms.TextBox tbCodeClient;
        private System.Windows.Forms.Button btVoirCom;
        private System.Windows.Forms.DataGridView dgvListCom;
        private System.Windows.Forms.ListBox lbClient;
    }
}