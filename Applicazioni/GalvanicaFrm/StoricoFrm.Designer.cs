namespace GalvanicaFrm
{
    partial class StoricoFrm
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
            this.dgvGriglia = new System.Windows.Forms.DataGridView();
            this.dtGiorno = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGriglia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessaggi
            // 
            this.lblMessaggi.AutoSize = true;
            this.lblMessaggi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessaggi.ForeColor = System.Drawing.Color.Red;
            this.lblMessaggi.Location = new System.Drawing.Point(38, 60);
            this.lblMessaggi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessaggi.Name = "lblMessaggi";
            this.lblMessaggi.Size = new System.Drawing.Size(45, 16);
            this.lblMessaggi.TabIndex = 11;
            this.lblMessaggi.Text = "label1";
            // 
            // lblSettimana
            // 
            this.lblSettimana.AutoSize = true;
            this.lblSettimana.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettimana.Location = new System.Drawing.Point(330, 28);
            this.lblSettimana.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSettimana.Name = "lblSettimana";
            this.lblSettimana.Size = new System.Drawing.Size(45, 16);
            this.lblSettimana.TabIndex = 12;
            this.lblSettimana.Text = "label1";
            // 
            // dgvGriglia
            // 
            this.dgvGriglia.AllowUserToAddRows = false;
            this.dgvGriglia.AllowUserToDeleteRows = false;
            this.dgvGriglia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGriglia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGriglia.Location = new System.Drawing.Point(16, 97);
            this.dgvGriglia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvGriglia.Name = "dgvGriglia";
            this.dgvGriglia.Size = new System.Drawing.Size(1467, 740);
            this.dgvGriglia.TabIndex = 13;
            this.dgvGriglia.TabStop = false;
            // 
            // dtGiorno
            // 
            this.dtGiorno.Location = new System.Drawing.Point(32, 23);
            this.dtGiorno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtGiorno.Name = "dtGiorno";
            this.dtGiorno.Size = new System.Drawing.Size(265, 22);
            this.dtGiorno.TabIndex = 14;
            this.dtGiorno.ValueChanged += new System.EventHandler(this.dtGiorno_ValueChanged);
            // 
            // StoricoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1499, 852);
            this.Controls.Add(this.dtGiorno);
            this.Controls.Add(this.dgvGriglia);
            this.Controls.Add(this.lblMessaggi);
            this.Controls.Add(this.lblSettimana);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StoricoFrm";
            this.Text = "Storico";
            this.Load += new System.EventHandler(this.StoricoFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGriglia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessaggi;
        private System.Windows.Forms.Label lblSettimana;
        private System.Windows.Forms.DataGridView dgvGriglia;
        private System.Windows.Forms.DateTimePicker dtGiorno;
    }
}