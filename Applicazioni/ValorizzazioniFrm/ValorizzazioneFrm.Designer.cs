namespace ValorizzazioniFrm
{
    partial class ValorizzazioneFrm
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
            this.ddlInventario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblCostoMax = new System.Windows.Forms.Label();
            this.lblCostoCur = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTempoCosto = new System.Windows.Forms.Label();
            this.prgCosto = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.chkConsideraTutteLeFasi = new System.Windows.Forms.CheckBox();
            this.chkVenditaTopFinish = new System.Windows.Forms.CheckBox();
            this.chkUsaDiBaNonDefault = new System.Windows.Forms.CheckBox();
            this.chkProdottiFiniti = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDataFine = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFineListiniCostoGalvanica = new System.Windows.Forms.DateTimePicker();
            this.btnCalcolaCostiGalvanica = new System.Windows.Forms.Button();
            this.chkInventario2020 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlInventario
            // 
            this.ddlInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlInventario.FormattingEnabled = true;
            this.ddlInventario.Location = new System.Drawing.Point(106, 29);
            this.ddlInventario.Name = "ddlInventario";
            this.ddlInventario.Size = new System.Drawing.Size(289, 24);
            this.ddlInventario.TabIndex = 0;
            this.ddlInventario.SelectedIndexChanged += new System.EventHandler(this.ddlInventario_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inventario";
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.Location = new System.Drawing.Point(15, 334);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(755, 366);
            this.txtNote.TabIndex = 5;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(440, 29);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Elabora";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblCostoMax
            // 
            this.lblCostoMax.AutoSize = true;
            this.lblCostoMax.Location = new System.Drawing.Point(610, 135);
            this.lblCostoMax.Name = "lblCostoMax";
            this.lblCostoMax.Size = new System.Drawing.Size(33, 16);
            this.lblCostoMax.TabIndex = 10;
            this.lblCostoMax.Text = "max";
            // 
            // lblCostoCur
            // 
            this.lblCostoCur.AutoSize = true;
            this.lblCostoCur.Location = new System.Drawing.Point(378, 135);
            this.lblCostoCur.Name = "lblCostoCur";
            this.lblCostoCur.Size = new System.Drawing.Size(26, 16);
            this.lblCostoCur.TabIndex = 11;
            this.lblCostoCur.Text = "cur";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "1";
            // 
            // lblTempoCosto
            // 
            this.lblTempoCosto.AutoSize = true;
            this.lblTempoCosto.Location = new System.Drawing.Point(685, 157);
            this.lblTempoCosto.Name = "lblTempoCosto";
            this.lblTempoCosto.Size = new System.Drawing.Size(45, 16);
            this.lblTempoCosto.TabIndex = 9;
            this.lblTempoCosto.Text = "label3";
            // 
            // prgCosto
            // 
            this.prgCosto.Location = new System.Drawing.Point(158, 154);
            this.prgCosto.Name = "prgCosto";
            this.prgCosto.Size = new System.Drawing.Size(485, 23);
            this.prgCosto.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Calcola costi";
            // 
            // chkConsideraTutteLeFasi
            // 
            this.chkConsideraTutteLeFasi.AutoSize = true;
            this.chkConsideraTutteLeFasi.Checked = true;
            this.chkConsideraTutteLeFasi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConsideraTutteLeFasi.Location = new System.Drawing.Point(28, 218);
            this.chkConsideraTutteLeFasi.Name = "chkConsideraTutteLeFasi";
            this.chkConsideraTutteLeFasi.Size = new System.Drawing.Size(262, 20);
            this.chkConsideraTutteLeFasi.TabIndex = 13;
            this.chkConsideraTutteLeFasi.Text = "Considera anche le fasi escuse da RVL";
            this.chkConsideraTutteLeFasi.UseVisualStyleBackColor = true;
            // 
            // chkVenditaTopFinish
            // 
            this.chkVenditaTopFinish.AutoSize = true;
            this.chkVenditaTopFinish.Checked = true;
            this.chkVenditaTopFinish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVenditaTopFinish.Location = new System.Drawing.Point(28, 248);
            this.chkVenditaTopFinish.Name = "chkVenditaTopFinish";
            this.chkVenditaTopFinish.Size = new System.Drawing.Size(274, 20);
            this.chkVenditaTopFinish.TabIndex = 13;
            this.chkVenditaTopFinish.Text = "Considera anche listini vendita Top Finish";
            this.chkVenditaTopFinish.UseVisualStyleBackColor = true;
            // 
            // chkUsaDiBaNonDefault
            // 
            this.chkUsaDiBaNonDefault.AutoSize = true;
            this.chkUsaDiBaNonDefault.Checked = true;
            this.chkUsaDiBaNonDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUsaDiBaNonDefault.Location = new System.Drawing.Point(28, 278);
            this.chkUsaDiBaNonDefault.Name = "chkUsaDiBaNonDefault";
            this.chkUsaDiBaNonDefault.Size = new System.Drawing.Size(352, 20);
            this.chkUsaDiBaNonDefault.TabIndex = 14;
            this.chkUsaDiBaNonDefault.Text = "Usa anche DiBa non di default per articoli da inventario";
            this.chkUsaDiBaNonDefault.UseVisualStyleBackColor = true;
            // 
            // chkProdottiFiniti
            // 
            this.chkProdottiFiniti.AutoSize = true;
            this.chkProdottiFiniti.Location = new System.Drawing.Point(21, 30);
            this.chkProdottiFiniti.Name = "chkProdottiFiniti";
            this.chkProdottiFiniti.Size = new System.Drawing.Size(131, 20);
            this.chkProdottiFiniti.TabIndex = 13;
            this.chkProdottiFiniti.Text = "Tutti i prodotti finiti";
            this.chkProdottiFiniti.UseVisualStyleBackColor = true;
            this.chkProdottiFiniti.CheckedChanged += new System.EventHandler(this.chkProdottiFiniti_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtDataFine);
            this.groupBox1.Controls.Add(this.chkProdottiFiniti);
            this.groupBox1.Location = new System.Drawing.Point(552, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 128);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prodotti finiti";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Data fine periodo per i listini";
            // 
            // dtDataFine
            // 
            this.dtDataFine.Location = new System.Drawing.Point(12, 91);
            this.dtDataFine.Name = "dtDataFine";
            this.dtDataFine.Size = new System.Drawing.Size(200, 22);
            this.dtDataFine.TabIndex = 14;
            this.dtDataFine.Value = new System.DateTime(2019, 12, 31, 0, 0, 0, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtFineListiniCostoGalvanica);
            this.groupBox2.Controls.Add(this.btnCalcolaCostiGalvanica);
            this.groupBox2.Location = new System.Drawing.Point(552, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 128);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Costi galvanica";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Data fine periodo per i listini";
            // 
            // dtFineListiniCostoGalvanica
            // 
            this.dtFineListiniCostoGalvanica.Location = new System.Drawing.Point(14, 55);
            this.dtFineListiniCostoGalvanica.Name = "dtFineListiniCostoGalvanica";
            this.dtFineListiniCostoGalvanica.Size = new System.Drawing.Size(200, 22);
            this.dtFineListiniCostoGalvanica.TabIndex = 16;
            this.dtFineListiniCostoGalvanica.Value = new System.DateTime(2019, 12, 31, 0, 0, 0, 0);
            // 
            // btnCalcolaCostiGalvanica
            // 
            this.btnCalcolaCostiGalvanica.Location = new System.Drawing.Point(12, 82);
            this.btnCalcolaCostiGalvanica.Name = "btnCalcolaCostiGalvanica";
            this.btnCalcolaCostiGalvanica.Size = new System.Drawing.Size(200, 39);
            this.btnCalcolaCostiGalvanica.TabIndex = 0;
            this.btnCalcolaCostiGalvanica.Text = "Calcola costi galvanica";
            this.btnCalcolaCostiGalvanica.UseVisualStyleBackColor = true;
            this.btnCalcolaCostiGalvanica.Click += new System.EventHandler(this.btnCalcolaCostiGalvanica_Click);
            // 
            // chkInventario2020
            // 
            this.chkInventario2020.AutoSize = true;
            this.chkInventario2020.Checked = true;
            this.chkInventario2020.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInventario2020.Location = new System.Drawing.Point(28, 308);
            this.chkInventario2020.Name = "chkInventario2020";
            this.chkInventario2020.Size = new System.Drawing.Size(144, 20);
            this.chkInventario2020.TabIndex = 17;
            this.chkInventario2020.Text = "Usa inventario 2020";
            this.chkInventario2020.UseVisualStyleBackColor = true;
            // 
            // ValorizzazioneFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 712);
            this.Controls.Add(this.chkInventario2020);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkUsaDiBaNonDefault);
            this.Controls.Add(this.chkVenditaTopFinish);
            this.Controls.Add(this.chkConsideraTutteLeFasi);
            this.Controls.Add(this.lblCostoMax);
            this.Controls.Add(this.lblCostoCur);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTempoCosto);
            this.Controls.Add(this.prgCosto);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlInventario);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ValorizzazioneFrm";
            this.Text = "Valorizzazione";
            this.Load += new System.EventHandler(this.ValorizzazioneFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlInventario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblCostoMax;
        private System.Windows.Forms.Label lblCostoCur;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTempoCosto;
        private System.Windows.Forms.ProgressBar prgCosto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkConsideraTutteLeFasi;
        private System.Windows.Forms.CheckBox chkVenditaTopFinish;
        private System.Windows.Forms.CheckBox chkUsaDiBaNonDefault;
        private System.Windows.Forms.CheckBox chkProdottiFiniti;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDataFine;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCalcolaCostiGalvanica;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFineListiniCostoGalvanica;
        private System.Windows.Forms.CheckBox chkInventario2020;
    }
}

