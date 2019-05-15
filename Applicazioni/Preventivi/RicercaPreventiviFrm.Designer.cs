namespace Preventivi
{
    partial class RicercaPreventiviFrm
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
            this.components = new System.ComponentModel.Container();
            this.dgvArticoli = new System.Windows.Forms.DataGridView();
            this.iDVENDITEPTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cODICECLIFODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATADOCUMENTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aNNODOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUMDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rIFERIMENTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATARIFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATAINIZIOVALIDITADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATAFINEVALIDITADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preventiviDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvScaglioni = new System.Windows.Forms.DataGridView();
            this.iDVENDITEPFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDVENDITEPDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDVENDITEPTDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qTADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pREZZOUNIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pREZZOUNICALCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOSTOUNICALCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rICARICOUNICALCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCONTO1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCONTO2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCONTO3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCONTO4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCONTO5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCONTO6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCONTO7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCONTO8DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCONTO9DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vALOREDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblErrore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvArticoliDettaglio = new System.Windows.Forms.DataGridView();
            this.iDVENDITEPDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDVENDITEPTDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRRIGA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODELLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESMAGAZZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VERSIONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticoli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preventiviDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScaglioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticoliDettaglio)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticoli
            // 
            this.dgvArticoli.AllowUserToAddRows = false;
            this.dgvArticoli.AllowUserToDeleteRows = false;
            this.dgvArticoli.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticoli.AutoGenerateColumns = false;
            this.dgvArticoli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticoli.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDVENDITEPTDataGridViewTextBoxColumn,
            this.cODICECLIFODataGridViewTextBoxColumn,
            this.dATADOCUMENTODataGridViewTextBoxColumn,
            this.aNNODOCDataGridViewTextBoxColumn,
            this.nUMDOCDataGridViewTextBoxColumn,
            this.rIFERIMENTODataGridViewTextBoxColumn,
            this.dATARIFDataGridViewTextBoxColumn,
            this.dATAINIZIOVALIDITADataGridViewTextBoxColumn,
            this.dATAFINEVALIDITADataGridViewTextBoxColumn});
            this.dgvArticoli.DataMember = "USR_VENDITEPT";
            this.dgvArticoli.DataSource = this.preventiviDSBindingSource;
            this.dgvArticoli.Location = new System.Drawing.Point(12, 26);
            this.dgvArticoli.Name = "dgvArticoli";
            this.dgvArticoli.ReadOnly = true;
            this.dgvArticoli.Size = new System.Drawing.Size(1043, 216);
            this.dgvArticoli.TabIndex = 0;
            this.dgvArticoli.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticoli_CellClick);
            // 
            // iDVENDITEPTDataGridViewTextBoxColumn
            // 
            this.iDVENDITEPTDataGridViewTextBoxColumn.DataPropertyName = "IDVENDITEPT";
            this.iDVENDITEPTDataGridViewTextBoxColumn.HeaderText = "IDVENDITEPT";
            this.iDVENDITEPTDataGridViewTextBoxColumn.Name = "iDVENDITEPTDataGridViewTextBoxColumn";
            this.iDVENDITEPTDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDVENDITEPTDataGridViewTextBoxColumn.Visible = false;
            // 
            // cODICECLIFODataGridViewTextBoxColumn
            // 
            this.cODICECLIFODataGridViewTextBoxColumn.DataPropertyName = "CODICECLIFO";
            this.cODICECLIFODataGridViewTextBoxColumn.HeaderText = "CODICECLIFO";
            this.cODICECLIFODataGridViewTextBoxColumn.Name = "cODICECLIFODataGridViewTextBoxColumn";
            this.cODICECLIFODataGridViewTextBoxColumn.ReadOnly = true;
            this.cODICECLIFODataGridViewTextBoxColumn.Visible = false;
            // 
            // dATADOCUMENTODataGridViewTextBoxColumn
            // 
            this.dATADOCUMENTODataGridViewTextBoxColumn.DataPropertyName = "DATADOCUMENTO";
            this.dATADOCUMENTODataGridViewTextBoxColumn.HeaderText = "Data documento";
            this.dATADOCUMENTODataGridViewTextBoxColumn.Name = "dATADOCUMENTODataGridViewTextBoxColumn";
            this.dATADOCUMENTODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aNNODOCDataGridViewTextBoxColumn
            // 
            this.aNNODOCDataGridViewTextBoxColumn.DataPropertyName = "ANNODOC";
            this.aNNODOCDataGridViewTextBoxColumn.HeaderText = "Anno";
            this.aNNODOCDataGridViewTextBoxColumn.Name = "aNNODOCDataGridViewTextBoxColumn";
            this.aNNODOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.aNNODOCDataGridViewTextBoxColumn.Width = 80;
            // 
            // nUMDOCDataGridViewTextBoxColumn
            // 
            this.nUMDOCDataGridViewTextBoxColumn.DataPropertyName = "NUMDOC";
            this.nUMDOCDataGridViewTextBoxColumn.HeaderText = "Numero";
            this.nUMDOCDataGridViewTextBoxColumn.Name = "nUMDOCDataGridViewTextBoxColumn";
            this.nUMDOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.nUMDOCDataGridViewTextBoxColumn.Width = 80;
            // 
            // rIFERIMENTODataGridViewTextBoxColumn
            // 
            this.rIFERIMENTODataGridViewTextBoxColumn.DataPropertyName = "RIFERIMENTO";
            this.rIFERIMENTODataGridViewTextBoxColumn.HeaderText = "Riferimento";
            this.rIFERIMENTODataGridViewTextBoxColumn.Name = "rIFERIMENTODataGridViewTextBoxColumn";
            this.rIFERIMENTODataGridViewTextBoxColumn.ReadOnly = true;
            this.rIFERIMENTODataGridViewTextBoxColumn.Width = 250;
            // 
            // dATARIFDataGridViewTextBoxColumn
            // 
            this.dATARIFDataGridViewTextBoxColumn.DataPropertyName = "DATARIF";
            this.dATARIFDataGridViewTextBoxColumn.HeaderText = "Data riferimento";
            this.dATARIFDataGridViewTextBoxColumn.Name = "dATARIFDataGridViewTextBoxColumn";
            this.dATARIFDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dATAINIZIOVALIDITADataGridViewTextBoxColumn
            // 
            this.dATAINIZIOVALIDITADataGridViewTextBoxColumn.DataPropertyName = "DATAINIZIOVALIDITA";
            this.dATAINIZIOVALIDITADataGridViewTextBoxColumn.HeaderText = "Inizio validita";
            this.dATAINIZIOVALIDITADataGridViewTextBoxColumn.Name = "dATAINIZIOVALIDITADataGridViewTextBoxColumn";
            this.dATAINIZIOVALIDITADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dATAFINEVALIDITADataGridViewTextBoxColumn
            // 
            this.dATAFINEVALIDITADataGridViewTextBoxColumn.DataPropertyName = "DATAFINEVALIDITA";
            this.dATAFINEVALIDITADataGridViewTextBoxColumn.HeaderText = "Fine validita";
            this.dATAFINEVALIDITADataGridViewTextBoxColumn.Name = "dATAFINEVALIDITADataGridViewTextBoxColumn";
            this.dATAFINEVALIDITADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // preventiviDSBindingSource
            // 
            this.preventiviDSBindingSource.DataSource = typeof(Applicazioni.Entities.PreventiviDS);
            this.preventiviDSBindingSource.Position = 0;
            // 
            // dgvScaglioni
            // 
            this.dgvScaglioni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvScaglioni.AutoGenerateColumns = false;
            this.dgvScaglioni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScaglioni.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDVENDITEPFDataGridViewTextBoxColumn,
            this.iDVENDITEPDDataGridViewTextBoxColumn1,
            this.iDVENDITEPTDataGridViewTextBoxColumn2,
            this.qTADataGridViewTextBoxColumn,
            this.pREZZOUNIDataGridViewTextBoxColumn,
            this.pREZZOUNICALCDataGridViewTextBoxColumn,
            this.cOSTOUNICALCDataGridViewTextBoxColumn,
            this.rICARICOUNICALCDataGridViewTextBoxColumn,
            this.sCONTO1DataGridViewTextBoxColumn,
            this.sCONTO2DataGridViewTextBoxColumn,
            this.sCONTO3DataGridViewTextBoxColumn,
            this.sCONTO4DataGridViewTextBoxColumn,
            this.sCONTO5DataGridViewTextBoxColumn,
            this.sCONTO6DataGridViewTextBoxColumn,
            this.sCONTO7DataGridViewTextBoxColumn,
            this.sCONTO8DataGridViewTextBoxColumn,
            this.sCONTO9DataGridViewTextBoxColumn,
            this.vALOREDataGridViewTextBoxColumn});
            this.dgvScaglioni.DataMember = "USR_VENDITEPF";
            this.dgvScaglioni.DataSource = this.preventiviDSBindingSource;
            this.dgvScaglioni.Location = new System.Drawing.Point(12, 487);
            this.dgvScaglioni.Name = "dgvScaglioni";
            this.dgvScaglioni.Size = new System.Drawing.Size(1043, 175);
            this.dgvScaglioni.TabIndex = 0;
            this.dgvScaglioni.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScaglioni_CellClick);
            // 
            // iDVENDITEPFDataGridViewTextBoxColumn
            // 
            this.iDVENDITEPFDataGridViewTextBoxColumn.DataPropertyName = "IDVENDITEPF";
            this.iDVENDITEPFDataGridViewTextBoxColumn.HeaderText = "IDVENDITEPF";
            this.iDVENDITEPFDataGridViewTextBoxColumn.Name = "iDVENDITEPFDataGridViewTextBoxColumn";
            this.iDVENDITEPFDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDVENDITEPDDataGridViewTextBoxColumn1
            // 
            this.iDVENDITEPDDataGridViewTextBoxColumn1.DataPropertyName = "IDVENDITEPD";
            this.iDVENDITEPDDataGridViewTextBoxColumn1.HeaderText = "IDVENDITEPD";
            this.iDVENDITEPDDataGridViewTextBoxColumn1.Name = "iDVENDITEPDDataGridViewTextBoxColumn1";
            this.iDVENDITEPDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // iDVENDITEPTDataGridViewTextBoxColumn2
            // 
            this.iDVENDITEPTDataGridViewTextBoxColumn2.DataPropertyName = "IDVENDITEPT";
            this.iDVENDITEPTDataGridViewTextBoxColumn2.HeaderText = "IDVENDITEPT";
            this.iDVENDITEPTDataGridViewTextBoxColumn2.Name = "iDVENDITEPTDataGridViewTextBoxColumn2";
            this.iDVENDITEPTDataGridViewTextBoxColumn2.Visible = false;
            // 
            // qTADataGridViewTextBoxColumn
            // 
            this.qTADataGridViewTextBoxColumn.DataPropertyName = "QTA";
            this.qTADataGridViewTextBoxColumn.HeaderText = "Quantità";
            this.qTADataGridViewTextBoxColumn.Name = "qTADataGridViewTextBoxColumn";
            this.qTADataGridViewTextBoxColumn.Width = 80;
            // 
            // pREZZOUNIDataGridViewTextBoxColumn
            // 
            this.pREZZOUNIDataGridViewTextBoxColumn.DataPropertyName = "PREZZOUNI";
            this.pREZZOUNIDataGridViewTextBoxColumn.HeaderText = "Prezzo unitario";
            this.pREZZOUNIDataGridViewTextBoxColumn.Name = "pREZZOUNIDataGridViewTextBoxColumn";
            this.pREZZOUNIDataGridViewTextBoxColumn.Width = 80;
            // 
            // pREZZOUNICALCDataGridViewTextBoxColumn
            // 
            this.pREZZOUNICALCDataGridViewTextBoxColumn.DataPropertyName = "PREZZOUNICALC";
            this.pREZZOUNICALCDataGridViewTextBoxColumn.HeaderText = "Prezzo unitario calcolato";
            this.pREZZOUNICALCDataGridViewTextBoxColumn.Name = "pREZZOUNICALCDataGridViewTextBoxColumn";
            this.pREZZOUNICALCDataGridViewTextBoxColumn.Width = 80;
            // 
            // cOSTOUNICALCDataGridViewTextBoxColumn
            // 
            this.cOSTOUNICALCDataGridViewTextBoxColumn.DataPropertyName = "COSTOUNICALC";
            this.cOSTOUNICALCDataGridViewTextBoxColumn.HeaderText = "Costo unitario calcolato";
            this.cOSTOUNICALCDataGridViewTextBoxColumn.Name = "cOSTOUNICALCDataGridViewTextBoxColumn";
            this.cOSTOUNICALCDataGridViewTextBoxColumn.Width = 80;
            // 
            // rICARICOUNICALCDataGridViewTextBoxColumn
            // 
            this.rICARICOUNICALCDataGridViewTextBoxColumn.DataPropertyName = "RICARICOUNICALC";
            this.rICARICOUNICALCDataGridViewTextBoxColumn.HeaderText = "Ricarico unitario calcolato";
            this.rICARICOUNICALCDataGridViewTextBoxColumn.Name = "rICARICOUNICALCDataGridViewTextBoxColumn";
            this.rICARICOUNICALCDataGridViewTextBoxColumn.Width = 80;
            // 
            // sCONTO1DataGridViewTextBoxColumn
            // 
            this.sCONTO1DataGridViewTextBoxColumn.DataPropertyName = "SCONTO1";
            this.sCONTO1DataGridViewTextBoxColumn.HeaderText = "Sc.1";
            this.sCONTO1DataGridViewTextBoxColumn.Name = "sCONTO1DataGridViewTextBoxColumn";
            this.sCONTO1DataGridViewTextBoxColumn.Width = 57;
            // 
            // sCONTO2DataGridViewTextBoxColumn
            // 
            this.sCONTO2DataGridViewTextBoxColumn.DataPropertyName = "SCONTO2";
            this.sCONTO2DataGridViewTextBoxColumn.HeaderText = "Sc.2";
            this.sCONTO2DataGridViewTextBoxColumn.Name = "sCONTO2DataGridViewTextBoxColumn";
            this.sCONTO2DataGridViewTextBoxColumn.Width = 57;
            // 
            // sCONTO3DataGridViewTextBoxColumn
            // 
            this.sCONTO3DataGridViewTextBoxColumn.DataPropertyName = "SCONTO3";
            this.sCONTO3DataGridViewTextBoxColumn.HeaderText = "Sc.3";
            this.sCONTO3DataGridViewTextBoxColumn.Name = "sCONTO3DataGridViewTextBoxColumn";
            this.sCONTO3DataGridViewTextBoxColumn.Width = 57;
            // 
            // sCONTO4DataGridViewTextBoxColumn
            // 
            this.sCONTO4DataGridViewTextBoxColumn.DataPropertyName = "SCONTO4";
            this.sCONTO4DataGridViewTextBoxColumn.HeaderText = "Sc.4";
            this.sCONTO4DataGridViewTextBoxColumn.Name = "sCONTO4DataGridViewTextBoxColumn";
            this.sCONTO4DataGridViewTextBoxColumn.Width = 57;
            // 
            // sCONTO5DataGridViewTextBoxColumn
            // 
            this.sCONTO5DataGridViewTextBoxColumn.DataPropertyName = "SCONTO5";
            this.sCONTO5DataGridViewTextBoxColumn.HeaderText = "Sc.5";
            this.sCONTO5DataGridViewTextBoxColumn.Name = "sCONTO5DataGridViewTextBoxColumn";
            this.sCONTO5DataGridViewTextBoxColumn.Width = 57;
            // 
            // sCONTO6DataGridViewTextBoxColumn
            // 
            this.sCONTO6DataGridViewTextBoxColumn.DataPropertyName = "SCONTO6";
            this.sCONTO6DataGridViewTextBoxColumn.HeaderText = "Sc.6";
            this.sCONTO6DataGridViewTextBoxColumn.Name = "sCONTO6DataGridViewTextBoxColumn";
            this.sCONTO6DataGridViewTextBoxColumn.Width = 57;
            // 
            // sCONTO7DataGridViewTextBoxColumn
            // 
            this.sCONTO7DataGridViewTextBoxColumn.DataPropertyName = "SCONTO7";
            this.sCONTO7DataGridViewTextBoxColumn.HeaderText = "Sc.7";
            this.sCONTO7DataGridViewTextBoxColumn.Name = "sCONTO7DataGridViewTextBoxColumn";
            this.sCONTO7DataGridViewTextBoxColumn.Width = 57;
            // 
            // sCONTO8DataGridViewTextBoxColumn
            // 
            this.sCONTO8DataGridViewTextBoxColumn.DataPropertyName = "SCONTO8";
            this.sCONTO8DataGridViewTextBoxColumn.HeaderText = "Sc.8";
            this.sCONTO8DataGridViewTextBoxColumn.Name = "sCONTO8DataGridViewTextBoxColumn";
            this.sCONTO8DataGridViewTextBoxColumn.Width = 57;
            // 
            // sCONTO9DataGridViewTextBoxColumn
            // 
            this.sCONTO9DataGridViewTextBoxColumn.DataPropertyName = "SCONTO9";
            this.sCONTO9DataGridViewTextBoxColumn.HeaderText = "Sc.9";
            this.sCONTO9DataGridViewTextBoxColumn.Name = "sCONTO9DataGridViewTextBoxColumn";
            this.sCONTO9DataGridViewTextBoxColumn.Width = 57;
            // 
            // vALOREDataGridViewTextBoxColumn
            // 
            this.vALOREDataGridViewTextBoxColumn.DataPropertyName = "VALORE";
            this.vALOREDataGridViewTextBoxColumn.HeaderText = "Valore";
            this.vALOREDataGridViewTextBoxColumn.Name = "vALOREDataGridViewTextBoxColumn";
            this.vALOREDataGridViewTextBoxColumn.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Riferimenti";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Articoli";
            // 
            // lblErrore
            // 
            this.lblErrore.AutoSize = true;
            this.lblErrore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrore.ForeColor = System.Drawing.Color.Red;
            this.lblErrore.Location = new System.Drawing.Point(361, 256);
            this.lblErrore.Name = "lblErrore";
            this.lblErrore.Size = new System.Drawing.Size(56, 16);
            this.lblErrore.TabIndex = 2;
            this.lblErrore.Text = "Articoli";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Scaglioni";
            // 
            // dgvArticoliDettaglio
            // 
            this.dgvArticoliDettaglio.AllowUserToAddRows = false;
            this.dgvArticoliDettaglio.AllowUserToDeleteRows = false;
            this.dgvArticoliDettaglio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticoliDettaglio.AutoGenerateColumns = false;
            this.dgvArticoliDettaglio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticoliDettaglio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDVENDITEPDDataGridViewTextBoxColumn,
            this.iDVENDITEPTDataGridViewTextBoxColumn1,
            this.NRRIGA,
            this.MODELLO,
            this.DESMAGAZZ,
            this.VERSIONE});
            this.dgvArticoliDettaglio.DataMember = "USR_VENDITEPD";
            this.dgvArticoliDettaglio.DataSource = this.preventiviDSBindingSource;
            this.dgvArticoliDettaglio.Location = new System.Drawing.Point(12, 275);
            this.dgvArticoliDettaglio.Name = "dgvArticoliDettaglio";
            this.dgvArticoliDettaglio.ReadOnly = true;
            this.dgvArticoliDettaglio.Size = new System.Drawing.Size(1043, 177);
            this.dgvArticoliDettaglio.TabIndex = 0;
            this.dgvArticoliDettaglio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticoliDettaglio_CellClick);
            // 
            // iDVENDITEPDDataGridViewTextBoxColumn
            // 
            this.iDVENDITEPDDataGridViewTextBoxColumn.DataPropertyName = "IDVENDITEPD";
            this.iDVENDITEPDDataGridViewTextBoxColumn.HeaderText = "IDVENDITEPD";
            this.iDVENDITEPDDataGridViewTextBoxColumn.Name = "iDVENDITEPDDataGridViewTextBoxColumn";
            this.iDVENDITEPDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDVENDITEPDDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDVENDITEPTDataGridViewTextBoxColumn1
            // 
            this.iDVENDITEPTDataGridViewTextBoxColumn1.DataPropertyName = "IDVENDITEPT";
            this.iDVENDITEPTDataGridViewTextBoxColumn1.HeaderText = "IDVENDITEPT";
            this.iDVENDITEPTDataGridViewTextBoxColumn1.Name = "iDVENDITEPTDataGridViewTextBoxColumn1";
            this.iDVENDITEPTDataGridViewTextBoxColumn1.ReadOnly = true;
            this.iDVENDITEPTDataGridViewTextBoxColumn1.Visible = false;
            // 
            // NRRIGA
            // 
            this.NRRIGA.DataPropertyName = "NRRIGA";
            this.NRRIGA.HeaderText = "N. riga";
            this.NRRIGA.Name = "NRRIGA";
            this.NRRIGA.ReadOnly = true;
            // 
            // MODELLO
            // 
            this.MODELLO.DataPropertyName = "MODELLO";
            this.MODELLO.HeaderText = "Modello";
            this.MODELLO.Name = "MODELLO";
            this.MODELLO.ReadOnly = true;
            this.MODELLO.Width = 200;
            // 
            // DESMAGAZZ
            // 
            this.DESMAGAZZ.DataPropertyName = "DESMAGAZZ";
            this.DESMAGAZZ.HeaderText = "Descrizione";
            this.DESMAGAZZ.Name = "DESMAGAZZ";
            this.DESMAGAZZ.ReadOnly = true;
            this.DESMAGAZZ.Width = 380;
            // 
            // VERSIONE
            // 
            this.VERSIONE.DataPropertyName = "VERSIONE";
            this.VERSIONE.HeaderText = "Versione";
            this.VERSIONE.Name = "VERSIONE";
            this.VERSIONE.ReadOnly = true;
            // 
            // RicercaPreventiviFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 687);
            this.Controls.Add(this.lblErrore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvArticoliDettaglio);
            this.Controls.Add(this.dgvScaglioni);
            this.Controls.Add(this.dgvArticoli);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RicercaPreventiviFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ricerca preventivo";
            this.Load += new System.EventHandler(this.RicercaPreventiviFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticoli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preventiviDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScaglioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticoliDettaglio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticoli;
        private System.Windows.Forms.DataGridView dgvScaglioni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblErrore;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDVENDITEPTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODICECLIFODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATADOCUMENTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aNNODOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUMDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rIFERIMENTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATARIFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATAINIZIOVALIDITADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATAFINEVALIDITADataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource preventiviDSBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvArticoliDettaglio;
        private System.Windows.Forms.DataGridViewTextBoxColumn nRRIGADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vERSIONEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDVENDITEPDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDVENDITEPTDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRRIGA;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODELLO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESMAGAZZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn VERSIONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDVENDITEPFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDVENDITEPDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDVENDITEPTDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pREZZOUNIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pREZZOUNICALCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOSTOUNICALCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rICARICOUNICALCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCONTO1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCONTO2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCONTO3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCONTO4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCONTO5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCONTO6DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCONTO7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCONTO8DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCONTO9DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALOREDataGridViewTextBoxColumn;
    }
}