namespace SpedizioniFrm
{
    partial class MovimentiFrm
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
            this.TXTCODICE = new System.Windows.Forms.TextBox();
            this.CODICE = new System.Windows.Forms.Label();
            this.DESCRIZIONE = new System.Windows.Forms.Label();
            this.TXTDESCRIZIONE = new System.Windows.Forms.TextBox();
            this.TXTMODELLO = new System.Windows.Forms.TextBox();
            this.QUANTITAATTUALE = new System.Windows.Forms.Label();
            this.TXTCAUSALE = new System.Windows.Forms.TextBox();
            this.TIPOMOVIMENTO = new System.Windows.Forms.Label();
            this.CAUSALE = new System.Windows.Forms.Label();
            this.QUANTITA = new System.Windows.Forms.Label();
            this.BTNOK = new System.Windows.Forms.Button();
            this.BTNANNULLA = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.TXTQUANTITASALDO = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // TXTCODICE
            // 
            this.TXTCODICE.Location = new System.Drawing.Point(95, 48);
            this.TXTCODICE.Name = "TXTCODICE";
            this.TXTCODICE.ReadOnly = true;
            this.TXTCODICE.Size = new System.Drawing.Size(229, 20);
            this.TXTCODICE.TabIndex = 0;
            this.TXTCODICE.TabStop = false;
            // 
            // CODICE
            // 
            this.CODICE.AutoSize = true;
            this.CODICE.Location = new System.Drawing.Point(33, 52);
            this.CODICE.Name = "CODICE";
            this.CODICE.Size = new System.Drawing.Size(47, 13);
            this.CODICE.TabIndex = 1;
            this.CODICE.Text = "CODICE";
            // 
            // DESCRIZIONE
            // 
            this.DESCRIZIONE.AutoSize = true;
            this.DESCRIZIONE.Location = new System.Drawing.Point(445, 52);
            this.DESCRIZIONE.Name = "DESCRIZIONE";
            this.DESCRIZIONE.Size = new System.Drawing.Size(80, 13);
            this.DESCRIZIONE.TabIndex = 2;
            this.DESCRIZIONE.Text = "DESCRIZIONE";
            // 
            // TXTDESCRIZIONE
            // 
            this.TXTDESCRIZIONE.Location = new System.Drawing.Point(531, 48);
            this.TXTDESCRIZIONE.Name = "TXTDESCRIZIONE";
            this.TXTDESCRIZIONE.ReadOnly = true;
            this.TXTDESCRIZIONE.Size = new System.Drawing.Size(228, 20);
            this.TXTDESCRIZIONE.TabIndex = 3;
            this.TXTDESCRIZIONE.TabStop = false;
            // 
            // TXTMODELLO
            // 
            this.TXTMODELLO.Location = new System.Drawing.Point(95, 124);
            this.TXTMODELLO.Name = "TXTMODELLO";
            this.TXTMODELLO.ReadOnly = true;
            this.TXTMODELLO.Size = new System.Drawing.Size(229, 20);
            this.TXTMODELLO.TabIndex = 4;
            this.TXTMODELLO.TabStop = false;
            // 
            // QUANTITAATTUALE
            // 
            this.QUANTITAATTUALE.Location = new System.Drawing.Point(12, 127);
            this.QUANTITAATTUALE.Name = "QUANTITAATTUALE";
            this.QUANTITAATTUALE.Size = new System.Drawing.Size(62, 15);
            this.QUANTITAATTUALE.TabIndex = 5;
            this.QUANTITAATTUALE.Text = "MODELLO";
            // 
            // TXTCAUSALE
            // 
            this.TXTCAUSALE.Location = new System.Drawing.Point(133, 292);
            this.TXTCAUSALE.MaxLength = 50;
            this.TXTCAUSALE.Name = "TXTCAUSALE";
            this.TXTCAUSALE.Size = new System.Drawing.Size(200, 20);
            this.TXTCAUSALE.TabIndex = 1;
            // 
            // TIPOMOVIMENTO
            // 
            this.TIPOMOVIMENTO.AutoSize = true;
            this.TIPOMOVIMENTO.Location = new System.Drawing.Point(25, 218);
            this.TIPOMOVIMENTO.Name = "TIPOMOVIMENTO";
            this.TIPOMOVIMENTO.Size = new System.Drawing.Size(101, 13);
            this.TIPOMOVIMENTO.TabIndex = 9;
            this.TIPOMOVIMENTO.Text = "TIPO MOVIMENTO";
            // 
            // CAUSALE
            // 
            this.CAUSALE.AutoSize = true;
            this.CAUSALE.Location = new System.Drawing.Point(70, 296);
            this.CAUSALE.Name = "CAUSALE";
            this.CAUSALE.Size = new System.Drawing.Size(56, 13);
            this.CAUSALE.TabIndex = 10;
            this.CAUSALE.Text = "CAUSALE";
            // 
            // QUANTITA
            // 
            this.QUANTITA.AutoSize = true;
            this.QUANTITA.Location = new System.Drawing.Point(62, 383);
            this.QUANTITA.Name = "QUANTITA";
            this.QUANTITA.Size = new System.Drawing.Size(64, 13);
            this.QUANTITA.TabIndex = 11;
            this.QUANTITA.Text = "QUANTITA\'";
            // 
            // BTNOK
            // 
            this.BTNOK.Location = new System.Drawing.Point(142, 501);
            this.BTNOK.Name = "BTNOK";
            this.BTNOK.Size = new System.Drawing.Size(154, 47);
            this.BTNOK.TabIndex = 3;
            this.BTNOK.Text = "OK";
            this.BTNOK.UseVisualStyleBackColor = true;
            // 
            // BTNANNULLA
            // 
            this.BTNANNULLA.Location = new System.Drawing.Point(507, 501);
            this.BTNANNULLA.Name = "BTNANNULLA";
            this.BTNANNULLA.Size = new System.Drawing.Size(154, 47);
            this.BTNANNULLA.TabIndex = 4;
            this.BTNANNULLA.Text = "ANNULLA";
            this.BTNANNULLA.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "VERSAMENTO",
            "PRELIEVO"});
            this.comboBox1.Location = new System.Drawing.Point(133, 214);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(185, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(133, 379);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(407, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "QUANTITA ATTUALE";
            // 
            // TXTQUANTITASALDO
            // 
            this.TXTQUANTITASALDO.Location = new System.Drawing.Point(531, 124);
            this.TXTQUANTITASALDO.Name = "TXTQUANTITASALDO";
            this.TXTQUANTITASALDO.ReadOnly = true;
            this.TXTQUANTITASALDO.Size = new System.Drawing.Size(228, 20);
            this.TXTQUANTITASALDO.TabIndex = 16;
            this.TXTQUANTITASALDO.TabStop = false;
            // 
            // MovimentiFrm
            // 
            this.ClientSize = new System.Drawing.Size(827, 564);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTQUANTITASALDO);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BTNANNULLA);
            this.Controls.Add(this.BTNOK);
            this.Controls.Add(this.QUANTITA);
            this.Controls.Add(this.CAUSALE);
            this.Controls.Add(this.TIPOMOVIMENTO);
            this.Controls.Add(this.TXTCAUSALE);
            this.Controls.Add(this.QUANTITAATTUALE);
            this.Controls.Add(this.TXTMODELLO);
            this.Controls.Add(this.TXTDESCRIZIONE);
            this.Controls.Add(this.DESCRIZIONE);
            this.Controls.Add(this.CODICE);
            this.Controls.Add(this.TXTCODICE);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MovimentiFrm";
           
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTCODICE;
        private System.Windows.Forms.Label CODICE;
        private System.Windows.Forms.Label DESCRIZIONE;
        private System.Windows.Forms.TextBox TXTDESCRIZIONE;
        private System.Windows.Forms.TextBox TXTMODELLO;
        private System.Windows.Forms.Label QUANTITAATTUALE;
        private System.Windows.Forms.TextBox TXTCAUSALE;
        private System.Windows.Forms.Label TIPOMOVIMENTO;
        private System.Windows.Forms.Label CAUSALE;
        private System.Windows.Forms.Label QUANTITA;
        private System.Windows.Forms.Button BTNOK;
        private System.Windows.Forms.Button BTNANNULLA;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTQUANTITASALDO;
    }
}