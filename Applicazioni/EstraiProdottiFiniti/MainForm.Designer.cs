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
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtNotifiche = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVersioneDiBa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoteStd = new System.Windows.Forms.TextBox();
            this.chkInserisciTopFinish = new System.Windows.Forms.CheckBox();
            this.chkControlliQualita = new System.Windows.Forms.CheckBox();
            this.btnVerifica = new System.Windows.Forms.Button();
            this.btnContoLavoro = new System.Windows.Forms.Button();
            this.chkTest = new System.Windows.Forms.CheckBox();
            this.btnSalvaTutto = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODELLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIZIONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPARTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FASE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDMAGAZZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANAGRAFICA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODICECICLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLLEGAMENTOCICLO = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.COLLEGAMENTODIBA = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PEZZIORARI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OREPERIODO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOTESTANDARD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITACONSUMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITAOCCORRENZA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METODO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VERSIONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATTIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTROLLATA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FORNITOCOMMITTENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPERFICIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOTETECNICHE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContoLavoro = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodi)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
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
            // dgvNodi
            // 
            this.dgvNodi.AllowUserToDeleteRows = false;
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
            this.COLLEGAMENTOCICLO,
            this.COLLEGAMENTODIBA,
            this.PEZZIORARI,
            this.OREPERIODO,
            this.NOTESTANDARD,
            this.QUANTITA,
            this.QUANTITACONSUMO,
            this.QUANTITAOCCORRENZA,
            this.UM,
            this.METODO,
            this.VERSIONE,
            this.ATTIVA,
            this.CONTROLLATA,
            this.FORNITOCOMMITTENTE,
            this.PESO,
            this.SUPERFICIE,
            this.NOTETECNICHE,
            this.ContoLavoro});
            this.dgvNodi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNodi.Location = new System.Drawing.Point(3, 3);
            this.dgvNodi.Name = "dgvNodi";
            this.dgvNodi.Size = new System.Drawing.Size(1088, 805);
            this.dgvNodi.TabIndex = 4;
            this.dgvNodi.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvNodi_RowsAdded);
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
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(577, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1102, 839);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvNodi);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1094, 811);
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
            this.tabPage4.Size = new System.Drawing.Size(1094, 811);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Anagrafiche";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtMsgAnagrafiche
            // 
            this.txtMsgAnagrafiche.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsgAnagrafiche.Location = new System.Drawing.Point(20, 105);
            this.txtMsgAnagrafiche.Multiline = true;
            this.txtMsgAnagrafiche.Name = "txtMsgAnagrafiche";
            this.txtMsgAnagrafiche.ReadOnly = true;
            this.txtMsgAnagrafiche.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgAnagrafiche.Size = new System.Drawing.Size(1047, 692);
            this.txtMsgAnagrafiche.TabIndex = 1;
            // 
            // btnSalvaAnagrafiche
            // 
            this.btnSalvaAnagrafiche.Enabled = false;
            this.btnSalvaAnagrafiche.Location = new System.Drawing.Point(218, 18);
            this.btnSalvaAnagrafiche.Name = "btnSalvaAnagrafiche";
            this.btnSalvaAnagrafiche.Size = new System.Drawing.Size(161, 38);
            this.btnSalvaAnagrafiche.TabIndex = 0;
            this.btnSalvaAnagrafiche.Text = "Salva anagrafiche";
            this.btnSalvaAnagrafiche.UseVisualStyleBackColor = true;
            this.btnSalvaAnagrafiche.Click += new System.EventHandler(this.btnSalvaAnagrafiche_Click);
            // 
            // btnVerificaAnagrafiche
            // 
            this.btnVerificaAnagrafiche.Location = new System.Drawing.Point(20, 18);
            this.btnVerificaAnagrafiche.Name = "btnVerificaAnagrafiche";
            this.btnVerificaAnagrafiche.Size = new System.Drawing.Size(161, 38);
            this.btnVerificaAnagrafiche.TabIndex = 0;
            this.btnVerificaAnagrafiche.Text = "Verifica anagrafiche";
            this.btnVerificaAnagrafiche.UseVisualStyleBackColor = true;
            this.btnVerificaAnagrafiche.Visible = false;
            this.btnVerificaAnagrafiche.Click += new System.EventHandler(this.btnVerificaAnagrafiche_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMsgCicli);
            this.tabPage1.Controls.Add(this.btnSalvaCicli);
            this.tabPage1.Controls.Add(this.btnVerificaCicli);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1094, 811);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Cicli";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtMsgCicli
            // 
            this.txtMsgCicli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsgCicli.Location = new System.Drawing.Point(22, 112);
            this.txtMsgCicli.Multiline = true;
            this.txtMsgCicli.Name = "txtMsgCicli";
            this.txtMsgCicli.ReadOnly = true;
            this.txtMsgCicli.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgCicli.Size = new System.Drawing.Size(1047, 692);
            this.txtMsgCicli.TabIndex = 4;
            // 
            // btnSalvaCicli
            // 
            this.btnSalvaCicli.Enabled = false;
            this.btnSalvaCicli.Location = new System.Drawing.Point(220, 25);
            this.btnSalvaCicli.Name = "btnSalvaCicli";
            this.btnSalvaCicli.Size = new System.Drawing.Size(161, 38);
            this.btnSalvaCicli.TabIndex = 2;
            this.btnSalvaCicli.Text = "Salva cicli";
            this.btnSalvaCicli.UseVisualStyleBackColor = true;
            this.btnSalvaCicli.Click += new System.EventHandler(this.btnSalvaCicli_Click);
            // 
            // btnVerificaCicli
            // 
            this.btnVerificaCicli.Location = new System.Drawing.Point(22, 25);
            this.btnVerificaCicli.Name = "btnVerificaCicli";
            this.btnVerificaCicli.Size = new System.Drawing.Size(161, 38);
            this.btnVerificaCicli.TabIndex = 3;
            this.btnVerificaCicli.Text = "Verifica cicli";
            this.btnVerificaCicli.UseVisualStyleBackColor = true;
            this.btnVerificaCicli.Visible = false;
            this.btnVerificaCicli.Click += new System.EventHandler(this.btnVerificaCicli_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtMsgDistinte);
            this.tabPage3.Controls.Add(this.btnSalvaDistinte);
            this.tabPage3.Controls.Add(this.btnVerificaDistinte);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1094, 811);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Distinte";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtMsgDistinte
            // 
            this.txtMsgDistinte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsgDistinte.Location = new System.Drawing.Point(22, 112);
            this.txtMsgDistinte.Multiline = true;
            this.txtMsgDistinte.Name = "txtMsgDistinte";
            this.txtMsgDistinte.ReadOnly = true;
            this.txtMsgDistinte.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgDistinte.Size = new System.Drawing.Size(1047, 692);
            this.txtMsgDistinte.TabIndex = 4;
            // 
            // btnSalvaDistinte
            // 
            this.btnSalvaDistinte.Enabled = false;
            this.btnSalvaDistinte.Location = new System.Drawing.Point(220, 25);
            this.btnSalvaDistinte.Name = "btnSalvaDistinte";
            this.btnSalvaDistinte.Size = new System.Drawing.Size(161, 38);
            this.btnSalvaDistinte.TabIndex = 2;
            this.btnSalvaDistinte.Text = "Salva distinte";
            this.btnSalvaDistinte.UseVisualStyleBackColor = true;
            this.btnSalvaDistinte.Click += new System.EventHandler(this.btnSalvaDistinte_Click);
            // 
            // btnVerificaDistinte
            // 
            this.btnVerificaDistinte.Location = new System.Drawing.Point(22, 25);
            this.btnVerificaDistinte.Name = "btnVerificaDistinte";
            this.btnVerificaDistinte.Size = new System.Drawing.Size(161, 38);
            this.btnVerificaDistinte.TabIndex = 3;
            this.btnVerificaDistinte.Text = "Verifica distinte";
            this.btnVerificaDistinte.UseVisualStyleBackColor = true;
            this.btnVerificaDistinte.Visible = false;
            this.btnVerificaDistinte.Click += new System.EventHandler(this.btnVerificaDistinte_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtNotifiche);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1094, 811);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "Notifiche";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // txtNotifiche
            // 
            this.txtNotifiche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotifiche.Location = new System.Drawing.Point(3, 3);
            this.txtNotifiche.Multiline = true;
            this.txtNotifiche.Name = "txtNotifiche";
            this.txtNotifiche.ReadOnly = true;
            this.txtNotifiche.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotifiche.Size = new System.Drawing.Size(1088, 805);
            this.txtNotifiche.TabIndex = 5;
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
            this.chkControlliQualita.Location = new System.Drawing.Point(211, 53);
            this.chkControlliQualita.Name = "chkControlliQualita";
            this.chkControlliQualita.Size = new System.Drawing.Size(157, 19);
            this.chkControlliQualita.TabIndex = 9;
            this.chkControlliQualita.Text = "Rimuovi controlli qualità";
            this.chkControlliQualita.UseVisualStyleBackColor = true;
            // 
            // btnVerifica
            // 
            this.btnVerifica.Location = new System.Drawing.Point(612, 48);
            this.btnVerifica.Name = "btnVerifica";
            this.btnVerifica.Size = new System.Drawing.Size(152, 27);
            this.btnVerifica.TabIndex = 10;
            this.btnVerifica.Text = "Verifica";
            this.btnVerifica.UseVisualStyleBackColor = true;
            this.btnVerifica.Click += new System.EventHandler(this.btnVerifica_Click);
            // 
            // btnContoLavoro
            // 
            this.btnContoLavoro.Location = new System.Drawing.Point(796, 48);
            this.btnContoLavoro.Name = "btnContoLavoro";
            this.btnContoLavoro.Size = new System.Drawing.Size(152, 27);
            this.btnContoLavoro.TabIndex = 11;
            this.btnContoLavoro.Text = "Conto lavoro";
            this.btnContoLavoro.UseVisualStyleBackColor = true;
            this.btnContoLavoro.Click += new System.EventHandler(this.btnContoLavoro_Click);
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
            // btnSalvaTutto
            // 
            this.btnSalvaTutto.Location = new System.Drawing.Point(979, 48);
            this.btnSalvaTutto.Name = "btnSalvaTutto";
            this.btnSalvaTutto.Size = new System.Drawing.Size(152, 27);
            this.btnSalvaTutto.TabIndex = 13;
            this.btnSalvaTutto.Text = "Salva nodi e anagrafiche";
            this.btnSalvaTutto.UseVisualStyleBackColor = true;
            this.btnSalvaTutto.Click += new System.EventHandler(this.btnSalvaTutto_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 40F;
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 40;
            // 
            // MODELLO
            // 
            this.MODELLO.DataPropertyName = "Modello";
            this.MODELLO.FillWeight = 80F;
            this.MODELLO.Frozen = true;
            this.MODELLO.HeaderText = "MODELLO";
            this.MODELLO.Name = "MODELLO";
            this.MODELLO.Width = 80;
            // 
            // DESCRIZIONE
            // 
            this.DESCRIZIONE.DataPropertyName = "DescrizioneArticolo";
            this.DESCRIZIONE.FillWeight = 80F;
            this.DESCRIZIONE.Frozen = true;
            this.DESCRIZIONE.HeaderText = "DESCRIZIONE";
            this.DESCRIZIONE.Name = "DESCRIZIONE";
            this.DESCRIZIONE.Width = 80;
            // 
            // REPARTO
            // 
            this.REPARTO.DataPropertyName = "Reparto";
            this.REPARTO.FillWeight = 80F;
            this.REPARTO.Frozen = true;
            this.REPARTO.HeaderText = "REPARTO";
            this.REPARTO.Name = "REPARTO";
            this.REPARTO.Width = 80;
            // 
            // FASE
            // 
            this.FASE.DataPropertyName = "Fase";
            this.FASE.FillWeight = 80F;
            this.FASE.Frozen = true;
            this.FASE.HeaderText = "FASE";
            this.FASE.Name = "FASE";
            this.FASE.Width = 80;
            // 
            // IDMAGAZZ
            // 
            this.IDMAGAZZ.DataPropertyName = "IDMAGAZZ";
            this.IDMAGAZZ.FillWeight = 80F;
            this.IDMAGAZZ.Frozen = true;
            this.IDMAGAZZ.HeaderText = "IDMAGAZZ";
            this.IDMAGAZZ.Name = "IDMAGAZZ";
            this.IDMAGAZZ.Width = 80;
            // 
            // ANAGRAFICA
            // 
            this.ANAGRAFICA.DataPropertyName = "Anagrafica";
            this.ANAGRAFICA.FillWeight = 160F;
            this.ANAGRAFICA.Frozen = true;
            this.ANAGRAFICA.HeaderText = "ANAGRAFICA";
            this.ANAGRAFICA.Name = "ANAGRAFICA";
            this.ANAGRAFICA.Width = 160;
            // 
            // CODICECICLO
            // 
            this.CODICECICLO.DataPropertyName = "CodiceCiclo";
            this.CODICECICLO.FillWeight = 80F;
            this.CODICECICLO.HeaderText = "CODICE CICLO";
            this.CODICECICLO.Name = "CODICECICLO";
            this.CODICECICLO.Width = 80;
            // 
            // COLLEGAMENTOCICLO
            // 
            this.COLLEGAMENTOCICLO.DataPropertyName = "CollegamentoCiclo";
            this.COLLEGAMENTOCICLO.HeaderText = "COLLEGAMENTO CICLO";
            this.COLLEGAMENTOCICLO.Name = "COLLEGAMENTOCICLO";
            this.COLLEGAMENTOCICLO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COLLEGAMENTOCICLO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COLLEGAMENTOCICLO.Width = 80;
            // 
            // COLLEGAMENTODIBA
            // 
            this.COLLEGAMENTODIBA.DataPropertyName = "CollegamentoDiba";
            this.COLLEGAMENTODIBA.HeaderText = "COLLEGAMENTO DISTINTA";
            this.COLLEGAMENTODIBA.Name = "COLLEGAMENTODIBA";
            this.COLLEGAMENTODIBA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COLLEGAMENTODIBA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COLLEGAMENTODIBA.Width = 80;
            // 
            // PEZZIORARI
            // 
            this.PEZZIORARI.DataPropertyName = "PezziOrari";
            this.PEZZIORARI.HeaderText = "PEZZI ORARI";
            this.PEZZIORARI.Name = "PEZZIORARI";
            this.PEZZIORARI.Width = 50;
            // 
            // OREPERIODO
            // 
            this.OREPERIODO.DataPropertyName = "OrePeriodo";
            this.OREPERIODO.FillWeight = 50F;
            this.OREPERIODO.HeaderText = "ORE PERIODO";
            this.OREPERIODO.Name = "OREPERIODO";
            this.OREPERIODO.Width = 50;
            // 
            // NOTESTANDARD
            // 
            this.NOTESTANDARD.DataPropertyName = "NoteStandard";
            this.NOTESTANDARD.HeaderText = "NOTE STANDARD";
            this.NOTESTANDARD.Name = "NOTESTANDARD";
            this.NOTESTANDARD.Width = 200;
            // 
            // QUANTITA
            // 
            this.QUANTITA.DataPropertyName = "Quantita";
            this.QUANTITA.HeaderText = "QUANTITA";
            this.QUANTITA.Name = "QUANTITA";
            // 
            // QUANTITACONSUMO
            // 
            this.QUANTITACONSUMO.DataPropertyName = "QuantitaConsumo";
            this.QUANTITACONSUMO.HeaderText = "QUANTITA CONSUMO";
            this.QUANTITACONSUMO.Name = "QUANTITACONSUMO";
            // 
            // QUANTITAOCCORRENZA
            // 
            this.QUANTITAOCCORRENZA.DataPropertyName = "QualitaOccorrenza";
            this.QUANTITAOCCORRENZA.HeaderText = "QUANTITA OCCORRENZA";
            this.QUANTITAOCCORRENZA.Name = "QUANTITAOCCORRENZA";
            // 
            // UM
            // 
            this.UM.DataPropertyName = "UM";
            this.UM.HeaderText = "UM";
            this.UM.Name = "UM";
            // 
            // METODO
            // 
            this.METODO.DataPropertyName = "Metodo";
            this.METODO.HeaderText = "METODO";
            this.METODO.Name = "METODO";
            // 
            // VERSIONE
            // 
            this.VERSIONE.DataPropertyName = "Versione";
            this.VERSIONE.HeaderText = "VERSIONE";
            this.VERSIONE.Name = "VERSIONE";
            // 
            // ATTIVA
            // 
            this.ATTIVA.DataPropertyName = "Attiva";
            this.ATTIVA.HeaderText = "ATTIVA";
            this.ATTIVA.Name = "ATTIVA";
            // 
            // CONTROLLATA
            // 
            this.CONTROLLATA.DataPropertyName = "Controllata";
            this.CONTROLLATA.HeaderText = "CONTROLLATA";
            this.CONTROLLATA.Name = "CONTROLLATA";
            // 
            // FORNITOCOMMITTENTE
            // 
            this.FORNITOCOMMITTENTE.DataPropertyName = "FornitoDaCommittente";
            this.FORNITOCOMMITTENTE.HeaderText = "FORN. COMMIT.";
            this.FORNITOCOMMITTENTE.Name = "FORNITOCOMMITTENTE";
            // 
            // PESO
            // 
            this.PESO.DataPropertyName = "Peso";
            this.PESO.HeaderText = "PESO";
            this.PESO.Name = "PESO";
            this.PESO.Width = 50;
            // 
            // SUPERFICIE
            // 
            this.SUPERFICIE.DataPropertyName = "Superficie";
            this.SUPERFICIE.HeaderText = "SUPERFICIE";
            this.SUPERFICIE.Name = "SUPERFICIE";
            this.SUPERFICIE.Width = 50;
            // 
            // NOTETECNICHE
            // 
            this.NOTETECNICHE.DataPropertyName = "NoteTecniche";
            this.NOTETECNICHE.HeaderText = "NOTE TECNICHE";
            this.NOTETECNICHE.Name = "NOTETECNICHE";
            this.NOTETECNICHE.Width = 200;
            // 
            // ContoLavoro
            // 
            this.ContoLavoro.DataPropertyName = "ContoLavoro";
            this.ContoLavoro.HeaderText = "ContoLavoro";
            this.ContoLavoro.Name = "ContoLavoro";
            this.ContoLavoro.Visible = false;
            // 
            // EstraiProdottoFinito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1694, 932);
            this.Controls.Add(this.btnSalvaTutto);
            this.Controls.Add(this.chkTest);
            this.Controls.Add(this.btnContoLavoro);
            this.Controls.Add(this.btnVerifica);
            this.Controls.Add(this.chkControlliQualita);
            this.Controls.Add(this.chkInserisciTopFinish);
            this.Controls.Add(this.txtNoteStd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVersioneDiBa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCercaDiBa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArticolo);
            this.Controls.Add(this.tvDiBa);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EstraiProdottoFinito";
            this.Text = "Distinta RVL";
            this.Load += new System.EventHandler(this.EstraiProdottoFinito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodi)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
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
        private System.Windows.Forms.CheckBox chkInserisciTopFinish;
        private System.Windows.Forms.CheckBox chkControlliQualita;
        private System.Windows.Forms.Button btnVerifica;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox txtNotifiche;
        private System.Windows.Forms.Button btnContoLavoro;
        private System.Windows.Forms.CheckBox chkTest;
        private System.Windows.Forms.Button btnSalvaTutto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODELLO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIZIONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn REPARTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FASE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMAGAZZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANAGRAFICA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODICECICLO;
        private System.Windows.Forms.DataGridViewComboBoxColumn COLLEGAMENTOCICLO;
        private System.Windows.Forms.DataGridViewComboBoxColumn COLLEGAMENTODIBA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PEZZIORARI;
        private System.Windows.Forms.DataGridViewTextBoxColumn OREPERIODO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOTESTANDARD;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITA;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITACONSUMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITAOCCORRENZA;
        private System.Windows.Forms.DataGridViewTextBoxColumn UM;
        private System.Windows.Forms.DataGridViewTextBoxColumn METODO;
        private System.Windows.Forms.DataGridViewTextBoxColumn VERSIONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATTIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTROLLATA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FORNITOCOMMITTENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PESO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPERFICIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOTETECNICHE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ContoLavoro;
    }
}

