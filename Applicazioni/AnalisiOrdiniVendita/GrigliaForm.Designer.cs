namespace AnalisiOrdiniVendita
{
    partial class GrigliaForm
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
            this.chkNascandiCompletate = new System.Windows.Forms.CheckBox();
            this.chkNascondiAnnullate = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkNascandiCompletate
            // 
            this.chkNascandiCompletate.AutoSize = true;
            this.chkNascandiCompletate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNascandiCompletate.Checked = true;
            this.chkNascandiCompletate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNascandiCompletate.Location = new System.Drawing.Point(195, 13);
            this.chkNascandiCompletate.Name = "chkNascandiCompletate";
            this.chkNascandiCompletate.Size = new System.Drawing.Size(126, 17);
            this.chkNascandiCompletate.TabIndex = 5;
            this.chkNascandiCompletate.Text = "Nascondi completate";
            this.chkNascandiCompletate.UseVisualStyleBackColor = true;
            this.chkNascandiCompletate.CheckedChanged += new System.EventHandler(this.chkNascondiAnnullate_CheckedChanged);
            // 
            // chkNascondiAnnullate
            // 
            this.chkNascondiAnnullate.AutoSize = true;
            this.chkNascondiAnnullate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNascondiAnnullate.Checked = true;
            this.chkNascondiAnnullate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNascondiAnnullate.Location = new System.Drawing.Point(45, 12);
            this.chkNascondiAnnullate.Name = "chkNascondiAnnullate";
            this.chkNascondiAnnullate.Size = new System.Drawing.Size(117, 17);
            this.chkNascondiAnnullate.TabIndex = 4;
            this.chkNascondiAnnullate.Text = "Nascondi annullate";
            this.chkNascondiAnnullate.UseVisualStyleBackColor = true;
            this.chkNascondiAnnullate.CheckedChanged += new System.EventHandler(this.chkNascondiAnnullate_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1306, 743);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // GrigliaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 790);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chkNascandiCompletate);
            this.Controls.Add(this.chkNascondiAnnullate);
            this.Name = "GrigliaForm";
            this.Text = "GrigliaForm";
            this.Load += new System.EventHandler(this.GrigliaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkNascandiCompletate;
        private System.Windows.Forms.CheckBox chkNascondiAnnullate;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}