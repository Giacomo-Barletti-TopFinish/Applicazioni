namespace Preventivi
{
    partial class BalenciagaFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTrova = new System.Windows.Forms.Button();
            this.txtRiferimento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPrezzo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRicaricoPerc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRicarico = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtScaglione = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModello = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCostiFissi = new System.Windows.Forms.DataGridView();
            this.iDVENDITEPFDIBACOSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDVENDITEPFDIBADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sEQUENZADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRCDDIBADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vALOREFISSODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qTAFISSADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vALORENETTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODVOCECOSTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESVOCECOSTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preventiviDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.nRicarico = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvGruppi = new System.Windows.Forms.DataGridView();
            this.iDVENDITEPFGRUPPOTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODPREVGRUPPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESPREVGRUPPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDVENDITEPFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDVENDITEPDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDVENDITEPFDIBADataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDPREVGRUPPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sEQUENZADataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tOTALECOSTIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tOTALERICARICODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tOTALEVENDITACALCOLATODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tOTALEVENDITAMANUALEGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tOTALEVENDITAMANUALETDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvGruppiDettaglio = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostiFissi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preventiviDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRicarico)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGruppi)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGruppiDettaglio)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTrova);
            this.groupBox1.Controls.Add(this.txtRiferimento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(420, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ricerca";
            // 
            // btnTrova
            // 
            this.btnTrova.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrova.Location = new System.Drawing.Point(304, 29);
            this.btnTrova.Margin = new System.Windows.Forms.Padding(4);
            this.btnTrova.Name = "btnTrova";
            this.btnTrova.Size = new System.Drawing.Size(100, 28);
            this.btnTrova.TabIndex = 2;
            this.btnTrova.Text = "Trova";
            this.btnTrova.UseVisualStyleBackColor = true;
            this.btnTrova.Click += new System.EventHandler(this.btnTrova_Click);
            // 
            // txtRiferimento
            // 
            this.txtRiferimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRiferimento.Location = new System.Drawing.Point(128, 32);
            this.txtRiferimento.Margin = new System.Windows.Forms.Padding(4);
            this.txtRiferimento.Name = "txtRiferimento";
            this.txtRiferimento.Size = new System.Drawing.Size(150, 22);
            this.txtRiferimento.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Riferimento";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPrezzo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtRicaricoPerc);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtRicarico);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCosto);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtScaglione);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtModello);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(444, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1388, 79);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preventivo";
            // 
            // txtPrezzo
            // 
            this.txtPrezzo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrezzo.ForeColor = System.Drawing.Color.Green;
            this.txtPrezzo.Location = new System.Drawing.Point(1281, 30);
            this.txtPrezzo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrezzo.Name = "txtPrezzo";
            this.txtPrezzo.ReadOnly = true;
            this.txtPrezzo.Size = new System.Drawing.Size(95, 22);
            this.txtPrezzo.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1229, 33);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Prezzo";
            // 
            // txtRicaricoPerc
            // 
            this.txtRicaricoPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRicaricoPerc.ForeColor = System.Drawing.Color.Navy;
            this.txtRicaricoPerc.Location = new System.Drawing.Point(1106, 30);
            this.txtRicaricoPerc.Margin = new System.Windows.Forms.Padding(4);
            this.txtRicaricoPerc.Name = "txtRicaricoPerc";
            this.txtRicaricoPerc.ReadOnly = true;
            this.txtRicaricoPerc.Size = new System.Drawing.Size(95, 22);
            this.txtRicaricoPerc.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1029, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "% Ricarico";
            // 
            // txtRicarico
            // 
            this.txtRicarico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRicarico.ForeColor = System.Drawing.Color.Navy;
            this.txtRicarico.Location = new System.Drawing.Point(908, 30);
            this.txtRicarico.Margin = new System.Windows.Forms.Padding(4);
            this.txtRicarico.Name = "txtRicarico";
            this.txtRicarico.ReadOnly = true;
            this.txtRicarico.Size = new System.Drawing.Size(95, 22);
            this.txtRicarico.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(847, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ricarico";
            // 
            // txtCosto
            // 
            this.txtCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.ForeColor = System.Drawing.Color.Red;
            this.txtCosto.Location = new System.Drawing.Point(715, 30);
            this.txtCosto.Margin = new System.Windows.Forms.Padding(4);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.ReadOnly = true;
            this.txtCosto.Size = new System.Drawing.Size(95, 22);
            this.txtCosto.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(669, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Costo";
            // 
            // txtScaglione
            // 
            this.txtScaglione.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScaglione.Location = new System.Drawing.Point(547, 30);
            this.txtScaglione.Margin = new System.Windows.Forms.Padding(4);
            this.txtScaglione.Name = "txtScaglione";
            this.txtScaglione.ReadOnly = true;
            this.txtScaglione.Size = new System.Drawing.Size(95, 22);
            this.txtScaglione.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(474, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Scaglione";
            // 
            // txtModello
            // 
            this.txtModello.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModello.Location = new System.Drawing.Point(75, 30);
            this.txtModello.Margin = new System.Windows.Forms.Padding(4);
            this.txtModello.Name = "txtModello";
            this.txtModello.ReadOnly = true;
            this.txtModello.Size = new System.Drawing.Size(374, 22);
            this.txtModello.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Modello";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvCostiFissi);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(13, 136);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1813, 151);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Costi fissi";
            // 
            // dgvCostiFissi
            // 
            this.dgvCostiFissi.AllowUserToAddRows = false;
            this.dgvCostiFissi.AllowUserToDeleteRows = false;
            this.dgvCostiFissi.AutoGenerateColumns = false;
            this.dgvCostiFissi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostiFissi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDVENDITEPFDIBACOSDataGridViewTextBoxColumn,
            this.iDVENDITEPFDIBADataGridViewTextBoxColumn,
            this.sEQUENZADataGridViewTextBoxColumn,
            this.dESCRCDDIBADataGridViewTextBoxColumn,
            this.vALOREFISSODataGridViewTextBoxColumn,
            this.qTAFISSADataGridViewTextBoxColumn,
            this.vALORENETTODataGridViewTextBoxColumn,
            this.CODVOCECOSTO,
            this.DESVOCECOSTO});
            this.dgvCostiFissi.DataMember = "USR_VENDITEPF_DIBACOS";
            this.dgvCostiFissi.DataSource = this.preventiviDSBindingSource;
            this.dgvCostiFissi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCostiFissi.Location = new System.Drawing.Point(4, 19);
            this.dgvCostiFissi.Name = "dgvCostiFissi";
            this.dgvCostiFissi.ReadOnly = true;
            this.dgvCostiFissi.Size = new System.Drawing.Size(1805, 128);
            this.dgvCostiFissi.TabIndex = 0;
            // 
            // iDVENDITEPFDIBACOSDataGridViewTextBoxColumn
            // 
            this.iDVENDITEPFDIBACOSDataGridViewTextBoxColumn.DataPropertyName = "IDVENDITEPFDIBACOS";
            this.iDVENDITEPFDIBACOSDataGridViewTextBoxColumn.HeaderText = "IDVENDITEPFDIBACOS";
            this.iDVENDITEPFDIBACOSDataGridViewTextBoxColumn.Name = "iDVENDITEPFDIBACOSDataGridViewTextBoxColumn";
            this.iDVENDITEPFDIBACOSDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDVENDITEPFDIBACOSDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDVENDITEPFDIBADataGridViewTextBoxColumn
            // 
            this.iDVENDITEPFDIBADataGridViewTextBoxColumn.DataPropertyName = "IDVENDITEPFDIBA";
            this.iDVENDITEPFDIBADataGridViewTextBoxColumn.HeaderText = "IDVENDITEPFDIBA";
            this.iDVENDITEPFDIBADataGridViewTextBoxColumn.Name = "iDVENDITEPFDIBADataGridViewTextBoxColumn";
            this.iDVENDITEPFDIBADataGridViewTextBoxColumn.ReadOnly = true;
            this.iDVENDITEPFDIBADataGridViewTextBoxColumn.Visible = false;
            // 
            // sEQUENZADataGridViewTextBoxColumn
            // 
            this.sEQUENZADataGridViewTextBoxColumn.DataPropertyName = "SEQUENZA";
            this.sEQUENZADataGridViewTextBoxColumn.HeaderText = "Sequenza";
            this.sEQUENZADataGridViewTextBoxColumn.Name = "sEQUENZADataGridViewTextBoxColumn";
            this.sEQUENZADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dESCRCDDIBADataGridViewTextBoxColumn
            // 
            this.dESCRCDDIBADataGridViewTextBoxColumn.DataPropertyName = "DESCRCDDIBA";
            this.dESCRCDDIBADataGridViewTextBoxColumn.HeaderText = "Descrizione";
            this.dESCRCDDIBADataGridViewTextBoxColumn.Name = "dESCRCDDIBADataGridViewTextBoxColumn";
            this.dESCRCDDIBADataGridViewTextBoxColumn.ReadOnly = true;
            this.dESCRCDDIBADataGridViewTextBoxColumn.Width = 250;
            // 
            // vALOREFISSODataGridViewTextBoxColumn
            // 
            this.vALOREFISSODataGridViewTextBoxColumn.DataPropertyName = "VALOREFISSO";
            this.vALOREFISSODataGridViewTextBoxColumn.HeaderText = "Valore";
            this.vALOREFISSODataGridViewTextBoxColumn.Name = "vALOREFISSODataGridViewTextBoxColumn";
            this.vALOREFISSODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qTAFISSADataGridViewTextBoxColumn
            // 
            this.qTAFISSADataGridViewTextBoxColumn.DataPropertyName = "QTAFISSA";
            this.qTAFISSADataGridViewTextBoxColumn.HeaderText = "Quantità";
            this.qTAFISSADataGridViewTextBoxColumn.Name = "qTAFISSADataGridViewTextBoxColumn";
            this.qTAFISSADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vALORENETTODataGridViewTextBoxColumn
            // 
            this.vALORENETTODataGridViewTextBoxColumn.DataPropertyName = "VALORENETTO";
            this.vALORENETTODataGridViewTextBoxColumn.HeaderText = "Valore netto";
            this.vALORENETTODataGridViewTextBoxColumn.Name = "vALORENETTODataGridViewTextBoxColumn";
            this.vALORENETTODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CODVOCECOSTO
            // 
            this.CODVOCECOSTO.DataPropertyName = "CODVOCECOSTO";
            this.CODVOCECOSTO.HeaderText = "Codice voce costo";
            this.CODVOCECOSTO.Name = "CODVOCECOSTO";
            this.CODVOCECOSTO.ReadOnly = true;
            // 
            // DESVOCECOSTO
            // 
            this.DESVOCECOSTO.DataPropertyName = "DESVOCECOSTO";
            this.DESVOCECOSTO.HeaderText = "Voce costo";
            this.DESVOCECOSTO.Name = "DESVOCECOSTO";
            this.DESVOCECOSTO.ReadOnly = true;
            this.DESVOCECOSTO.Width = 200;
            // 
            // preventiviDSBindingSource
            // 
            this.preventiviDSBindingSource.DataSource = typeof(Applicazioni.Entities.PreventiviDS);
            this.preventiviDSBindingSource.Position = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(789, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "% RICARICO";
            // 
            // nRicarico
            // 
            this.nRicarico.Location = new System.Drawing.Point(881, 101);
            this.nRicarico.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nRicarico.Name = "nRicarico";
            this.nRicarico.Size = new System.Drawing.Size(57, 22);
            this.nRicarico.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dgvGruppi);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(16, 295);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(1813, 286);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gruppi";
            // 
            // dgvGruppi
            // 
            this.dgvGruppi.AllowUserToAddRows = false;
            this.dgvGruppi.AllowUserToDeleteRows = false;
            this.dgvGruppi.AllowUserToOrderColumns = true;
            this.dgvGruppi.AutoGenerateColumns = false;
            this.dgvGruppi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGruppi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDVENDITEPFGRUPPOTDataGridViewTextBoxColumn,
            this.CODPREVGRUPPO,
            this.DESPREVGRUPPO,
            this.iDVENDITEPFDataGridViewTextBoxColumn,
            this.iDVENDITEPDDataGridViewTextBoxColumn,
            this.iDVENDITEPFDIBADataGridViewTextBoxColumn1,
            this.iDPREVGRUPPODataGridViewTextBoxColumn,
            this.sEQUENZADataGridViewTextBoxColumn1,
            this.tOTALECOSTIDataGridViewTextBoxColumn,
            this.tOTALERICARICODataGridViewTextBoxColumn,
            this.tOTALEVENDITACALCOLATODataGridViewTextBoxColumn,
            this.tOTALEVENDITAMANUALEGDataGridViewTextBoxColumn,
            this.tOTALEVENDITAMANUALETDataGridViewTextBoxColumn});
            this.dgvGruppi.DataMember = "USR_VENDITEPF_GRUPPOT";
            this.dgvGruppi.DataSource = this.preventiviDSBindingSource;
            this.dgvGruppi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGruppi.Location = new System.Drawing.Point(4, 19);
            this.dgvGruppi.Name = "dgvGruppi";
            this.dgvGruppi.ReadOnly = true;
            this.dgvGruppi.Size = new System.Drawing.Size(1805, 263);
            this.dgvGruppi.TabIndex = 0;
            this.dgvGruppi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGruppi_CellClick);
            // 
            // iDVENDITEPFGRUPPOTDataGridViewTextBoxColumn
            // 
            this.iDVENDITEPFGRUPPOTDataGridViewTextBoxColumn.DataPropertyName = "IDVENDITEPFGRUPPOT";
            this.iDVENDITEPFGRUPPOTDataGridViewTextBoxColumn.HeaderText = "IDVENDITEPFGRUPPOT";
            this.iDVENDITEPFGRUPPOTDataGridViewTextBoxColumn.Name = "iDVENDITEPFGRUPPOTDataGridViewTextBoxColumn";
            this.iDVENDITEPFGRUPPOTDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDVENDITEPFGRUPPOTDataGridViewTextBoxColumn.Visible = false;
            // 
            // CODPREVGRUPPO
            // 
            this.CODPREVGRUPPO.DataPropertyName = "CODPREVGRUPPO";
            this.CODPREVGRUPPO.HeaderText = "Gruppo";
            this.CODPREVGRUPPO.Name = "CODPREVGRUPPO";
            this.CODPREVGRUPPO.ReadOnly = true;
            // 
            // DESPREVGRUPPO
            // 
            this.DESPREVGRUPPO.DataPropertyName = "DESPREVGRUPPO";
            this.DESPREVGRUPPO.HeaderText = "Descrizione gruppo";
            this.DESPREVGRUPPO.Name = "DESPREVGRUPPO";
            this.DESPREVGRUPPO.ReadOnly = true;
            // 
            // iDVENDITEPFDataGridViewTextBoxColumn
            // 
            this.iDVENDITEPFDataGridViewTextBoxColumn.DataPropertyName = "IDVENDITEPF";
            this.iDVENDITEPFDataGridViewTextBoxColumn.HeaderText = "IDVENDITEPF";
            this.iDVENDITEPFDataGridViewTextBoxColumn.Name = "iDVENDITEPFDataGridViewTextBoxColumn";
            this.iDVENDITEPFDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDVENDITEPFDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDVENDITEPDDataGridViewTextBoxColumn
            // 
            this.iDVENDITEPDDataGridViewTextBoxColumn.DataPropertyName = "IDVENDITEPD";
            this.iDVENDITEPDDataGridViewTextBoxColumn.HeaderText = "IDVENDITEPD";
            this.iDVENDITEPDDataGridViewTextBoxColumn.Name = "iDVENDITEPDDataGridViewTextBoxColumn";
            this.iDVENDITEPDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDVENDITEPDDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDVENDITEPFDIBADataGridViewTextBoxColumn1
            // 
            this.iDVENDITEPFDIBADataGridViewTextBoxColumn1.DataPropertyName = "IDVENDITEPFDIBA";
            this.iDVENDITEPFDIBADataGridViewTextBoxColumn1.HeaderText = "IDVENDITEPFDIBA";
            this.iDVENDITEPFDIBADataGridViewTextBoxColumn1.Name = "iDVENDITEPFDIBADataGridViewTextBoxColumn1";
            this.iDVENDITEPFDIBADataGridViewTextBoxColumn1.ReadOnly = true;
            this.iDVENDITEPFDIBADataGridViewTextBoxColumn1.Visible = false;
            // 
            // iDPREVGRUPPODataGridViewTextBoxColumn
            // 
            this.iDPREVGRUPPODataGridViewTextBoxColumn.DataPropertyName = "IDPREVGRUPPO";
            this.iDPREVGRUPPODataGridViewTextBoxColumn.HeaderText = "IDPREVGRUPPO";
            this.iDPREVGRUPPODataGridViewTextBoxColumn.Name = "iDPREVGRUPPODataGridViewTextBoxColumn";
            this.iDPREVGRUPPODataGridViewTextBoxColumn.ReadOnly = true;
            this.iDPREVGRUPPODataGridViewTextBoxColumn.Visible = false;
            // 
            // sEQUENZADataGridViewTextBoxColumn1
            // 
            this.sEQUENZADataGridViewTextBoxColumn1.DataPropertyName = "SEQUENZA";
            this.sEQUENZADataGridViewTextBoxColumn1.HeaderText = "Sequenza";
            this.sEQUENZADataGridViewTextBoxColumn1.Name = "sEQUENZADataGridViewTextBoxColumn1";
            this.sEQUENZADataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tOTALECOSTIDataGridViewTextBoxColumn
            // 
            this.tOTALECOSTIDataGridViewTextBoxColumn.DataPropertyName = "TOTALECOSTI";
            this.tOTALECOSTIDataGridViewTextBoxColumn.HeaderText = "Totale costi";
            this.tOTALECOSTIDataGridViewTextBoxColumn.Name = "tOTALECOSTIDataGridViewTextBoxColumn";
            this.tOTALECOSTIDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tOTALERICARICODataGridViewTextBoxColumn
            // 
            this.tOTALERICARICODataGridViewTextBoxColumn.DataPropertyName = "TOTALERICARICO";
            this.tOTALERICARICODataGridViewTextBoxColumn.HeaderText = "Totale ricarico";
            this.tOTALERICARICODataGridViewTextBoxColumn.Name = "tOTALERICARICODataGridViewTextBoxColumn";
            this.tOTALERICARICODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tOTALEVENDITACALCOLATODataGridViewTextBoxColumn
            // 
            this.tOTALEVENDITACALCOLATODataGridViewTextBoxColumn.DataPropertyName = "TOTALEVENDITACALCOLATO";
            this.tOTALEVENDITACALCOLATODataGridViewTextBoxColumn.HeaderText = "Totale vendita calcolato";
            this.tOTALEVENDITACALCOLATODataGridViewTextBoxColumn.Name = "tOTALEVENDITACALCOLATODataGridViewTextBoxColumn";
            this.tOTALEVENDITACALCOLATODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tOTALEVENDITAMANUALEGDataGridViewTextBoxColumn
            // 
            this.tOTALEVENDITAMANUALEGDataGridViewTextBoxColumn.DataPropertyName = "TOTALEVENDITAMANUALEG";
            this.tOTALEVENDITAMANUALEGDataGridViewTextBoxColumn.HeaderText = "Totale vendita manuale gruppi";
            this.tOTALEVENDITAMANUALEGDataGridViewTextBoxColumn.Name = "tOTALEVENDITAMANUALEGDataGridViewTextBoxColumn";
            this.tOTALEVENDITAMANUALEGDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tOTALEVENDITAMANUALETDataGridViewTextBoxColumn
            // 
            this.tOTALEVENDITAMANUALETDataGridViewTextBoxColumn.DataPropertyName = "TOTALEVENDITAMANUALET";
            this.tOTALEVENDITAMANUALETDataGridViewTextBoxColumn.HeaderText = "Totale vendita manuale tot.";
            this.tOTALEVENDITAMANUALETDataGridViewTextBoxColumn.Name = "tOTALEVENDITAMANUALETDataGridViewTextBoxColumn";
            this.tOTALEVENDITAMANUALETDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.dgvGruppiDettaglio);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(17, 602);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(1813, 228);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Dettaglio";
            // 
            // dgvGruppiDettaglio
            // 
            this.dgvGruppiDettaglio.AllowUserToAddRows = false;
            this.dgvGruppiDettaglio.AllowUserToDeleteRows = false;
            this.dgvGruppiDettaglio.AllowUserToOrderColumns = true;
            this.dgvGruppiDettaglio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGruppiDettaglio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGruppiDettaglio.Location = new System.Drawing.Point(4, 19);
            this.dgvGruppiDettaglio.Name = "dgvGruppiDettaglio";
            this.dgvGruppiDettaglio.ReadOnly = true;
            this.dgvGruppiDettaglio.Size = new System.Drawing.Size(1805, 205);
            this.dgvGruppiDettaglio.TabIndex = 0;
            // 
            // BalenciagaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1845, 843);
            this.Controls.Add(this.nRicarico);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BalenciagaFrm";
            this.Text = "BALENCIAGA";
            this.Load += new System.EventHandler(this.BalenciagaFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostiFissi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preventiviDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRicarico)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGruppi)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGruppiDettaglio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTrova;
        private System.Windows.Forms.TextBox txtRiferimento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtModello;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrezzo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRicaricoPerc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRicarico;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtScaglione;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvCostiFissi;
        private System.Windows.Forms.BindingSource preventiviDSBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDVENDITEPFDIBACOSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDVENDITEPFDIBADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEQUENZADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRCDDIBADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALOREFISSODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTAFISSADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALORENETTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODVOCECOSTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESVOCECOSTO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nRicarico;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvGruppi;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDVENDITEPFGRUPPOTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODPREVGRUPPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESPREVGRUPPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDVENDITEPFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDVENDITEPDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDVENDITEPFDIBADataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDPREVGRUPPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEQUENZADataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tOTALECOSTIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tOTALERICARICODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tOTALEVENDITACALCOLATODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tOTALEVENDITAMANUALEGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tOTALEVENDITAMANUALETDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvGruppiDettaglio;
    }
}