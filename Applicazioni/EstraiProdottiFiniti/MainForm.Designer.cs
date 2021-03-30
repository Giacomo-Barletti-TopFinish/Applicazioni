namespace EstraiProdottiFiniti
{
    partial class EstraiProdottoFinito
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
            this.dgvNodi = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODELLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPARTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FASE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANAGRAFICA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODICECICLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PEZZIORARI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FORNITOCOMMITTENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLLEGAMENTODIBA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLLEGAMENTOCICLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPERFICIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOTESTANDARD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOTETECNICHE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtMsgAnagrafiche = new System.Windows.Forms.TextBox();
            this.btnSalvaAnagrafiche = new System.Windows.Forms.Button();
            this.btnVerificaAnagrafiche = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtMsgCicli = new System.Windows.Forms.TextBox();
            this.btnSalvaCicli = new System.Windows.Forms.Button();
            this.btnVerificaCicli = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtMsgDistinte = new System.Windows.Forms.TextBox();
            this.btnSalvaDistinte = new System.Windows.Forms.Button();
            this.btnVerificaDistinte = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVersioneDiBa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoteStd = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodi)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvDiBa
            // 
            this.tvDiBa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvDiBa.Location = new System.Drawing.Point(12, 69);
            this.tvDiBa.Name = "tvDiBa";
            this.tvDiBa.Size = new System.Drawing.Size(458, 727);
            this.tvDiBa.TabIndex = 0;
            this.tvDiBa.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDiBa_NodeMouseClick);
            // 
            // txtArticolo
            // 
            this.txtArticolo.Location = new System.Drawing.Point(88, 10);
            this.txtArticolo.Name = "txtArticolo";
            this.txtArticolo.Size = new System.Drawing.Size(205, 20);
            this.txtArticolo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Articolo";
            // 
            // btnCercaDiBa
            // 
            this.btnCercaDiBa.Location = new System.Drawing.Point(331, 9);
            this.btnCercaDiBa.Name = "btnCercaDiBa";
            this.btnCercaDiBa.Size = new System.Drawing.Size(130, 23);
            this.btnCercaDiBa.TabIndex = 3;
            this.btnCercaDiBa.Text = "Cerca DiBa";
            this.btnCercaDiBa.UseVisualStyleBackColor = true;
            this.btnCercaDiBa.Click += new System.EventHandler(this.btnCercaDiBa_Click);
            // 
            // dgvNodi
            // 
            this.dgvNodi.AllowUserToAddRows = false;
            this.dgvNodi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNodi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MODELLO,
            this.REPARTO,
            this.FASE,
            this.QUANTITA,
            this.ANAGRAFICA,
            this.CODICECICLO,
            this.PEZZIORARI,
            this.FORNITOCOMMITTENTE,
            this.COLLEGAMENTODIBA,
            this.COLLEGAMENTOCICLO,
            this.PESO,
            this.SUPERFICIE,
            this.NOTESTANDARD,
            this.NOTETECNICHE});
            this.dgvNodi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNodi.Location = new System.Drawing.Point(3, 3);
            this.dgvNodi.Name = "dgvNodi";
            this.dgvNodi.Size = new System.Drawing.Size(931, 712);
            this.dgvNodi.TabIndex = 4;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // MODELLO
            // 
            this.MODELLO.DataPropertyName = "Modello";
            this.MODELLO.Frozen = true;
            this.MODELLO.HeaderText = "MODELLO";
            this.MODELLO.Name = "MODELLO";
            // 
            // REPARTO
            // 
            this.REPARTO.DataPropertyName = "Reparto";
            this.REPARTO.Frozen = true;
            this.REPARTO.HeaderText = "REPARTO";
            this.REPARTO.Name = "REPARTO";
            this.REPARTO.ReadOnly = true;
            // 
            // FASE
            // 
            this.FASE.DataPropertyName = "Fase";
            this.FASE.Frozen = true;
            this.FASE.HeaderText = "FASE";
            this.FASE.Name = "FASE";
            this.FASE.ReadOnly = true;
            // 
            // QUANTITA
            // 
            this.QUANTITA.DataPropertyName = "Quantita";
            this.QUANTITA.HeaderText = "QUANTITA";
            this.QUANTITA.Name = "QUANTITA";
            this.QUANTITA.ReadOnly = true;
            // 
            // ANAGRAFICA
            // 
            this.ANAGRAFICA.DataPropertyName = "Anagrafica";
            this.ANAGRAFICA.HeaderText = "ANAGRAFICA";
            this.ANAGRAFICA.Name = "ANAGRAFICA";
            // 
            // CODICECICLO
            // 
            this.CODICECICLO.DataPropertyName = "CodiceCiclo";
            this.CODICECICLO.HeaderText = "CODICE CICLO";
            this.CODICECICLO.Name = "CODICECICLO";
            // 
            // PEZZIORARI
            // 
            this.PEZZIORARI.DataPropertyName = "PezziOrari";
            this.PEZZIORARI.HeaderText = "PEZZI ORARI";
            this.PEZZIORARI.Name = "PEZZIORARI";
            this.PEZZIORARI.Width = 50;
            // 
            // FORNITOCOMMITTENTE
            // 
            this.FORNITOCOMMITTENTE.DataPropertyName = "FornitoDaCommittente";
            this.FORNITOCOMMITTENTE.HeaderText = "FORN. COMMIT.";
            this.FORNITOCOMMITTENTE.Name = "FORNITOCOMMITTENTE";
            this.FORNITOCOMMITTENTE.ReadOnly = true;
            // 
            // COLLEGAMENTODIBA
            // 
            this.COLLEGAMENTODIBA.DataPropertyName = "CollegamentoDiba";
            this.COLLEGAMENTODIBA.HeaderText = "COLLEGAMENTO DISTINTA";
            this.COLLEGAMENTODIBA.Name = "COLLEGAMENTODIBA";
            this.COLLEGAMENTODIBA.Width = 80;
            // 
            // COLLEGAMENTOCICLO
            // 
            this.COLLEGAMENTOCICLO.DataPropertyName = "CollegamentoCiclo";
            this.COLLEGAMENTOCICLO.HeaderText = "COLLEGAMENTO CICLO";
            this.COLLEGAMENTOCICLO.Name = "COLLEGAMENTOCICLO";
            this.COLLEGAMENTOCICLO.Width = 80;
            // 
            // PESO
            // 
            this.PESO.DataPropertyName = "Peso";
            this.PESO.HeaderText = "PESO";
            this.PESO.Name = "PESO";
            this.PESO.ReadOnly = true;
            this.PESO.Width = 50;
            // 
            // SUPERFICIE
            // 
            this.SUPERFICIE.DataPropertyName = "Superficie";
            this.SUPERFICIE.HeaderText = "SUPERFICIE";
            this.SUPERFICIE.Name = "SUPERFICIE";
            this.SUPERFICIE.ReadOnly = true;
            this.SUPERFICIE.Width = 50;
            // 
            // NOTESTANDARD
            // 
            this.NOTESTANDARD.DataPropertyName = "NoteStandard";
            this.NOTESTANDARD.HeaderText = "NOTE STANDARD";
            this.NOTESTANDARD.Name = "NOTESTANDARD";
            this.NOTESTANDARD.ReadOnly = true;
            this.NOTESTANDARD.Width = 200;
            // 
            // NOTETECNICHE
            // 
            this.NOTETECNICHE.DataPropertyName = "NoteTecniche";
            this.NOTETECNICHE.HeaderText = "NOTE TECNICHE";
            this.NOTETECNICHE.Name = "NOTETECNICHE";
            this.NOTETECNICHE.ReadOnly = true;
            this.NOTETECNICHE.Width = 200;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(495, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(945, 746);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvNodi);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(937, 718);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Distinta";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtMsgAnagrafiche);
            this.tabPage4.Controls.Add(this.btnSalvaAnagrafiche);
            this.tabPage4.Controls.Add(this.btnVerificaAnagrafiche);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(937, 718);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Anagrafiche";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtMsgAnagrafiche
            // 
            this.txtMsgAnagrafiche.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsgAnagrafiche.Location = new System.Drawing.Point(17, 91);
            this.txtMsgAnagrafiche.Multiline = true;
            this.txtMsgAnagrafiche.Name = "txtMsgAnagrafiche";
            this.txtMsgAnagrafiche.ReadOnly = true;
            this.txtMsgAnagrafiche.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgAnagrafiche.Size = new System.Drawing.Size(898, 600);
            this.txtMsgAnagrafiche.TabIndex = 1;
            // 
            // btnSalvaAnagrafiche
            // 
            this.btnSalvaAnagrafiche.Enabled = false;
            this.btnSalvaAnagrafiche.Location = new System.Drawing.Point(187, 16);
            this.btnSalvaAnagrafiche.Name = "btnSalvaAnagrafiche";
            this.btnSalvaAnagrafiche.Size = new System.Drawing.Size(138, 33);
            this.btnSalvaAnagrafiche.TabIndex = 0;
            this.btnSalvaAnagrafiche.Text = "Salva anagrafiche";
            this.btnSalvaAnagrafiche.UseVisualStyleBackColor = true;
            this.btnSalvaAnagrafiche.Click += new System.EventHandler(this.btnSalvaAnagrafiche_Click);
            // 
            // btnVerificaAnagrafiche
            // 
            this.btnVerificaAnagrafiche.Location = new System.Drawing.Point(17, 16);
            this.btnVerificaAnagrafiche.Name = "btnVerificaAnagrafiche";
            this.btnVerificaAnagrafiche.Size = new System.Drawing.Size(138, 33);
            this.btnVerificaAnagrafiche.TabIndex = 0;
            this.btnVerificaAnagrafiche.Text = "Verifica anagrafiche";
            this.btnVerificaAnagrafiche.UseVisualStyleBackColor = true;
            this.btnVerificaAnagrafiche.Click += new System.EventHandler(this.btnVerificaAnagrafiche_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMsgCicli);
            this.tabPage1.Controls.Add(this.btnSalvaCicli);
            this.tabPage1.Controls.Add(this.btnVerificaCicli);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(937, 718);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Cicli";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtMsgCicli
            // 
            this.txtMsgCicli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsgCicli.Location = new System.Drawing.Point(19, 97);
            this.txtMsgCicli.Multiline = true;
            this.txtMsgCicli.Name = "txtMsgCicli";
            this.txtMsgCicli.ReadOnly = true;
            this.txtMsgCicli.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgCicli.Size = new System.Drawing.Size(898, 600);
            this.txtMsgCicli.TabIndex = 4;
            // 
            // btnSalvaCicli
            // 
            this.btnSalvaCicli.Enabled = false;
            this.btnSalvaCicli.Location = new System.Drawing.Point(189, 22);
            this.btnSalvaCicli.Name = "btnSalvaCicli";
            this.btnSalvaCicli.Size = new System.Drawing.Size(138, 33);
            this.btnSalvaCicli.TabIndex = 2;
            this.btnSalvaCicli.Text = "Salva cicli";
            this.btnSalvaCicli.UseVisualStyleBackColor = true;
            this.btnSalvaCicli.Click += new System.EventHandler(this.btnSalvaCicli_Click);
            // 
            // btnVerificaCicli
            // 
            this.btnVerificaCicli.Location = new System.Drawing.Point(19, 22);
            this.btnVerificaCicli.Name = "btnVerificaCicli";
            this.btnVerificaCicli.Size = new System.Drawing.Size(138, 33);
            this.btnVerificaCicli.TabIndex = 3;
            this.btnVerificaCicli.Text = "Verifica cicli";
            this.btnVerificaCicli.UseVisualStyleBackColor = true;
            this.btnVerificaCicli.Click += new System.EventHandler(this.btnVerificaCicli_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtMsgDistinte);
            this.tabPage3.Controls.Add(this.btnSalvaDistinte);
            this.tabPage3.Controls.Add(this.btnVerificaDistinte);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(937, 718);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Distinte";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtMsgDistinte
            // 
            this.txtMsgDistinte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsgDistinte.Location = new System.Drawing.Point(19, 97);
            this.txtMsgDistinte.Multiline = true;
            this.txtMsgDistinte.Name = "txtMsgDistinte";
            this.txtMsgDistinte.ReadOnly = true;
            this.txtMsgDistinte.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgDistinte.Size = new System.Drawing.Size(898, 600);
            this.txtMsgDistinte.TabIndex = 4;
            // 
            // btnSalvaDistinte
            // 
            this.btnSalvaDistinte.Enabled = false;
            this.btnSalvaDistinte.Location = new System.Drawing.Point(189, 22);
            this.btnSalvaDistinte.Name = "btnSalvaDistinte";
            this.btnSalvaDistinte.Size = new System.Drawing.Size(138, 33);
            this.btnSalvaDistinte.TabIndex = 2;
            this.btnSalvaDistinte.Text = "Salva distinte";
            this.btnSalvaDistinte.UseVisualStyleBackColor = true;
            this.btnSalvaDistinte.Click += new System.EventHandler(this.btnSalvaDistinte_Click);
            // 
            // btnVerificaDistinte
            // 
            this.btnVerificaDistinte.Location = new System.Drawing.Point(19, 22);
            this.btnVerificaDistinte.Name = "btnVerificaDistinte";
            this.btnVerificaDistinte.Size = new System.Drawing.Size(138, 33);
            this.btnVerificaDistinte.TabIndex = 3;
            this.btnVerificaDistinte.Text = "Verifica distinte";
            this.btnVerificaDistinte.UseVisualStyleBackColor = true;
            this.btnVerificaDistinte.Click += new System.EventHandler(this.btnVerificaDistinte_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(522, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Versione";
            // 
            // txtVersioneDiBa
            // 
            this.txtVersioneDiBa.Location = new System.Drawing.Point(575, 10);
            this.txtVersioneDiBa.Name = "txtVersioneDiBa";
            this.txtVersioneDiBa.ReadOnly = true;
            this.txtVersioneDiBa.Size = new System.Drawing.Size(139, 20);
            this.txtVersioneDiBa.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(769, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Note Standard";
            // 
            // txtNoteStd
            // 
            this.txtNoteStd.Location = new System.Drawing.Point(847, 10);
            this.txtNoteStd.Name = "txtNoteStd";
            this.txtNoteStd.ReadOnly = true;
            this.txtNoteStd.Size = new System.Drawing.Size(495, 20);
            this.txtNoteStd.TabIndex = 7;
            // 
            // EstraiProdottoFinito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 808);
            this.Controls.Add(this.txtNoteStd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVersioneDiBa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCercaDiBa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArticolo);
            this.Controls.Add(this.tvDiBa);
            this.Name = "EstraiProdottoFinito";
            this.Text = "Distinta RVL";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodi)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvDiBa;
        private System.Windows.Forms.TextBox txtArticolo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCercaDiBa;
        private System.Windows.Forms.DataGridView dgvNodi;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVersioneDiBa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoteStd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODELLO;
        private System.Windows.Forms.DataGridViewTextBoxColumn REPARTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FASE;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANAGRAFICA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODICECICLO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PEZZIORARI;
        private System.Windows.Forms.DataGridViewTextBoxColumn FORNITOCOMMITTENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLLEGAMENTODIBA;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLLEGAMENTOCICLO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PESO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPERFICIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOTESTANDARD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOTETECNICHE;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtMsgAnagrafiche;
        private System.Windows.Forms.Button btnVerificaAnagrafiche;
        private System.Windows.Forms.Button btnSalvaAnagrafiche;
        private System.Windows.Forms.TextBox txtMsgCicli;
        private System.Windows.Forms.Button btnSalvaCicli;
        private System.Windows.Forms.Button btnVerificaCicli;
        private System.Windows.Forms.TextBox txtMsgDistinte;
        private System.Windows.Forms.Button btnSalvaDistinte;
        private System.Windows.Forms.Button btnVerificaDistinte;
    }
}

