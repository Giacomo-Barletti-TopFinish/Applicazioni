namespace SpedizioniFrm
{
    partial class ListamovimentiFrm
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
            this.txtUbicazione = new System.Windows.Forms.TextBox();
            this.txtArticolo = new System.Windows.Forms.TextBox();
            this.btncerca = new System.Windows.Forms.Button();
            this.Ubicazione = new System.Windows.Forms.Label();
            this.Articolo = new System.Windows.Forms.Label();
            this.dgvlistamovimenti = new System.Windows.Forms.DataGridView();
            this.dtInizio = new System.Windows.Forms.DateTimePicker();
            this.dtFine = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IDUBICAZIONE_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UBICAZIONE_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ARTICOLO_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITA_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATAMODIFICA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UTENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlistamovimenti)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUbicazione
            // 
            this.txtUbicazione.Location = new System.Drawing.Point(49, 30);
            this.txtUbicazione.Name = "txtUbicazione";
            this.txtUbicazione.Size = new System.Drawing.Size(200, 20);
            this.txtUbicazione.TabIndex = 0;
            // 
            // txtArticolo
            // 
            this.txtArticolo.Location = new System.Drawing.Point(305, 30);
            this.txtArticolo.Name = "txtArticolo";
            this.txtArticolo.Size = new System.Drawing.Size(200, 20);
            this.txtArticolo.TabIndex = 1;
            // 
            // btncerca
            // 
            this.btncerca.Location = new System.Drawing.Point(569, 44);
            this.btncerca.Name = "btncerca";
            this.btncerca.Size = new System.Drawing.Size(95, 30);
            this.btncerca.TabIndex = 2;
            this.btncerca.Text = "Cerca";
            this.btncerca.UseVisualStyleBackColor = true;
            this.btncerca.Click += new System.EventHandler(this.btncerca_Click);
            // 
            // Ubicazione
            // 
            this.Ubicazione.AutoSize = true;
            this.Ubicazione.Location = new System.Drawing.Point(49, 11);
            this.Ubicazione.Name = "Ubicazione";
            this.Ubicazione.Size = new System.Drawing.Size(60, 13);
            this.Ubicazione.TabIndex = 3;
            this.Ubicazione.Text = "Ubicazione";
            // 
            // Articolo
            // 
            this.Articolo.AutoSize = true;
            this.Articolo.Location = new System.Drawing.Point(305, 11);
            this.Articolo.Name = "Articolo";
            this.Articolo.Size = new System.Drawing.Size(42, 13);
            this.Articolo.TabIndex = 4;
            this.Articolo.Text = "Articolo";
            // 
            // dgvlistamovimenti
            // 
            this.dgvlistamovimenti.AllowUserToAddRows = false;
            this.dgvlistamovimenti.AllowUserToDeleteRows = false;
            this.dgvlistamovimenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvlistamovimenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlistamovimenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDUBICAZIONE_,
            this.UBICAZIONE_,
            this.ARTICOLO_,
            this.QUANTITA_,
            this.DATAMODIFICA,
            this.UTENTE});
            this.dgvlistamovimenti.Location = new System.Drawing.Point(0, 122);
            this.dgvlistamovimenti.Name = "dgvlistamovimenti";
            this.dgvlistamovimenti.ReadOnly = true;
            this.dgvlistamovimenti.Size = new System.Drawing.Size(899, 475);
            this.dgvlistamovimenti.TabIndex = 5;
            // 
            // dtInizio
            // 
            this.dtInizio.Location = new System.Drawing.Point(49, 78);
            this.dtInizio.Name = "dtInizio";
            this.dtInizio.Size = new System.Drawing.Size(200, 20);
            this.dtInizio.TabIndex = 6;
            // 
            // dtFine
            // 
            this.dtFine.Location = new System.Drawing.Point(305, 78);
            this.dtFine.Name = "dtFine";
            this.dtFine.Size = new System.Drawing.Size(200, 20);
            this.dtFine.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Data inizio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data fine";
            // 
            // IDUBICAZIONE_
            // 
            this.IDUBICAZIONE_.DataPropertyName = "IDUBICAZIONE";
            this.IDUBICAZIONE_.FillWeight = 170F;
            this.IDUBICAZIONE_.HeaderText = "IDUBICAZIONE";
            this.IDUBICAZIONE_.Name = "IDUBICAZIONE_";
            this.IDUBICAZIONE_.ReadOnly = true;
            this.IDUBICAZIONE_.Visible = false;
            this.IDUBICAZIONE_.Width = 20;
            // 
            // UBICAZIONE_
            // 
            this.UBICAZIONE_.DataPropertyName = "CODICE";
            this.UBICAZIONE_.HeaderText = "UBICAZIONE";
            this.UBICAZIONE_.Name = "UBICAZIONE_";
            this.UBICAZIONE_.ReadOnly = true;
            this.UBICAZIONE_.Width = 170;
            // 
            // ARTICOLO_
            // 
            this.ARTICOLO_.DataPropertyName = "MODELLO";
            this.ARTICOLO_.HeaderText = "ARTICOLO";
            this.ARTICOLO_.Name = "ARTICOLO_";
            this.ARTICOLO_.ReadOnly = true;
            this.ARTICOLO_.Width = 170;
            // 
            // QUANTITA_
            // 
            this.QUANTITA_.DataPropertyName = "QUANTITA";
            this.QUANTITA_.HeaderText = "QUANTITA";
            this.QUANTITA_.Name = "QUANTITA_";
            this.QUANTITA_.ReadOnly = true;
            this.QUANTITA_.Width = 170;
            // 
            // DATAMODIFICA
            // 
            this.DATAMODIFICA.DataPropertyName = "DATAMODIFICA";
            this.DATAMODIFICA.HeaderText = "DATA MODIFICA";
            this.DATAMODIFICA.Name = "DATAMODIFICA";
            this.DATAMODIFICA.ReadOnly = true;
            this.DATAMODIFICA.Width = 170;
            // 
            // UTENTE
            // 
            this.UTENTE.DataPropertyName = "UTENTEMODIFICA";
            this.UTENTE.HeaderText = "UTENTE";
            this.UTENTE.Name = "UTENTE";
            this.UTENTE.ReadOnly = true;
            this.UTENTE.Width = 170;
            // 
            // ListamovimentiFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 592);
            this.Controls.Add(this.dtFine);
            this.Controls.Add(this.dtInizio);
            this.Controls.Add(this.dgvlistamovimenti);
            this.Controls.Add(this.Articolo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Ubicazione);
            this.Controls.Add(this.btncerca);
            this.Controls.Add(this.txtArticolo);
            this.Controls.Add(this.txtUbicazione);
            this.Name = "ListamovimentiFrm";
            this.Text = "Lista movimenti";
            this.Load += new System.EventHandler(this.ListamovimentiFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlistamovimenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUbicazione;
        private System.Windows.Forms.TextBox txtArticolo;
        private System.Windows.Forms.Button btncerca;
        private System.Windows.Forms.Label Ubicazione;
        private System.Windows.Forms.Label Articolo;
        private System.Windows.Forms.DataGridView dgvlistamovimenti;
        private System.Windows.Forms.DateTimePicker dtInizio;
        private System.Windows.Forms.DateTimePicker dtFine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDUBICAZIONE_;
        private System.Windows.Forms.DataGridViewTextBoxColumn UBICAZIONE_;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARTICOLO_;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITA_;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATAMODIFICA;
        private System.Windows.Forms.DataGridViewTextBoxColumn UTENTE;
    }
}