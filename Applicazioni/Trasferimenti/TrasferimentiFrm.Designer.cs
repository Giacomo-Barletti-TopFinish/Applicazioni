namespace Trasferimenti
{
    partial class TrasferimentiFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnPulisci = new System.Windows.Forms.Button();
            this.dgvTrasferimenti = new System.Windows.Forms.DataGridView();
            this.lblMessaggi = new System.Windows.Forms.Label();
            this.txtLedInTrasferimento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrasferimenti)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barcode";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(108, 7);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(254, 24);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // btnPulisci
            // 
            this.btnPulisci.Location = new System.Drawing.Point(401, 3);
            this.btnPulisci.Name = "btnPulisci";
            this.btnPulisci.Size = new System.Drawing.Size(91, 32);
            this.btnPulisci.TabIndex = 2;
            this.btnPulisci.Text = "Pulisci";
            this.btnPulisci.UseVisualStyleBackColor = true;
            this.btnPulisci.Click += new System.EventHandler(this.btnPulisci_Click);
            // 
            // dgvTrasferimenti
            // 
            this.dgvTrasferimenti.AllowUserToAddRows = false;
            this.dgvTrasferimenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTrasferimenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrasferimenti.Location = new System.Drawing.Point(15, 76);
            this.dgvTrasferimenti.Name = "dgvTrasferimenti";
            this.dgvTrasferimenti.ReadOnly = true;
            this.dgvTrasferimenti.Size = new System.Drawing.Size(762, 285);
            this.dgvTrasferimenti.TabIndex = 3;
            this.dgvTrasferimenti.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvTrasferimenti_UserDeletingRow);
            // 
            // lblMessaggi
            // 
            this.lblMessaggi.AutoSize = true;
            this.lblMessaggi.ForeColor = System.Drawing.Color.Red;
            this.lblMessaggi.Location = new System.Drawing.Point(12, 45);
            this.lblMessaggi.Name = "lblMessaggi";
            this.lblMessaggi.Size = new System.Drawing.Size(72, 18);
            this.lblMessaggi.TabIndex = 0;
            this.lblMessaggi.Text = "Messaggi";
            // 
            // txtLedInTrasferimento
            // 
            this.txtLedInTrasferimento.Location = new System.Drawing.Point(727, 7);
            this.txtLedInTrasferimento.Name = "txtLedInTrasferimento";
            this.txtLedInTrasferimento.ReadOnly = true;
            this.txtLedInTrasferimento.Size = new System.Drawing.Size(25, 24);
            this.txtLedInTrasferimento.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(611, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "In trasferimento";
            // 
            // TrasferimentiFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 418);
            this.Controls.Add(this.txtLedInTrasferimento);
            this.Controls.Add(this.dgvTrasferimenti);
            this.Controls.Add(this.btnPulisci);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lblMessaggi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrasferimentiFrm";
            this.Text = "Trasferimenti";
            this.Load += new System.EventHandler(this.TrasferimentiFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrasferimenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnPulisci;
        private System.Windows.Forms.DataGridView dgvTrasferimenti;
        private System.Windows.Forms.Label lblMessaggi;
        private System.Windows.Forms.TextBox txtLedInTrasferimento;
        private System.Windows.Forms.Label label2;
    }
}

