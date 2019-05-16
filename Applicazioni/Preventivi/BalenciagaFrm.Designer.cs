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
            this.preventiviDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dgvGrezzo = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvLavorazioniInterne = new System.Windows.Forms.DataGridView();
            this.lblPrezzo = new System.Windows.Forms.Label();
            this.nRicarico = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvGruppiDettaglio = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvGruppi = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCostiFissi = new System.Windows.Forms.DataGridView();
            this.CODVOCECOSTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESVOCECOSTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTrova = new System.Windows.Forms.Button();
            this.txtRiferimento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodiceProvvisorio = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCodiceDefinitivo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodiceGalvanica = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFornitore = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDescrizioneArticolo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtStagione = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtEvento = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSpessoreAu = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSpessorePd = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtSuperficie = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtComposizioneMateriali = new System.Windows.Forms.TextBox();
            this.dtData = new System.Windows.Forms.DateTimePicker();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dgvLavorazioniEsterne = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.preventiviDSBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrezzo)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLavorazioniInterne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRicarico)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGruppiDettaglio)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGruppi)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostiFissi)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLavorazioniEsterne)).BeginInit();
            this.SuspendLayout();
            // 
            // preventiviDSBindingSource
            // 
            this.preventiviDSBindingSource.DataSource = typeof(Applicazioni.Entities.PreventiviDS);
            this.preventiviDSBindingSource.Position = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.dtData);
            this.panel1.Controls.Add(this.txtDescrizioneArticolo);
            this.panel1.Controls.Add(this.txtPeso);
            this.panel1.Controls.Add(this.txtFornitore);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtSuperficie);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.txtCodiceGalvanica);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtSpessorePd);
            this.panel1.Controls.Add(this.txtEvento);
            this.panel1.Controls.Add(this.txtCodiceDefinitivo);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtComposizioneMateriali);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.txtSpessoreAu);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.txtStagione);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtCodiceProvvisorio);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.groupBox8);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.lblPrezzo);
            this.panel1.Controls.Add(this.nRicarico);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1844, 1900);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.dgvGrezzo);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(5, 1121);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(1839, 276);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Grezzo";
            // 
            // dgvGrezzo
            // 
            this.dgvGrezzo.AllowUserToAddRows = false;
            this.dgvGrezzo.AllowUserToDeleteRows = false;
            this.dgvGrezzo.AllowUserToOrderColumns = true;
            this.dgvGrezzo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrezzo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrezzo.Location = new System.Drawing.Point(4, 19);
            this.dgvGrezzo.Name = "dgvGrezzo";
            this.dgvGrezzo.ReadOnly = true;
            this.dgvGrezzo.Size = new System.Drawing.Size(1831, 253);
            this.dgvGrezzo.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.dgvLavorazioniInterne);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(5, 1410);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(1839, 228);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Lavorazioni interne";
            // 
            // dgvLavorazioniInterne
            // 
            this.dgvLavorazioniInterne.AllowUserToAddRows = false;
            this.dgvLavorazioniInterne.AllowUserToDeleteRows = false;
            this.dgvLavorazioniInterne.AllowUserToOrderColumns = true;
            this.dgvLavorazioniInterne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLavorazioniInterne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLavorazioniInterne.Location = new System.Drawing.Point(4, 19);
            this.dgvLavorazioniInterne.Name = "dgvLavorazioniInterne";
            this.dgvLavorazioniInterne.ReadOnly = true;
            this.dgvLavorazioniInterne.Size = new System.Drawing.Size(1831, 205);
            this.dgvLavorazioniInterne.TabIndex = 0;
            // 
            // lblPrezzo
            // 
            this.lblPrezzo.AutoSize = true;
            this.lblPrezzo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrezzo.ForeColor = System.Drawing.Color.Red;
            this.lblPrezzo.Location = new System.Drawing.Point(988, 911);
            this.lblPrezzo.Name = "lblPrezzo";
            this.lblPrezzo.Size = new System.Drawing.Size(55, 16);
            this.lblPrezzo.TabIndex = 14;
            this.lblPrezzo.Text = "Prezzo";
            // 
            // nRicarico
            // 
            this.nRicarico.Location = new System.Drawing.Point(822, 90);
            this.nRicarico.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nRicarico.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nRicarico.Name = "nRicarico";
            this.nRicarico.Size = new System.Drawing.Size(57, 22);
            this.nRicarico.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(730, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "% RICARICO";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.dgvGruppiDettaglio);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(1, 594);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(1839, 228);
            this.groupBox5.TabIndex = 10;
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
            this.dgvGruppiDettaglio.Size = new System.Drawing.Size(1831, 205);
            this.dgvGruppiDettaglio.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dgvGruppi);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(1, 284);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(1839, 295);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gruppi";
            // 
            // dgvGruppi
            // 
            this.dgvGruppi.AllowUserToAddRows = false;
            this.dgvGruppi.AllowUserToDeleteRows = false;
            this.dgvGruppi.AllowUserToOrderColumns = true;
            this.dgvGruppi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGruppi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGruppi.Location = new System.Drawing.Point(4, 19);
            this.dgvGruppi.Name = "dgvGruppi";
            this.dgvGruppi.ReadOnly = true;
            this.dgvGruppi.Size = new System.Drawing.Size(1831, 272);
            this.dgvGruppi.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvCostiFissi);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(1, 125);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1839, 151);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Costi fissi";
            // 
            // dgvCostiFissi
            // 
            this.dgvCostiFissi.AllowUserToAddRows = false;
            this.dgvCostiFissi.AllowUserToDeleteRows = false;
            this.dgvCostiFissi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostiFissi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODVOCECOSTO,
            this.DESVOCECOSTO});
            this.dgvCostiFissi.DataMember = "USR_VENDITEPF_DIBACOS";
            this.dgvCostiFissi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCostiFissi.Location = new System.Drawing.Point(4, 19);
            this.dgvCostiFissi.Name = "dgvCostiFissi";
            this.dgvCostiFissi.ReadOnly = true;
            this.dgvCostiFissi.Size = new System.Drawing.Size(1831, 128);
            this.dgvCostiFissi.TabIndex = 0;
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
            this.groupBox2.Location = new System.Drawing.Point(433, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1388, 79);
            this.groupBox2.TabIndex = 9;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTrova);
            this.groupBox1.Controls.Add(this.txtRiferimento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(420, 79);
            this.groupBox1.TabIndex = 7;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 856);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Codice provvisorio";
            // 
            // txtCodiceProvvisorio
            // 
            this.txtCodiceProvvisorio.Location = new System.Drawing.Point(144, 853);
            this.txtCodiceProvvisorio.Name = "txtCodiceProvvisorio";
            this.txtCodiceProvvisorio.Size = new System.Drawing.Size(139, 22);
            this.txtCodiceProvvisorio.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(316, 856);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "Codice definitivo";
            // 
            // txtCodiceDefinitivo
            // 
            this.txtCodiceDefinitivo.Location = new System.Drawing.Point(433, 853);
            this.txtCodiceDefinitivo.Name = "txtCodiceDefinitivo";
            this.txtCodiceDefinitivo.Size = new System.Drawing.Size(139, 22);
            this.txtCodiceDefinitivo.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(608, 856);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 16);
            this.label11.TabIndex = 16;
            this.label11.Text = "Codice galvanica";
            // 
            // txtCodiceGalvanica
            // 
            this.txtCodiceGalvanica.Location = new System.Drawing.Point(733, 853);
            this.txtCodiceGalvanica.Name = "txtCodiceGalvanica";
            this.txtCodiceGalvanica.Size = new System.Drawing.Size(139, 22);
            this.txtCodiceGalvanica.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(951, 856);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 16);
            this.label12.TabIndex = 16;
            this.label12.Text = "Fornitore";
            // 
            // txtFornitore
            // 
            this.txtFornitore.Location = new System.Drawing.Point(1022, 853);
            this.txtFornitore.Name = "txtFornitore";
            this.txtFornitore.Size = new System.Drawing.Size(139, 22);
            this.txtFornitore.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1198, 856);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 16);
            this.label13.TabIndex = 16;
            this.label13.Text = "Descrizione articolo";
            // 
            // txtDescrizioneArticolo
            // 
            this.txtDescrizioneArticolo.Location = new System.Drawing.Point(1329, 853);
            this.txtDescrizioneArticolo.Name = "txtDescrizioneArticolo";
            this.txtDescrizioneArticolo.Size = new System.Drawing.Size(503, 22);
            this.txtDescrizioneArticolo.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(72, 910);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 16);
            this.label14.TabIndex = 16;
            this.label14.Text = "Stagione";
            // 
            // txtStagione
            // 
            this.txtStagione.Location = new System.Drawing.Point(144, 907);
            this.txtStagione.Name = "txtStagione";
            this.txtStagione.Size = new System.Drawing.Size(139, 22);
            this.txtStagione.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(373, 910);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 16);
            this.label15.TabIndex = 16;
            this.label15.Text = "Evento";
            // 
            // txtEvento
            // 
            this.txtEvento.Location = new System.Drawing.Point(433, 907);
            this.txtEvento.Name = "txtEvento";
            this.txtEvento.Size = new System.Drawing.Size(139, 22);
            this.txtEvento.TabIndex = 17;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(684, 910);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 16);
            this.label16.TabIndex = 16;
            this.label16.Text = "Data";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(48, 976);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 16);
            this.label17.TabIndex = 16;
            this.label17.Text = "Spessore Au";
            // 
            // txtSpessoreAu
            // 
            this.txtSpessoreAu.Location = new System.Drawing.Point(144, 973);
            this.txtSpessoreAu.Name = "txtSpessoreAu";
            this.txtSpessoreAu.Size = new System.Drawing.Size(139, 22);
            this.txtSpessoreAu.TabIndex = 17;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(336, 976);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 16);
            this.label18.TabIndex = 16;
            this.label18.Text = "Spessore Pd";
            // 
            // txtSpessorePd
            // 
            this.txtSpessorePd.Location = new System.Drawing.Point(433, 973);
            this.txtSpessorePd.Name = "txtSpessorePd";
            this.txtSpessorePd.Size = new System.Drawing.Size(139, 22);
            this.txtSpessorePd.TabIndex = 17;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(653, 976);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 16);
            this.label19.TabIndex = 16;
            this.label19.Text = "Superficie";
            // 
            // txtSuperficie
            // 
            this.txtSuperficie.Location = new System.Drawing.Point(733, 973);
            this.txtSuperficie.Name = "txtSuperficie";
            this.txtSuperficie.Size = new System.Drawing.Size(139, 22);
            this.txtSuperficie.TabIndex = 17;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(972, 976);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 16);
            this.label20.TabIndex = 16;
            this.label20.Text = "Peso";
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(1022, 973);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(139, 22);
            this.txtPeso.TabIndex = 17;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 1043);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(148, 16);
            this.label21.TabIndex = 16;
            this.label21.Text = "Composizione materiali";
            // 
            // txtComposizioneMateriali
            // 
            this.txtComposizioneMateriali.Location = new System.Drawing.Point(167, 1043);
            this.txtComposizioneMateriali.Multiline = true;
            this.txtComposizioneMateriali.Name = "txtComposizioneMateriali";
            this.txtComposizioneMateriali.Size = new System.Drawing.Size(735, 73);
            this.txtComposizioneMateriali.TabIndex = 17;
            // 
            // dtData
            // 
            this.dtData.Location = new System.Drawing.Point(733, 908);
            this.dtData.Name = "dtData";
            this.dtData.Size = new System.Drawing.Size(200, 22);
            this.dtData.TabIndex = 18;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.dgvLavorazioniEsterne);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(5, 1659);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox8.Size = new System.Drawing.Size(1839, 228);
            this.groupBox8.TabIndex = 15;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Lavorazioni esterne";
            // 
            // dgvLavorazioniEsterne
            // 
            this.dgvLavorazioniEsterne.AllowUserToAddRows = false;
            this.dgvLavorazioniEsterne.AllowUserToDeleteRows = false;
            this.dgvLavorazioniEsterne.AllowUserToOrderColumns = true;
            this.dgvLavorazioniEsterne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLavorazioniEsterne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLavorazioniEsterne.Location = new System.Drawing.Point(4, 19);
            this.dgvLavorazioniEsterne.Name = "dgvLavorazioniEsterne";
            this.dgvLavorazioniEsterne.ReadOnly = true;
            this.dgvLavorazioniEsterne.Size = new System.Drawing.Size(1831, 205);
            this.dgvLavorazioniEsterne.TabIndex = 0;
            // 
            // BalenciagaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1845, 843);
            this.Controls.Add(this.panel1);
            this.Name = "BalenciagaFrm";
            this.Text = "BALENCIAGA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BalenciagaFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.preventiviDSBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrezzo)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLavorazioniInterne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRicarico)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGruppiDettaglio)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGruppi)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostiFissi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLavorazioniEsterne)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource preventiviDSBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPrezzo;
        private System.Windows.Forms.NumericUpDown nRicarico;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvGruppiDettaglio;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvGruppi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvCostiFissi;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODVOCECOSTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESVOCECOSTO;
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.TextBox txtModello;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTrova;
        private System.Windows.Forms.TextBox txtRiferimento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvLavorazioniInterne;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView dgvGrezzo;
        private System.Windows.Forms.TextBox txtDescrizioneArticolo;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.TextBox txtFornitore;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSuperficie;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtCodiceGalvanica;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSpessorePd;
        private System.Windows.Forms.TextBox txtEvento;
        private System.Windows.Forms.TextBox txtCodiceDefinitivo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtComposizioneMateriali;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtSpessoreAu;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtStagione;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCodiceProvvisorio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtData;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView dgvLavorazioniEsterne;
    }
}