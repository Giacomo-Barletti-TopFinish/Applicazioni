namespace AnalisiOrdiniVendita
{
    partial class CommessaForm
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
            this.pannello = new System.Windows.Forms.TableLayoutPanel();
            this.chkNascondiAnnullate = new System.Windows.Forms.CheckBox();
            this.chkNascandiCompletate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // pannello
            // 
            this.pannello.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pannello.AutoScroll = true;
            this.pannello.ColumnCount = 1;
            this.pannello.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pannello.Location = new System.Drawing.Point(0, 34);
            this.pannello.Name = "pannello";
            this.pannello.RowCount = 1;
            this.pannello.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pannello.Size = new System.Drawing.Size(1330, 756);
            this.pannello.TabIndex = 1;
            // 
            // chkNascondiAnnullate
            // 
            this.chkNascondiAnnullate.AutoSize = true;
            this.chkNascondiAnnullate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNascondiAnnullate.Checked = true;
            this.chkNascondiAnnullate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNascondiAnnullate.Location = new System.Drawing.Point(27, 11);
            this.chkNascondiAnnullate.Name = "chkNascondiAnnullate";
            this.chkNascondiAnnullate.Size = new System.Drawing.Size(117, 17);
            this.chkNascondiAnnullate.TabIndex = 2;
            this.chkNascondiAnnullate.Text = "Nascondi annullate";
            this.chkNascondiAnnullate.UseVisualStyleBackColor = true;
            this.chkNascondiAnnullate.CheckedChanged += new System.EventHandler(this.chkNascondiAnnullate_CheckedChanged);
            // 
            // chkNascandiCompletate
            // 
            this.chkNascandiCompletate.AutoSize = true;
            this.chkNascandiCompletate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNascandiCompletate.Checked = true;
            this.chkNascandiCompletate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNascandiCompletate.Location = new System.Drawing.Point(177, 12);
            this.chkNascandiCompletate.Name = "chkNascandiCompletate";
            this.chkNascandiCompletate.Size = new System.Drawing.Size(126, 17);
            this.chkNascandiCompletate.TabIndex = 3;
            this.chkNascandiCompletate.Text = "Nascondi completate";
            this.chkNascandiCompletate.UseVisualStyleBackColor = true;
            this.chkNascandiCompletate.CheckedChanged += new System.EventHandler(this.chkNascandiCompletate_CheckedChanged);
            // 
            // CommessaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 790);
            this.Controls.Add(this.chkNascandiCompletate);
            this.Controls.Add(this.chkNascondiAnnullate);
            this.Controls.Add(this.pannello);
            this.Name = "CommessaForm";
            this.Text = "CommessaForm";
            this.Load += new System.EventHandler(this.CommessaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pannello;
        private System.Windows.Forms.CheckBox chkNascondiAnnullate;
        private System.Windows.Forms.CheckBox chkNascandiCompletate;
    }
}