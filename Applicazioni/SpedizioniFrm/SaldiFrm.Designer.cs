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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSaldi = new System.Windows.Forms.DataGridView();
            this.IDSALDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDUBICAZIONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDMAGAZZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOVIMENTA = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldi)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(44, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(237, 63);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(130, 20);
            this.textBox2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(416, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cerca";
            this.button1.UseVisualStyleBackColor = true;
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
            this.dgvSaldi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaldi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDSALDO,
            this.IDUBICAZIONE,
            this.IDMAGAZZ,
            this.QUANTITA,
            this.MOVIMENTA});
            this.dgvSaldi.Location = new System.Drawing.Point(-2, 106);
            this.dgvSaldi.Name = "dgvSaldi";
            this.dgvSaldi.Size = new System.Drawing.Size(619, 397);
            this.dgvSaldi.TabIndex = 5;
            // 
            // IDSALDO
            // 
            this.IDSALDO.HeaderText = "SALDO";
            this.IDSALDO.Name = "IDSALDO";
            this.IDSALDO.Visible = false;
            // 
            // IDUBICAZIONE
            // 
            this.IDUBICAZIONE.HeaderText = "UBICAZIONE";
            this.IDUBICAZIONE.Name = "IDUBICAZIONE";
            // 
            // IDMAGAZZ
            // 
            this.IDMAGAZZ.HeaderText = "ARTICOLO";
            this.IDMAGAZZ.Name = "IDMAGAZZ";
            // 
            // QUANTITA
            // 
            this.QUANTITA.HeaderText = "QUANTITA";
            this.QUANTITA.Name = "QUANTITA";
            // 
            // MOVIMENTA
            // 
            this.MOVIMENTA.HeaderText = "MOVIMENTA";
            this.MOVIMENTA.Name = "MOVIMENTA";
            this.MOVIMENTA.UseColumnTextForButtonValue = true;
            // 
            // SaldiFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(617, 502);
            this.Controls.Add(this.dgvSaldi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "SaldiFrm";
            this.Text = "Saldi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSaldi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDSALDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDUBICAZIONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMAGAZZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITA;
        private System.Windows.Forms.DataGridViewButtonColumn MOVIMENTA;
    }
}