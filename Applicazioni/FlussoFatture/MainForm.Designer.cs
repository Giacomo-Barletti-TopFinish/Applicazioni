namespace FlussoFatture
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCreaFiles = new System.Windows.Forms.Button();
            this.btnTrova = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtAl = new System.Windows.Forms.DateTimePicker();
            this.dtDal = new System.Windows.Forms.DateTimePicker();
            this.dgvRisultati = new System.Windows.Forms.DataGridView();
            this.rbTutti = new System.Windows.Forms.RadioButton();
            this.rbSoloItalia = new System.Windows.Forms.RadioButton();
            this.rbEstero = new System.Windows.Forms.RadioButton();
            this.chkSelezionaTutto = new System.Windows.Forms.CheckBox();
            this.SELEZIONATA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AZIENDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOCUMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATDOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTINAZIONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODICETIPOO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTABTIPOO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODICECAUTR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTABCAUTR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDVENDITET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAGIONESOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAZIONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERORIGHE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RIFERIMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbMetalTop = new System.Windows.Forms.RadioButton();
            this.rbMetal = new System.Windows.Forms.RadioButton();
            this.rbTop = new System.Windows.Forms.RadioButton();
            this.grEstero = new System.Windows.Forms.GroupBox();
            this.grAzienda = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRisultati)).BeginInit();
            this.grEstero.SuspendLayout();
            this.grAzienda.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreaFiles
            // 
            this.btnCreaFiles.Location = new System.Drawing.Point(745, 25);
            this.btnCreaFiles.Name = "btnCreaFiles";
            this.btnCreaFiles.Size = new System.Drawing.Size(92, 48);
            this.btnCreaFiles.TabIndex = 10;
            this.btnCreaFiles.Text = "Crea files";
            this.btnCreaFiles.UseVisualStyleBackColor = true;
            this.btnCreaFiles.Click += new System.EventHandler(this.btnCreaFiles_Click);
            // 
            // btnTrova
            // 
            this.btnTrova.Location = new System.Drawing.Point(601, 25);
            this.btnTrova.Name = "btnTrova";
            this.btnTrova.Size = new System.Drawing.Size(92, 48);
            this.btnTrova.TabIndex = 9;
            this.btnTrova.Text = "Trova";
            this.btnTrova.UseVisualStyleBackColor = true;
            this.btnTrova.Click += new System.EventHandler(this.btnTrova_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "DAL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "AL";
            // 
            // dtAl
            // 
            this.dtAl.Location = new System.Drawing.Point(41, 51);
            this.dtAl.Name = "dtAl";
            this.dtAl.Size = new System.Drawing.Size(200, 20);
            this.dtAl.TabIndex = 8;
            // 
            // dtDal
            // 
            this.dtDal.Location = new System.Drawing.Point(41, 18);
            this.dtDal.Name = "dtDal";
            this.dtDal.Size = new System.Drawing.Size(200, 20);
            this.dtDal.TabIndex = 5;
            // 
            // dgvRisultati
            // 
            this.dgvRisultati.AllowUserToAddRows = false;
            this.dgvRisultati.AllowUserToResizeRows = false;
            this.dgvRisultati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRisultati.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRisultati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRisultati.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SELEZIONATA,
            this.AZIENDA,
            this.DOCUMENTO,
            this.NUMERO,
            this.DATDOC,
            this.DESTINAZIONE,
            this.CODICETIPOO,
            this.DESTABTIPOO,
            this.CODICECAUTR,
            this.DESTABCAUTR,
            this.IDVENDITET,
            this.RAGIONESOC,
            this.NAZIONE,
            this.NUMERORIGHE,
            this.RIFERIMENTO});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRisultati.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRisultati.Location = new System.Drawing.Point(18, 116);
            this.dgvRisultati.Name = "dgvRisultati";
            this.dgvRisultati.Size = new System.Drawing.Size(1551, 586);
            this.dgvRisultati.TabIndex = 11;
            // 
            // rbTutti
            // 
            this.rbTutti.AutoSize = true;
            this.rbTutti.Checked = true;
            this.rbTutti.Location = new System.Drawing.Point(6, 17);
            this.rbTutti.Name = "rbTutti";
            this.rbTutti.Size = new System.Drawing.Size(46, 17);
            this.rbTutti.TabIndex = 12;
            this.rbTutti.TabStop = true;
            this.rbTutti.Text = "Tutti";
            this.rbTutti.UseVisualStyleBackColor = true;
            // 
            // rbSoloItalia
            // 
            this.rbSoloItalia.AutoSize = true;
            this.rbSoloItalia.Location = new System.Drawing.Point(6, 46);
            this.rbSoloItalia.Name = "rbSoloItalia";
            this.rbSoloItalia.Size = new System.Drawing.Size(82, 17);
            this.rbSoloItalia.TabIndex = 12;
            this.rbSoloItalia.Text = "Solo ITALIA";
            this.rbSoloItalia.UseVisualStyleBackColor = true;
            // 
            // rbEstero
            // 
            this.rbEstero.AutoSize = true;
            this.rbEstero.Location = new System.Drawing.Point(6, 75);
            this.rbEstero.Name = "rbEstero";
            this.rbEstero.Size = new System.Drawing.Size(69, 17);
            this.rbEstero.TabIndex = 12;
            this.rbEstero.Text = "ESTERO";
            this.rbEstero.UseVisualStyleBackColor = true;
            // 
            // chkSelezionaTutto
            // 
            this.chkSelezionaTutto.AutoSize = true;
            this.chkSelezionaTutto.Location = new System.Drawing.Point(41, 93);
            this.chkSelezionaTutto.Name = "chkSelezionaTutto";
            this.chkSelezionaTutto.Size = new System.Drawing.Size(168, 17);
            this.chkSelezionaTutto.TabIndex = 13;
            this.chkSelezionaTutto.Text = "Seleziona / Deseleziona tutoo";
            this.chkSelezionaTutto.UseVisualStyleBackColor = true;
            this.chkSelezionaTutto.CheckedChanged += new System.EventHandler(this.chkSelezionaTutto_CheckedChanged);
            // 
            // SELEZIONATA
            // 
            this.SELEZIONATA.FillWeight = 70F;
            this.SELEZIONATA.HeaderText = "";
            this.SELEZIONATA.Name = "SELEZIONATA";
            this.SELEZIONATA.Width = 70;
            // 
            // AZIENDA
            // 
            this.AZIENDA.DataPropertyName = "AZIENDA";
            this.AZIENDA.HeaderText = "AZIENDA";
            this.AZIENDA.Name = "AZIENDA";
            // 
            // DOCUMENTO
            // 
            this.DOCUMENTO.DataPropertyName = "FULLNUMDOC";
            this.DOCUMENTO.FillWeight = 150F;
            this.DOCUMENTO.HeaderText = "DOCUMENTO";
            this.DOCUMENTO.Name = "DOCUMENTO";
            this.DOCUMENTO.Width = 150;
            // 
            // NUMERO
            // 
            this.NUMERO.DataPropertyName = "NUMDOC";
            this.NUMERO.HeaderText = "NUMERO";
            this.NUMERO.Name = "NUMERO";
            // 
            // DATDOC
            // 
            this.DATDOC.DataPropertyName = "DATDOC";
            this.DATDOC.HeaderText = "DATA DOC";
            this.DATDOC.Name = "DATDOC";
            // 
            // DESTINAZIONE
            // 
            this.DESTINAZIONE.DataPropertyName = "DESTINAZIONE";
            this.DESTINAZIONE.FillWeight = 150F;
            this.DESTINAZIONE.HeaderText = "DESTINAZIONE";
            this.DESTINAZIONE.Name = "DESTINAZIONE";
            this.DESTINAZIONE.Width = 150;
            // 
            // CODICETIPOO
            // 
            this.CODICETIPOO.DataPropertyName = "CODICETIPOO";
            this.CODICETIPOO.HeaderText = "CODICE ORDINE";
            this.CODICETIPOO.Name = "CODICETIPOO";
            this.CODICETIPOO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CODICETIPOO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DESTABTIPOO
            // 
            this.DESTABTIPOO.DataPropertyName = "DESTABTIPOO";
            this.DESTABTIPOO.FillWeight = 200F;
            this.DESTABTIPOO.HeaderText = "TIPO ORDINE";
            this.DESTABTIPOO.Name = "DESTABTIPOO";
            this.DESTABTIPOO.Width = 200;
            // 
            // CODICECAUTR
            // 
            this.CODICECAUTR.DataPropertyName = "CODICECAUTR";
            this.CODICECAUTR.HeaderText = "COD";
            this.CODICECAUTR.Name = "CODICECAUTR";
            // 
            // DESTABCAUTR
            // 
            this.DESTABCAUTR.DataPropertyName = "DESTABCAUTR";
            this.DESTABCAUTR.FillWeight = 150F;
            this.DESTABCAUTR.HeaderText = "CAUSALE";
            this.DESTABCAUTR.Name = "DESTABCAUTR";
            this.DESTABCAUTR.Width = 150;
            // 
            // IDVENDITET
            // 
            this.IDVENDITET.DataPropertyName = "IDVENDITET";
            this.IDVENDITET.HeaderText = "IDVENDITET";
            this.IDVENDITET.Name = "IDVENDITET";
            this.IDVENDITET.Visible = false;
            // 
            // RAGIONESOC
            // 
            this.RAGIONESOC.DataPropertyName = "RAGIONESOC";
            this.RAGIONESOC.FillWeight = 150F;
            this.RAGIONESOC.HeaderText = "CLIENTE";
            this.RAGIONESOC.Name = "RAGIONESOC";
            this.RAGIONESOC.Width = 150;
            // 
            // NAZIONE
            // 
            this.NAZIONE.DataPropertyName = "NAZIONE";
            this.NAZIONE.HeaderText = "NAZIONE";
            this.NAZIONE.Name = "NAZIONE";
            // 
            // NUMERORIGHE
            // 
            this.NUMERORIGHE.DataPropertyName = "NUMERORIGHE";
            this.NUMERORIGHE.HeaderText = "NUMERO RIGHE";
            this.NUMERORIGHE.Name = "NUMERORIGHE";
            // 
            // RIFERIMENTO
            // 
            this.RIFERIMENTO.DataPropertyName = "RIFERIMENTO";
            this.RIFERIMENTO.FillWeight = 130F;
            this.RIFERIMENTO.HeaderText = "RIFERIMENTO";
            this.RIFERIMENTO.Name = "RIFERIMENTO";
            this.RIFERIMENTO.Width = 130;
            // 
            // rbMetalTop
            // 
            this.rbMetalTop.AutoSize = true;
            this.rbMetalTop.Location = new System.Drawing.Point(6, 15);
            this.rbMetalTop.Name = "rbMetalTop";
            this.rbMetalTop.Size = new System.Drawing.Size(46, 17);
            this.rbMetalTop.TabIndex = 14;
            this.rbMetalTop.Text = "Tutti";
            this.rbMetalTop.UseVisualStyleBackColor = true;
            // 
            // rbMetal
            // 
            this.rbMetal.AutoSize = true;
            this.rbMetal.Checked = true;
            this.rbMetal.Location = new System.Drawing.Point(6, 44);
            this.rbMetal.Name = "rbMetal";
            this.rbMetal.Size = new System.Drawing.Size(89, 17);
            this.rbMetal.TabIndex = 15;
            this.rbMetal.TabStop = true;
            this.rbMetal.Text = "METALPLUS";
            this.rbMetal.UseVisualStyleBackColor = true;
            // 
            // rbTop
            // 
            this.rbTop.AutoSize = true;
            this.rbTop.Location = new System.Drawing.Point(6, 73);
            this.rbTop.Name = "rbTop";
            this.rbTop.Size = new System.Drawing.Size(85, 17);
            this.rbTop.TabIndex = 16;
            this.rbTop.Text = "TOP FINISH";
            this.rbTop.UseVisualStyleBackColor = true;
            // 
            // grEstero
            // 
            this.grEstero.Controls.Add(this.rbSoloItalia);
            this.grEstero.Controls.Add(this.rbTutti);
            this.grEstero.Controls.Add(this.rbEstero);
            this.grEstero.Location = new System.Drawing.Point(459, 6);
            this.grEstero.Name = "grEstero";
            this.grEstero.Size = new System.Drawing.Size(119, 101);
            this.grEstero.TabIndex = 17;
            this.grEstero.TabStop = false;
            this.grEstero.Text = "Estero / Italia";
            // 
            // grAzienda
            // 
            this.grAzienda.Controls.Add(this.rbMetal);
            this.grAzienda.Controls.Add(this.rbMetalTop);
            this.grAzienda.Controls.Add(this.rbTop);
            this.grAzienda.Location = new System.Drawing.Point(281, 6);
            this.grAzienda.Name = "grAzienda";
            this.grAzienda.Size = new System.Drawing.Size(135, 101);
            this.grAzienda.TabIndex = 18;
            this.grAzienda.TabStop = false;
            this.grAzienda.Text = "Metalplus / Topfinish";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1573, 714);
            this.Controls.Add(this.grAzienda);
            this.Controls.Add(this.grEstero);
            this.Controls.Add(this.chkSelezionaTutto);
            this.Controls.Add(this.dgvRisultati);
            this.Controls.Add(this.btnCreaFiles);
            this.Controls.Add(this.btnTrova);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtAl);
            this.Controls.Add(this.dtDal);
            this.Name = "MainForm";
            this.Text = "Flusso fatture per Business Central";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRisultati)).EndInit();
            this.grEstero.ResumeLayout(false);
            this.grEstero.PerformLayout();
            this.grAzienda.ResumeLayout(false);
            this.grAzienda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreaFiles;
        private System.Windows.Forms.Button btnTrova;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtAl;
        private System.Windows.Forms.DateTimePicker dtDal;
        private System.Windows.Forms.DataGridView dgvRisultati;
        private System.Windows.Forms.RadioButton rbTutti;
        private System.Windows.Forms.RadioButton rbSoloItalia;
        private System.Windows.Forms.RadioButton rbEstero;
        private System.Windows.Forms.CheckBox chkSelezionaTutto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SELEZIONATA;
        private System.Windows.Forms.DataGridViewTextBoxColumn AZIENDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCUMENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATDOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTINAZIONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODICETIPOO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTABTIPOO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODICECAUTR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTABCAUTR;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDVENDITET;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAGIONESOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAZIONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERORIGHE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RIFERIMENTO;
        private System.Windows.Forms.RadioButton rbMetalTop;
        private System.Windows.Forms.RadioButton rbMetal;
        private System.Windows.Forms.RadioButton rbTop;
        private System.Windows.Forms.GroupBox grEstero;
        private System.Windows.Forms.GroupBox grAzienda;
    }
}

