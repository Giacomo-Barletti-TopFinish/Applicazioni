namespace SpedizioniFrm
{
    partial class UbicazioniFrm
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
            this.txtCodiceUbicazione = new System.Windows.Forms.TextBox();
            this.txtDescrizioneUbicazione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalva = new System.Windows.Forms.Button();
            this.ddlStampanti = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvUbicazioni = new System.Windows.Forms.DataGridView();
            this.IDUBICAZIONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIZIONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BARCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cancella = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Stampa = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUbicazioni)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice";
            // 
            // txtCodiceUbicazione
            // 
            this.txtCodiceUbicazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodiceUbicazione.Location = new System.Drawing.Point(68, 74);
            this.txtCodiceUbicazione.MaxLength = 5;
            this.txtCodiceUbicazione.Name = "txtCodiceUbicazione";
            this.txtCodiceUbicazione.Size = new System.Drawing.Size(88, 21);
            this.txtCodiceUbicazione.TabIndex = 1;
            // 
            // txtDescrizioneUbicazione
            // 
            this.txtDescrizioneUbicazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescrizioneUbicazione.Location = new System.Drawing.Point(216, 74);
            this.txtDescrizioneUbicazione.MaxLength = 30;
            this.txtDescrizioneUbicazione.Name = "txtDescrizioneUbicazione";
            this.txtDescrizioneUbicazione.Size = new System.Drawing.Size(238, 21);
            this.txtDescrizioneUbicazione.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(216, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrizione";
            // 
            // btnSalva
            // 
            this.btnSalva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalva.Location = new System.Drawing.Point(540, 69);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(85, 31);
            this.btnSalva.TabIndex = 4;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // ddlStampanti
            // 
            this.ddlStampanti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStampanti.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlStampanti.FormattingEnabled = true;
            this.ddlStampanti.Location = new System.Drawing.Point(97, 13);
            this.ddlStampanti.Margin = new System.Windows.Forms.Padding(4);
            this.ddlStampanti.Name = "ddlStampanti";
            this.ddlStampanti.Size = new System.Drawing.Size(528, 26);
            this.ddlStampanti.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Stampanti";
            // 
            // dgvUbicazioni
            // 
            this.dgvUbicazioni.AllowUserToAddRows = false;
            this.dgvUbicazioni.AllowUserToDeleteRows = false;
            this.dgvUbicazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUbicazioni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUbicazioni.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDUBICAZIONE,
            this.CODICE,
            this.DESCRIZIONE,
            this.BARCODE,
            this.Cancella,
            this.Stampa});
            this.dgvUbicazioni.Location = new System.Drawing.Point(15, 128);
            this.dgvUbicazioni.Name = "dgvUbicazioni";
            this.dgvUbicazioni.ReadOnly = true;
            this.dgvUbicazioni.Size = new System.Drawing.Size(910, 387);
            this.dgvUbicazioni.TabIndex = 9;
            this.dgvUbicazioni.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUbicazioni_CellContentClick);
            // 
            // IDUBICAZIONE
            // 
            this.IDUBICAZIONE.DataPropertyName = "IDUBICAZIONE";
            this.IDUBICAZIONE.HeaderText = "IDUBICAZIONE";
            this.IDUBICAZIONE.Name = "IDUBICAZIONE";
            this.IDUBICAZIONE.ReadOnly = true;
            this.IDUBICAZIONE.Visible = false;
            // 
            // CODICE
            // 
            this.CODICE.DataPropertyName = "CODICE";
            this.CODICE.FillWeight = 80F;
            this.CODICE.HeaderText = "CODICE";
            this.CODICE.Name = "CODICE";
            this.CODICE.ReadOnly = true;
            this.CODICE.Width = 80;
            // 
            // DESCRIZIONE
            // 
            this.DESCRIZIONE.DataPropertyName = "DESCRIZIONE";
            this.DESCRIZIONE.FillWeight = 200F;
            this.DESCRIZIONE.HeaderText = "DESCRIZIONE";
            this.DESCRIZIONE.Name = "DESCRIZIONE";
            this.DESCRIZIONE.ReadOnly = true;
            this.DESCRIZIONE.Width = 200;
            // 
            // BARCODE
            // 
            this.BARCODE.DataPropertyName = "BARCODE";
            this.BARCODE.HeaderText = "BARCODE";
            this.BARCODE.Name = "BARCODE";
            this.BARCODE.ReadOnly = true;
            // 
            // Cancella
            // 
            this.Cancella.HeaderText = "";
            this.Cancella.Name = "Cancella";
            this.Cancella.ReadOnly = true;
            this.Cancella.Text = "Cancella";
            this.Cancella.UseColumnTextForButtonValue = true;
            // 
            // Stampa
            // 
            this.Stampa.HeaderText = "";
            this.Stampa.Name = "Stampa";
            this.Stampa.ReadOnly = true;
            this.Stampa.Text = "Stampa";
            this.Stampa.UseColumnTextForButtonValue = true;
            // 
            // UbicazioniFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 536);
            this.Controls.Add(this.dgvUbicazioni);
            this.Controls.Add(this.ddlStampanti);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.txtDescrizioneUbicazione);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodiceUbicazione);
            this.Controls.Add(this.label1);
            this.Name = "UbicazioniFrm";
            this.Text = "Ubicazioni";
            this.Load += new System.EventHandler(this.UbicazioniFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUbicazioni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodiceUbicazione;
        private System.Windows.Forms.TextBox txtDescrizioneUbicazione;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.ComboBox ddlStampanti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvUbicazioni;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDUBICAZIONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIZIONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn BARCODE;
        private System.Windows.Forms.DataGridViewButtonColumn Cancella;
        private System.Windows.Forms.DataGridViewButtonColumn Stampa;
    }
}