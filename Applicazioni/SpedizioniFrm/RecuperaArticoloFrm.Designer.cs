namespace SpedizioniFrm
{
    partial class RecuperaArticoloFrm
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
            this.dgvRisultati = new System.Windows.Forms.DataGridView();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODELLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIZIONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRisultati)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRisultati
            // 
            this.dgvRisultati.AllowUserToAddRows = false;
            this.dgvRisultati.AllowUserToDeleteRows = false;
            this.dgvRisultati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRisultati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRisultati.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.MODELLO,
            this.DESCRIZIONE});
            this.dgvRisultati.Location = new System.Drawing.Point(0, 12);
            this.dgvRisultati.Name = "dgvRisultati";
            this.dgvRisultati.ReadOnly = true;
            this.dgvRisultati.Size = new System.Drawing.Size(475, 398);
            this.dgvRisultati.TabIndex = 2;
            this.dgvRisultati.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRisultati_CellMouseDoubleClick);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Location = new System.Drawing.Point(207, 416);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 3;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IDMAGAZZ";
            this.Column1.HeaderText = "IDMAGAZZ";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // MODELLO
            // 
            this.MODELLO.DataPropertyName = "MODELLO";
            this.MODELLO.FillWeight = 120F;
            this.MODELLO.HeaderText = "Modello";
            this.MODELLO.Name = "MODELLO";
            this.MODELLO.ReadOnly = true;
            this.MODELLO.Width = 120;
            // 
            // DESCRIZIONE
            // 
            this.DESCRIZIONE.DataPropertyName = "DESMAGAZZ";
            this.DESCRIZIONE.FillWeight = 300F;
            this.DESCRIZIONE.HeaderText = "Descrizione";
            this.DESCRIZIONE.Name = "DESCRIZIONE";
            this.DESCRIZIONE.ReadOnly = true;
            this.DESCRIZIONE.Width = 300;
            // 
            // RecuperaArticoloFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 450);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.dgvRisultati);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecuperaArticoloFrm";
            this.Text = "RecuperaArticoloFrm";
            this.Load += new System.EventHandler(this.RecuperaArticoloFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRisultati)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRisultati;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODELLO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIZIONE;
    }
}