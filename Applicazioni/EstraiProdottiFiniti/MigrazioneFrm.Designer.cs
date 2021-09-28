namespace EstraiProdottiFiniti
{
    partial class MigrazioneFrm
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
            this.tvDiBa = new System.Windows.Forms.TreeView();
            this.txtArticolo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCercaDiBa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVersioneDiBa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoteStd = new System.Windows.Forms.TextBox();
            this.chkInserisciTopFinish = new System.Windows.Forms.CheckBox();
            this.chkControlliQualita = new System.Windows.Forms.CheckBox();
            this.chkTest = new System.Windows.Forms.CheckBox();
            this.dgvNodi = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODELLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIZIONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPARTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FASE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDMAGAZZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANAGRAFICA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODICECICLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PEZZIORARI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OREPERIODO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITACONSUMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITAOCCORRENZA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContoLavoro = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MagazzinoClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMagazzino = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodi)).BeginInit();
            this.SuspendLayout();
            // 
            // tvDiBa
            // 
            this.tvDiBa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvDiBa.Location = new System.Drawing.Point(14, 80);
            this.tvDiBa.Name = "tvDiBa";
            this.tvDiBa.Size = new System.Drawing.Size(534, 838);
            this.tvDiBa.TabIndex = 0;
            this.tvDiBa.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDiBa_NodeMouseClick);
            // 
            // txtArticolo
            // 
            this.txtArticolo.Location = new System.Drawing.Point(82, 12);
            this.txtArticolo.Name = "txtArticolo";
            this.txtArticolo.Size = new System.Drawing.Size(238, 21);
            this.txtArticolo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Articolo";
            // 
            // btnCercaDiBa
            // 
            this.btnCercaDiBa.Location = new System.Drawing.Point(347, 10);
            this.btnCercaDiBa.Name = "btnCercaDiBa";
            this.btnCercaDiBa.Size = new System.Drawing.Size(152, 27);
            this.btnCercaDiBa.TabIndex = 3;
            this.btnCercaDiBa.Text = "Cerca DiBa";
            this.btnCercaDiBa.UseVisualStyleBackColor = true;
            this.btnCercaDiBa.Click += new System.EventHandler(this.btnCercaDiBa_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(550, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Versione";
            // 
            // txtVersioneDiBa
            // 
            this.txtVersioneDiBa.Location = new System.Drawing.Point(612, 12);
            this.txtVersioneDiBa.Name = "txtVersioneDiBa";
            this.txtVersioneDiBa.ReadOnly = true;
            this.txtVersioneDiBa.Size = new System.Drawing.Size(279, 21);
            this.txtVersioneDiBa.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(897, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Note Standard";
            // 
            // txtNoteStd
            // 
            this.txtNoteStd.Location = new System.Drawing.Point(988, 12);
            this.txtNoteStd.Name = "txtNoteStd";
            this.txtNoteStd.ReadOnly = true;
            this.txtNoteStd.Size = new System.Drawing.Size(577, 21);
            this.txtNoteStd.TabIndex = 7;
            // 
            // chkInserisciTopFinish
            // 
            this.chkInserisciTopFinish.AutoSize = true;
            this.chkInserisciTopFinish.Checked = true;
            this.chkInserisciTopFinish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInserisciTopFinish.Enabled = false;
            this.chkInserisciTopFinish.Location = new System.Drawing.Point(19, 53);
            this.chkInserisciTopFinish.Name = "chkInserisciTopFinish";
            this.chkInserisciTopFinish.Size = new System.Drawing.Size(173, 19);
            this.chkInserisciTopFinish.TabIndex = 8;
            this.chkInserisciTopFinish.Text = "Inserisci distinte Top Finish";
            this.chkInserisciTopFinish.UseVisualStyleBackColor = true;
            // 
            // chkControlliQualita
            // 
            this.chkControlliQualita.AutoSize = true;
            this.chkControlliQualita.Checked = true;
            this.chkControlliQualita.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkControlliQualita.Enabled = false;
            this.chkControlliQualita.Location = new System.Drawing.Point(211, 53);
            this.chkControlliQualita.Name = "chkControlliQualita";
            this.chkControlliQualita.Size = new System.Drawing.Size(157, 19);
            this.chkControlliQualita.TabIndex = 9;
            this.chkControlliQualita.Text = "Rimuovi controlli qualità";
            this.chkControlliQualita.UseVisualStyleBackColor = true;
            // 
            // chkTest
            // 
            this.chkTest.AutoSize = true;
            this.chkTest.Checked = true;
            this.chkTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTest.ForeColor = System.Drawing.Color.Red;
            this.chkTest.Location = new System.Drawing.Point(1170, 49);
            this.chkTest.Name = "chkTest";
            this.chkTest.Size = new System.Drawing.Size(191, 24);
            this.chkTest.TabIndex = 12;
            this.chkTest.Text = "AMBIENTE DI TEST";
            this.chkTest.UseVisualStyleBackColor = true;
            // 
            // dgvNodi
            // 
            this.dgvNodi.AllowUserToAddRows = false;
            this.dgvNodi.AllowUserToDeleteRows = false;
            this.dgvNodi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNodi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNodi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MODELLO,
            this.DESCRIZIONE,
            this.REPARTO,
            this.FASE,
            this.IDMAGAZZ,
            this.ANAGRAFICA,
            this.CODICECICLO,
            this.PEZZIORARI,
            this.OREPERIODO,
            this.QUANTITA,
            this.QUANTITACONSUMO,
            this.QUANTITAOCCORRENZA,
            this.ContoLavoro,
            this.MagazzinoClm});
            this.dgvNodi.Location = new System.Drawing.Point(594, 80);
            this.dgvNodi.Name = "dgvNodi";
            this.dgvNodi.ReadOnly = true;
            this.dgvNodi.Size = new System.Drawing.Size(1088, 667);
            this.dgvNodi.TabIndex = 13;
            this.dgvNodi.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNodi_RowEnter);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 40F;
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 40;
            // 
            // MODELLO
            // 
            this.MODELLO.DataPropertyName = "Modello";
            this.MODELLO.FillWeight = 80F;
            this.MODELLO.Frozen = true;
            this.MODELLO.HeaderText = "MODELLO";
            this.MODELLO.Name = "MODELLO";
            this.MODELLO.ReadOnly = true;
            this.MODELLO.Width = 80;
            // 
            // DESCRIZIONE
            // 
            this.DESCRIZIONE.DataPropertyName = "DescrizioneArticolo";
            this.DESCRIZIONE.FillWeight = 80F;
            this.DESCRIZIONE.Frozen = true;
            this.DESCRIZIONE.HeaderText = "DESCRIZIONE";
            this.DESCRIZIONE.Name = "DESCRIZIONE";
            this.DESCRIZIONE.ReadOnly = true;
            this.DESCRIZIONE.Width = 80;
            // 
            // REPARTO
            // 
            this.REPARTO.DataPropertyName = "Reparto";
            this.REPARTO.FillWeight = 80F;
            this.REPARTO.Frozen = true;
            this.REPARTO.HeaderText = "REPARTO";
            this.REPARTO.Name = "REPARTO";
            this.REPARTO.ReadOnly = true;
            this.REPARTO.Width = 80;
            // 
            // FASE
            // 
            this.FASE.DataPropertyName = "Fase";
            this.FASE.FillWeight = 80F;
            this.FASE.Frozen = true;
            this.FASE.HeaderText = "FASE";
            this.FASE.Name = "FASE";
            this.FASE.ReadOnly = true;
            this.FASE.Width = 80;
            // 
            // IDMAGAZZ
            // 
            this.IDMAGAZZ.DataPropertyName = "IDMAGAZZ";
            this.IDMAGAZZ.FillWeight = 80F;
            this.IDMAGAZZ.Frozen = true;
            this.IDMAGAZZ.HeaderText = "IDMAGAZZ";
            this.IDMAGAZZ.Name = "IDMAGAZZ";
            this.IDMAGAZZ.ReadOnly = true;
            this.IDMAGAZZ.Width = 80;
            // 
            // ANAGRAFICA
            // 
            this.ANAGRAFICA.DataPropertyName = "Anagrafica";
            this.ANAGRAFICA.FillWeight = 160F;
            this.ANAGRAFICA.Frozen = true;
            this.ANAGRAFICA.HeaderText = "ANAGRAFICA";
            this.ANAGRAFICA.Name = "ANAGRAFICA";
            this.ANAGRAFICA.ReadOnly = true;
            this.ANAGRAFICA.Width = 160;
            // 
            // CODICECICLO
            // 
            this.CODICECICLO.DataPropertyName = "CodiceCiclo";
            this.CODICECICLO.FillWeight = 80F;
            this.CODICECICLO.Frozen = true;
            this.CODICECICLO.HeaderText = "CODICE CICLO";
            this.CODICECICLO.Name = "CODICECICLO";
            this.CODICECICLO.ReadOnly = true;
            this.CODICECICLO.Width = 80;
            // 
            // PEZZIORARI
            // 
            this.PEZZIORARI.DataPropertyName = "PezziOrari";
            this.PEZZIORARI.Frozen = true;
            this.PEZZIORARI.HeaderText = "PEZZI ORARI";
            this.PEZZIORARI.Name = "PEZZIORARI";
            this.PEZZIORARI.ReadOnly = true;
            this.PEZZIORARI.Width = 50;
            // 
            // OREPERIODO
            // 
            this.OREPERIODO.DataPropertyName = "OrePeriodo";
            this.OREPERIODO.FillWeight = 50F;
            this.OREPERIODO.Frozen = true;
            this.OREPERIODO.HeaderText = "ORE PERIODO";
            this.OREPERIODO.Name = "OREPERIODO";
            this.OREPERIODO.ReadOnly = true;
            this.OREPERIODO.Width = 50;
            // 
            // QUANTITA
            // 
            this.QUANTITA.DataPropertyName = "Quantita";
            this.QUANTITA.Frozen = true;
            this.QUANTITA.HeaderText = "QUANTITA";
            this.QUANTITA.Name = "QUANTITA";
            this.QUANTITA.ReadOnly = true;
            // 
            // QUANTITACONSUMO
            // 
            this.QUANTITACONSUMO.DataPropertyName = "QuantitaConsumo";
            this.QUANTITACONSUMO.Frozen = true;
            this.QUANTITACONSUMO.HeaderText = "QUANTITA CONSUMO";
            this.QUANTITACONSUMO.Name = "QUANTITACONSUMO";
            this.QUANTITACONSUMO.ReadOnly = true;
            // 
            // QUANTITAOCCORRENZA
            // 
            this.QUANTITAOCCORRENZA.DataPropertyName = "QualitaOccorrenza";
            this.QUANTITAOCCORRENZA.Frozen = true;
            this.QUANTITAOCCORRENZA.HeaderText = "QUANTITA OCCORRENZA";
            this.QUANTITAOCCORRENZA.Name = "QUANTITAOCCORRENZA";
            this.QUANTITAOCCORRENZA.ReadOnly = true;
            // 
            // ContoLavoro
            // 
            this.ContoLavoro.DataPropertyName = "ContoLavoro";
            this.ContoLavoro.Frozen = true;
            this.ContoLavoro.HeaderText = "ContoLavoro";
            this.ContoLavoro.Name = "ContoLavoro";
            this.ContoLavoro.ReadOnly = true;
            this.ContoLavoro.Visible = false;
            // 
            // MagazzinoClm
            // 
            this.MagazzinoClm.DataPropertyName = "ListaMagazzino";
            this.MagazzinoClm.FillWeight = 250F;
            this.MagazzinoClm.Frozen = true;
            this.MagazzinoClm.HeaderText = "Magazzino";
            this.MagazzinoClm.Name = "MagazzinoClm";
            this.MagazzinoClm.ReadOnly = true;
            this.MagazzinoClm.Width = 250;
            // 
            // txtMagazzino
            // 
            this.txtMagazzino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMagazzino.Location = new System.Drawing.Point(594, 779);
            this.txtMagazzino.Multiline = true;
            this.txtMagazzino.Name = "txtMagazzino";
            this.txtMagazzino.Size = new System.Drawing.Size(1088, 119);
            this.txtMagazzino.TabIndex = 14;
            // 
            // MigrazioneFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1694, 932);
            this.Controls.Add(this.txtMagazzino);
            this.Controls.Add(this.dgvNodi);
            this.Controls.Add(this.chkTest);
            this.Controls.Add(this.chkControlliQualita);
            this.Controls.Add(this.chkInserisciTopFinish);
            this.Controls.Add(this.txtNoteStd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVersioneDiBa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCercaDiBa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArticolo);
            this.Controls.Add(this.tvDiBa);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MigrazioneFrm";
            this.Text = "Migrazione";
            this.Load += new System.EventHandler(this.EstraiProdottoFinito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvDiBa;
        private System.Windows.Forms.TextBox txtArticolo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCercaDiBa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVersioneDiBa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoteStd;
        private System.Windows.Forms.CheckBox chkInserisciTopFinish;
        private System.Windows.Forms.CheckBox chkControlliQualita;
        private System.Windows.Forms.CheckBox chkTest;
        private System.Windows.Forms.DataGridView dgvNodi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODELLO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIZIONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn REPARTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FASE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMAGAZZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANAGRAFICA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODICECICLO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PEZZIORARI;
        private System.Windows.Forms.DataGridViewTextBoxColumn OREPERIODO;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITA;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITACONSUMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITAOCCORRENZA;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ContoLavoro;
        private System.Windows.Forms.DataGridViewTextBoxColumn MagazzinoClm;
        private System.Windows.Forms.TextBox txtMagazzino;
    }
}

