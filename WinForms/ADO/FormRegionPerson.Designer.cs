namespace ADO
{
    partial class FormRegionPerson
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
            this.cbPersonne = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRegion = new System.Windows.Forms.DataGridView();
            this.btEnrRegPers = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegion)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPersonne
            // 
            this.cbPersonne.FormattingEnabled = true;
            this.cbPersonne.Location = new System.Drawing.Point(128, 28);
            this.cbPersonne.Name = "cbPersonne";
            this.cbPersonne.Size = new System.Drawing.Size(211, 21);
            this.cbPersonne.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Personne";
            // 
            // dgvRegion
            // 
            this.dgvRegion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegion.Location = new System.Drawing.Point(37, 72);
            this.dgvRegion.Name = "dgvRegion";
            this.dgvRegion.Size = new System.Drawing.Size(321, 164);
            this.dgvRegion.TabIndex = 2;
            // 
            // btEnrRegPers
            // 
            this.btEnrRegPers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnrRegPers.Location = new System.Drawing.Point(37, 250);
            this.btEnrRegPers.Name = "btEnrRegPers";
            this.btEnrRegPers.Size = new System.Drawing.Size(95, 27);
            this.btEnrRegPers.TabIndex = 3;
            this.btEnrRegPers.Text = "Enregistrer";
            this.btEnrRegPers.UseVisualStyleBackColor = true;
            // 
            // FormRegionPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 321);
            this.Controls.Add(this.btEnrRegPers);
            this.Controls.Add(this.dgvRegion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPersonne);
            this.Name = "FormRegionPerson";
            this.Text = "Régions des employés";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPersonne;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRegion;
        private System.Windows.Forms.Button btEnrRegPers;
    }
}