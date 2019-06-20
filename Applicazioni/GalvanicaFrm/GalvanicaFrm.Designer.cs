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
            ((System.ComponentModel.ISupportInitialize)(this.dgvGriglia)).BeginInit();
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
            this.dgvGriglia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGriglia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGriglia.Location = new System.Drawing.Point(12, 74);
            this.dgvGriglia.Name = "dgvGriglia";
            this.dgvGriglia.Size = new System.Drawing.Size(1100, 601);
            this.dgvGriglia.TabIndex = 5;
            this.dgvGriglia.TabStop = false;
            this.dgvGriglia.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGriglia_CellFormatting);
            this.dgvGriglia.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGriglia_CellValueChanged);
            this.dgvGriglia.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvGriglia_UserDeletingRow);
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
            this.Name = "GalvanicaFrm";
            this.Text = "Galvanica";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GalvanicaFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGriglia)).EndInit();
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
    }
}

