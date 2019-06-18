namespace GalvanicaFrm
{
    partial class GalvanicaFrm
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
            this.lblMessaggi = new System.Windows.Forms.Label();
            this.lblSettimana = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgvGriglia = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.analisiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esportaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGriglia)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessaggi
            // 
            this.lblMessaggi.AutoSize = true;
            this.lblMessaggi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessaggi.ForeColor = System.Drawing.Color.Red;
            this.lblMessaggi.Location = new System.Drawing.Point(252, 36);
            this.lblMessaggi.Name = "lblMessaggi";
            this.lblMessaggi.Size = new System.Drawing.Size(45, 16);
            this.lblMessaggi.TabIndex = 9;
            this.lblMessaggi.Text = "label1";
            // 
            // lblSettimana
            // 
            this.lblSettimana.AutoSize = true;
            this.lblSettimana.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettimana.Location = new System.Drawing.Point(12, 36);
            this.lblSettimana.Name = "lblSettimana";
            this.lblSettimana.Size = new System.Drawing.Size(45, 16);
            this.lblSettimana.TabIndex = 10;
            this.lblSettimana.Text = "label1";
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(726, 36);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(146, 23);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvGriglia
            // 
            this.dgvGriglia.AllowUserToAddRows = false;
            this.dgvGriglia.AllowUserToDeleteRows = false;
            this.dgvGriglia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGriglia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGriglia.Location = new System.Drawing.Point(12, 74);
            this.dgvGriglia.Name = "dgvGriglia";
            this.dgvGriglia.Size = new System.Drawing.Size(1100, 601);
            this.dgvGriglia.TabIndex = 5;
            this.dgvGriglia.TabStop = false;
            this.dgvGriglia.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGriglia_CellValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analisiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1124, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // analisiToolStripMenuItem
            // 
            this.analisiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.esportaToolStripMenuItem});
            this.analisiToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.analisiToolStripMenuItem.Name = "analisiToolStripMenuItem";
            this.analisiToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.analisiToolStripMenuItem.Text = "Analisi";
            this.analisiToolStripMenuItem.Visible = false;
            // 
            // esportaToolStripMenuItem
            // 
            this.esportaToolStripMenuItem.Name = "esportaToolStripMenuItem";
            this.esportaToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.esportaToolStripMenuItem.Text = "Esporta";
            // 
            // GalvanicaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 692);
            this.Controls.Add(this.lblMessaggi);
            this.Controls.Add(this.lblSettimana);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvGriglia);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GalvanicaFrm";
            this.Text = "Galvanica";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GalvanicaFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGriglia)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMessaggi;
        private System.Windows.Forms.Label lblSettimana;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvGriglia;
        private System.Windows.Forms.DataGridViewTextBoxColumn BRAND;
        private System.Windows.Forms.DataGridViewButtonColumn MODELLO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPONENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FINITURA;
        private System.Windows.Forms.DataGridViewTextBoxColumn MATERIALE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PEZZIBARRA;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITA;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPERIFICIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn BARRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRIORITA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPOGALVANICA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIANIFICATI;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATA1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATA2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATA3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATA4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATA5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATA6;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATA7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem analisiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esportaToolStripMenuItem;
    }
}

