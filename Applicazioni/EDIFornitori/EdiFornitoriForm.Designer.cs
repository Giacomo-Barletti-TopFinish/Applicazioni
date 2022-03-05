namespace EDIFornitori
{
    partial class EdiFornitoriForm
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
            this.rbMetal = new System.Windows.Forms.RadioButton();
            this.rbTopFinish = new System.Windows.Forms.RadioButton();
            this.dtDal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtAl = new System.Windows.Forms.DateTimePicker();
            this.btnTrova = new System.Windows.Forms.Button();
            this.dgvRisultati = new System.Windows.Forms.DataGridView();
            this.SELEZIONATA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DOCUMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATDOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCESSORISTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTINAZIONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODICETIPOO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTABTIPOO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODICECAUTR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTABCAUTR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDVENDITET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAGIONESOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERORIGHE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RIFERIMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCreaFiles = new System.Windows.Forms.Button();
            this.rbRVL = new System.Windows.Forms.RadioButton();
            this.rbBusinessCentral = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRisultati)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbMetal
            // 
            this.rbMetal.AutoSize = true;
            this.rbMetal.Checked = true;
            this.rbMetal.Location = new System.Drawing.Point(12, 25);
            this.rbMetal.Name = "rbMetal";
            this.rbMetal.Size = new System.Drawing.Size(134, 17);
            this.rbMetal.TabIndex = 0;
            this.rbMetal.TabStop = true;
            this.rbMetal.Text = "METALPLUS (492145)";
            this.rbMetal.UseVisualStyleBackColor = true;
            // 
            // rbTopFinish
            // 
            this.rbTopFinish.AutoSize = true;
            this.rbTopFinish.Location = new System.Drawing.Point(12, 58);
            this.rbTopFinish.Name = "rbTopFinish";
            this.rbTopFinish.Size = new System.Drawing.Size(130, 17);
            this.rbTopFinish.TabIndex = 0;
            this.rbTopFinish.Text = "TOP FINISH (465861)";
            this.rbTopFinish.UseVisualStyleBackColor = true;
            // 
            // dtDal
            // 
            this.dtDal.Location = new System.Drawing.Point(220, 23);
            this.dtDal.Name = "dtDal";
            this.dtDal.Size = new System.Drawing.Size(200, 20);
            this.dtDal.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "AL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "DAL";
            // 
            // dtAl
            // 
            this.dtAl.Location = new System.Drawing.Point(220, 56);
            this.dtAl.Name = "dtAl";
            this.dtAl.Size = new System.Drawing.Size(200, 20);
            this.dtAl.TabIndex = 2;
            // 
            // btnTrova
            // 
            this.btnTrova.Location = new System.Drawing.Point(464, 27);
            this.btnTrova.Name = "btnTrova";
            this.btnTrova.Size = new System.Drawing.Size(92, 48);
            this.btnTrova.TabIndex = 3;
            this.btnTrova.Text = "Trova";
            this.btnTrova.UseVisualStyleBackColor = true;
            this.btnTrova.Click += new System.EventHandler(this.btnTrova_Click);
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
            this.SELEZIONATA,
            this.DOCUMENTO,
            this.NUMERO,
            this.DATDOC,
            this.ACCESSORISTA,
            this.DESTINAZIONE,
            this.CODICETIPOO,
            this.DESTABTIPOO,
            this.CODICECAUTR,
            this.DESTABCAUTR,
            this.IDVENDITET,
            this.RAGIONESOC,
            this.NUMERORIGHE,
            this.RIFERIMENTO});
            this.dgvRisultati.Location = new System.Drawing.Point(12, 96);
            this.dgvRisultati.Name = "dgvRisultati";
            this.dgvRisultati.Size = new System.Drawing.Size(1626, 591);
            this.dgvRisultati.TabIndex = 4;
            // 
            // SELEZIONATA
            // 
            this.SELEZIONATA.FillWeight = 70F;
            this.SELEZIONATA.HeaderText = "";
            this.SELEZIONATA.Name = "SELEZIONATA";
            this.SELEZIONATA.Width = 70;
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
            // ACCESSORISTA
            // 
            this.ACCESSORISTA.DataPropertyName = "ACCESSORISTA";
            this.ACCESSORISTA.FillWeight = 80F;
            this.ACCESSORISTA.HeaderText = "ACCESSORISTA";
            this.ACCESSORISTA.Name = "ACCESSORISTA";
            this.ACCESSORISTA.Width = 80;
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
            // btnCreaFiles
            // 
            this.btnCreaFiles.Location = new System.Drawing.Point(634, 28);
            this.btnCreaFiles.Name = "btnCreaFiles";
            this.btnCreaFiles.Size = new System.Drawing.Size(92, 48);
            this.btnCreaFiles.TabIndex = 4;
            this.btnCreaFiles.Text = "Crea files";
            this.btnCreaFiles.UseVisualStyleBackColor = true;
            this.btnCreaFiles.Click += new System.EventHandler(this.btnCreaFiles_Click);
            // 
            // rbRVL
            // 
            this.rbRVL.AutoSize = true;
            this.rbRVL.Location = new System.Drawing.Point(11, 31);
            this.rbRVL.Name = "rbRVL";
            this.rbRVL.Size = new System.Drawing.Size(46, 17);
            this.rbRVL.TabIndex = 5;
            this.rbRVL.Text = "RVL";
            this.rbRVL.UseVisualStyleBackColor = true;
            // 
            // rbBusinessCentral
            // 
            this.rbBusinessCentral.AutoSize = true;
            this.rbBusinessCentral.Checked = true;
            this.rbBusinessCentral.Location = new System.Drawing.Point(86, 31);
            this.rbBusinessCentral.Name = "rbBusinessCentral";
            this.rbBusinessCentral.Size = new System.Drawing.Size(103, 17);
            this.rbBusinessCentral.TabIndex = 5;
            this.rbBusinessCentral.TabStop = true;
            this.rbBusinessCentral.Text = "Business Central";
            this.rbBusinessCentral.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbRVL);
            this.groupBox1.Controls.Add(this.rbBusinessCentral);
            this.groupBox1.Location = new System.Drawing.Point(751, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 73);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ambiente";
            // 
            // EdiFornitoriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1650, 689);
            this.Controls.Add(this.dgvRisultati);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCreaFiles);
            this.Controls.Add(this.btnTrova);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtAl);
            this.Controls.Add(this.dtDal);
            this.Controls.Add(this.rbTopFinish);
            this.Controls.Add(this.rbMetal);
            this.Name = "EdiFornitoriForm";
            this.Text = "EDI Fornitori";
            this.Load += new System.EventHandler(this.EdiFornitoriForm_Load);
            this.Shown += new System.EventHandler(this.EdiFornitoriForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRisultati)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbMetal;
        private System.Windows.Forms.RadioButton rbTopFinish;
        private System.Windows.Forms.DateTimePicker dtDal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtAl;
        private System.Windows.Forms.Button btnTrova;
        private System.Windows.Forms.DataGridView dgvRisultati;
        private System.Windows.Forms.Button btnCreaFiles;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SELEZIONATA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCUMENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATDOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCESSORISTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTINAZIONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODICETIPOO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTABTIPOO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODICECAUTR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTABCAUTR;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDVENDITET;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAGIONESOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERORIGHE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RIFERIMENTO;
        private System.Windows.Forms.RadioButton rbRVL;
        private System.Windows.Forms.RadioButton rbBusinessCentral;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

