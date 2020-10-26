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
            this.btnCreaFiles = new System.Windows.Forms.Button();
            this.SELEZIONATA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CODICETIPOO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTABTIPOO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODICECAUTR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTABCAUTR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDVENDITET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATDOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAGIONESOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERORIGHE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RIFERIMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRisultati)).BeginInit();
            this.SuspendLayout();
            // 
            // rbMetal
            // 
            this.rbMetal.AutoSize = true;
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
            this.rbTopFinish.TabStop = true;
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
            this.dtAl.TabIndex = 1;
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
            this.CODICETIPOO,
            this.DESTABTIPOO,
            this.CODICECAUTR,
            this.DESTABCAUTR,
            this.IDVENDITET,
            this.DATDOC,
            this.RAGIONESOC,
            this.NUMERORIGHE,
            this.RIFERIMENTO});
            this.dgvRisultati.Location = new System.Drawing.Point(12, 96);
            this.dgvRisultati.Name = "dgvRisultati";
            this.dgvRisultati.Size = new System.Drawing.Size(1152, 591);
            this.dgvRisultati.TabIndex = 4;
            // 
            // btnCreaFiles
            // 
            this.btnCreaFiles.Location = new System.Drawing.Point(634, 28);
            this.btnCreaFiles.Name = "btnCreaFiles";
            this.btnCreaFiles.Size = new System.Drawing.Size(92, 48);
            this.btnCreaFiles.TabIndex = 3;
            this.btnCreaFiles.Text = "Crea files";
            this.btnCreaFiles.UseVisualStyleBackColor = true;
            this.btnCreaFiles.Click += new System.EventHandler(this.btnCreaFiles_Click);
            // 
            // SELEZIONATA
            // 
            this.SELEZIONATA.FillWeight = 70F;
            this.SELEZIONATA.HeaderText = "";
            this.SELEZIONATA.Name = "SELEZIONATA";
            this.SELEZIONATA.Width = 70;
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
            // DATDOC
            // 
            this.DATDOC.DataPropertyName = "DATDOC";
            this.DATDOC.HeaderText = "DATA DOC";
            this.DATDOC.Name = "DATDOC";
            // 
            // RAGIONESOC
            // 
            this.RAGIONESOC.DataPropertyName = "RAGIONESOC";
            this.RAGIONESOC.FillWeight = 150F;
            this.RAGIONESOC.HeaderText = "DESTINAZIONE";
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
            // EdiFornitoriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 689);
            this.Controls.Add(this.dgvRisultati);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvRisultati)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn CODICETIPOO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTABTIPOO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODICECAUTR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTABCAUTR;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDVENDITET;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATDOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAGIONESOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERORIGHE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RIFERIMENTO;
    }
}

