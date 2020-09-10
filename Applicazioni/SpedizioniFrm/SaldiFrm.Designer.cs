namespace SpedizioniFrm
{
    partial class SaldiFrm
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
            this.txtubicazione = new System.Windows.Forms.TextBox();
            this.txtarticolo = new System.Windows.Forms.TextBox();
            this.btnCerca = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSaldi = new System.Windows.Forms.DataGridView();
            this.chkNascondiSaldiAZero = new System.Windows.Forms.CheckBox();
            this.IDUBICAZIONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIZIONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDMAGAZZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOVIMENTA = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IDSALDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnexport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtubicazione
            // 
            this.txtubicazione.Location = new System.Drawing.Point(44, 66);
            this.txtubicazione.Name = "txtubicazione";
            this.txtubicazione.Size = new System.Drawing.Size(130, 20);
            this.txtubicazione.TabIndex = 0;
            // 
            // txtarticolo
            // 
            this.txtarticolo.Location = new System.Drawing.Point(237, 66);
            this.txtarticolo.Name = "txtarticolo";
            this.txtarticolo.Size = new System.Drawing.Size(130, 20);
            this.txtarticolo.TabIndex = 1;
            // 
            // btnCerca
            // 
            this.btnCerca.Location = new System.Drawing.Point(416, 65);
            this.btnCerca.Name = "btnCerca";
            this.btnCerca.Size = new System.Drawing.Size(75, 23);
            this.btnCerca.TabIndex = 2;
            this.btnCerca.Text = "Cerca";
            this.btnCerca.UseVisualStyleBackColor = true;
            this.btnCerca.Click += new System.EventHandler(this.btnCerca_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ubicazione";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Articolo";
            // 
            // dgvSaldi
            // 
            this.dgvSaldi.AllowUserToAddRows = false;
            this.dgvSaldi.AllowUserToDeleteRows = false;
            this.dgvSaldi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSaldi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaldi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDUBICAZIONE,
            this.DESCRIZIONE,
            this.IDMAGAZZ,
            this.QUANTITA,
            this.MOVIMENTA,
            this.IDSALDO});
            this.dgvSaldi.Location = new System.Drawing.Point(-1, 104);
            this.dgvSaldi.Name = "dgvSaldi";
            this.dgvSaldi.ReadOnly = true;
            this.dgvSaldi.Size = new System.Drawing.Size(816, 455);
            this.dgvSaldi.TabIndex = 5;
            this.dgvSaldi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaldi_CellContentClick);
            // 
            // chkNascondiSaldiAZero
            // 
            this.chkNascondiSaldiAZero.AutoSize = true;
            this.chkNascondiSaldiAZero.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNascondiSaldiAZero.Checked = true;
            this.chkNascondiSaldiAZero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNascondiSaldiAZero.Location = new System.Drawing.Point(629, 68);
            this.chkNascondiSaldiAZero.Name = "chkNascondiSaldiAZero";
            this.chkNascondiSaldiAZero.Size = new System.Drawing.Size(127, 17);
            this.chkNascondiSaldiAZero.TabIndex = 6;
            this.chkNascondiSaldiAZero.Text = "Nascondi saldi a zero";
            this.chkNascondiSaldiAZero.UseVisualStyleBackColor = true;
            // 
            // IDUBICAZIONE
            // 
            this.IDUBICAZIONE.DataPropertyName = "CODICE";
            this.IDUBICAZIONE.FillWeight = 80F;
            this.IDUBICAZIONE.HeaderText = "UBICAZIONE";
            this.IDUBICAZIONE.Name = "IDUBICAZIONE";
            this.IDUBICAZIONE.ReadOnly = true;
            this.IDUBICAZIONE.Width = 80;
            // 
            // DESCRIZIONE
            // 
            this.DESCRIZIONE.DataPropertyName = "DESCRIZIONE";
            this.DESCRIZIONE.FillWeight = 170F;
            this.DESCRIZIONE.HeaderText = "DESCRIZIONE";
            this.DESCRIZIONE.Name = "DESCRIZIONE";
            this.DESCRIZIONE.ReadOnly = true;
            this.DESCRIZIONE.Width = 170;
            // 
            // IDMAGAZZ
            // 
            this.IDMAGAZZ.DataPropertyName = "MODELLO";
            this.IDMAGAZZ.FillWeight = 170F;
            this.IDMAGAZZ.HeaderText = "ARTICOLO";
            this.IDMAGAZZ.Name = "IDMAGAZZ";
            this.IDMAGAZZ.ReadOnly = true;
            this.IDMAGAZZ.Width = 170;
            // 
            // QUANTITA
            // 
            this.QUANTITA.DataPropertyName = "QUANTITA";
            this.QUANTITA.FillWeight = 80F;
            this.QUANTITA.HeaderText = "QUANTITA";
            this.QUANTITA.Name = "QUANTITA";
            this.QUANTITA.ReadOnly = true;
            this.QUANTITA.Width = 80;
            // 
            // MOVIMENTA
            // 
            this.MOVIMENTA.HeaderText = "MOVIMENTA";
            this.MOVIMENTA.Name = "MOVIMENTA";
            this.MOVIMENTA.ReadOnly = true;
            this.MOVIMENTA.UseColumnTextForButtonValue = true;
            // 
            // IDSALDO
            // 
            this.IDSALDO.DataPropertyName = "IDSALDO";
            this.IDSALDO.HeaderText = "IDSALDO";
            this.IDSALDO.Name = "IDSALDO";
            this.IDSALDO.ReadOnly = true;
            this.IDSALDO.Visible = false;
            // 
            // btnexport
            // 
            this.btnexport.Location = new System.Drawing.Point(518, 65);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(75, 23);
            this.btnexport.TabIndex = 7;
            this.btnexport.Text = "Export";
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // SaldiFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(812, 560);
            this.Controls.Add(this.btnexport);
            this.Controls.Add(this.chkNascondiSaldiAZero);
            this.Controls.Add(this.dgvSaldi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCerca);
            this.Controls.Add(this.txtarticolo);
            this.Controls.Add(this.txtubicazione);
            this.Name = "SaldiFrm";
            this.Text = "Saldi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtubicazione;
        private System.Windows.Forms.TextBox txtarticolo;
        private System.Windows.Forms.Button btnCerca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSaldi;
        private System.Windows.Forms.CheckBox chkNascondiSaldiAZero;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDUBICAZIONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIZIONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMAGAZZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITA;
        private System.Windows.Forms.DataGridViewButtonColumn MOVIMENTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDSALDO;
        private System.Windows.Forms.Button btnexport;
    }
}