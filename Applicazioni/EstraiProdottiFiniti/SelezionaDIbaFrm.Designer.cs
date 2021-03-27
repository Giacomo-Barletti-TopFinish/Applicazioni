namespace EstraiProdottiFiniti
{
    partial class SelezionaDIbaFrm
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
            this.dgvDiBa = new System.Windows.Forms.DataGridView();
            this.iDTDIBADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mODELLODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESVERSIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vERSIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOTESTDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOTETECHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estraiProdottiFinitiDS1 = new Applicazioni.Entities.EstraiProdottiFinitiDS();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiBa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estraiProdottiFinitiDS1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDiBa
            // 
            this.dgvDiBa.AllowUserToAddRows = false;
            this.dgvDiBa.AllowUserToDeleteRows = false;
            this.dgvDiBa.AutoGenerateColumns = false;
            this.dgvDiBa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiBa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDTDIBADataGridViewTextBoxColumn,
            this.mODELLODataGridViewTextBoxColumn,
            this.dESVERSIONDataGridViewTextBoxColumn,
            this.vERSIONDataGridViewTextBoxColumn,
            this.nOTESTDDataGridViewTextBoxColumn,
            this.nOTETECHDataGridViewTextBoxColumn});
            this.dgvDiBa.DataMember = "USR_PRD_TDIBA";
            this.dgvDiBa.DataSource = this.estraiProdottiFinitiDS1;
            this.dgvDiBa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiBa.Location = new System.Drawing.Point(0, 0);
            this.dgvDiBa.Name = "dgvDiBa";
            this.dgvDiBa.ReadOnly = true;
            this.dgvDiBa.Size = new System.Drawing.Size(800, 450);
            this.dgvDiBa.TabIndex = 0;
            this.dgvDiBa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiBa_CellDoubleClick);
            // 
            // iDTDIBADataGridViewTextBoxColumn
            // 
            this.iDTDIBADataGridViewTextBoxColumn.DataPropertyName = "IDTDIBA";
            this.iDTDIBADataGridViewTextBoxColumn.HeaderText = "IDTDIBA";
            this.iDTDIBADataGridViewTextBoxColumn.Name = "iDTDIBADataGridViewTextBoxColumn";
            this.iDTDIBADataGridViewTextBoxColumn.ReadOnly = true;
            this.iDTDIBADataGridViewTextBoxColumn.Visible = false;
            // 
            // mODELLODataGridViewTextBoxColumn
            // 
            this.mODELLODataGridViewTextBoxColumn.DataPropertyName = "MODELLO";
            this.mODELLODataGridViewTextBoxColumn.HeaderText = "MODELLO";
            this.mODELLODataGridViewTextBoxColumn.Name = "mODELLODataGridViewTextBoxColumn";
            this.mODELLODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dESVERSIONDataGridViewTextBoxColumn
            // 
            this.dESVERSIONDataGridViewTextBoxColumn.DataPropertyName = "DESVERSION";
            this.dESVERSIONDataGridViewTextBoxColumn.HeaderText = "VERSIONE";
            this.dESVERSIONDataGridViewTextBoxColumn.Name = "dESVERSIONDataGridViewTextBoxColumn";
            this.dESVERSIONDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vERSIONDataGridViewTextBoxColumn
            // 
            this.vERSIONDataGridViewTextBoxColumn.DataPropertyName = "VERSION";
            this.vERSIONDataGridViewTextBoxColumn.HeaderText = "DESCRIZIONE";
            this.vERSIONDataGridViewTextBoxColumn.Name = "vERSIONDataGridViewTextBoxColumn";
            this.vERSIONDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nOTESTDDataGridViewTextBoxColumn
            // 
            this.nOTESTDDataGridViewTextBoxColumn.DataPropertyName = "NOTESTD";
            this.nOTESTDDataGridViewTextBoxColumn.HeaderText = "NOTE STANDARD";
            this.nOTESTDDataGridViewTextBoxColumn.Name = "nOTESTDDataGridViewTextBoxColumn";
            this.nOTESTDDataGridViewTextBoxColumn.ReadOnly = true;
            this.nOTESTDDataGridViewTextBoxColumn.Width = 200;
            // 
            // nOTETECHDataGridViewTextBoxColumn
            // 
            this.nOTETECHDataGridViewTextBoxColumn.DataPropertyName = "NOTETECH";
            this.nOTETECHDataGridViewTextBoxColumn.HeaderText = "NOTE TECINICHE";
            this.nOTETECHDataGridViewTextBoxColumn.Name = "nOTETECHDataGridViewTextBoxColumn";
            this.nOTETECHDataGridViewTextBoxColumn.ReadOnly = true;
            this.nOTETECHDataGridViewTextBoxColumn.Width = 200;
            // 
            // estraiProdottiFinitiDS1
            // 
            this.estraiProdottiFinitiDS1.DataSetName = "EstraiProdottiFinitiDS";
            this.estraiProdottiFinitiDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SelezionaDIbaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvDiBa);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelezionaDIbaFrm";
            this.Text = "Seleziona Diba";
            this.Load += new System.EventHandler(this.SelezionaDIbaFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiBa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estraiProdottiFinitiDS1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDiBa;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDTDIBADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mODELLODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESVERSIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vERSIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOTESTDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOTETECHDataGridViewTextBoxColumn;
        public Applicazioni.Entities.EstraiProdottiFinitiDS estraiProdottiFinitiDS1;
    }
}