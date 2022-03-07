namespace EtichetteMagazzinoBC
{
    partial class Form1
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
            this.ddlStampanti = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMessaggi = new System.Windows.Forms.TextBox();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStampa = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ddlStampanti
            // 
            this.ddlStampanti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStampanti.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlStampanti.FormattingEnabled = true;
            this.ddlStampanti.Location = new System.Drawing.Point(103, 27);
            this.ddlStampanti.Margin = new System.Windows.Forms.Padding(4);
            this.ddlStampanti.Name = "ddlStampanti";
            this.ddlStampanti.Size = new System.Drawing.Size(528, 26);
            this.ddlStampanti.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "Stampanti";
            // 
            // txtMessaggi
            // 
            this.txtMessaggi.Location = new System.Drawing.Point(83, 196);
            this.txtMessaggi.Multiline = true;
            this.txtMessaggi.Name = "txtMessaggi";
            this.txtMessaggi.Size = new System.Drawing.Size(444, 197);
            this.txtMessaggi.TabIndex = 15;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(83, 88);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(314, 20);
            this.txtFile.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "FIle";
            // 
            // btnStampa
            // 
            this.btnStampa.Location = new System.Drawing.Point(598, 86);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(75, 23);
            this.btnStampa.TabIndex = 12;
            this.btnStampa.Text = "Stampa";
            this.btnStampa.UseVisualStyleBackColor = true;
            this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(434, 86);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 11;
            this.btnOpenFile.Text = "Browse...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ddlStampanti);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMessaggi);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStampa);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlStampanti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMessaggi;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStampa;
        private System.Windows.Forms.Button btnOpenFile;
    }
}

