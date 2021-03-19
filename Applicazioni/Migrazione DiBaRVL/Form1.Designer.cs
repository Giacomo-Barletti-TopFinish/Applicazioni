namespace Migrazione_DiBaRVL
{
    partial class MainForm
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
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnCercaFile = new System.Windows.Forms.Button();
            this.txtRisultati = new System.Windows.Forms.TextBox();
            this.btnApri = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "File origine";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(110, 31);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(528, 22);
            this.txtFile.TabIndex = 1;
            // 
            // btnCercaFile
            // 
            this.btnCercaFile.Location = new System.Drawing.Point(676, 27);
            this.btnCercaFile.Name = "btnCercaFile";
            this.btnCercaFile.Size = new System.Drawing.Size(75, 30);
            this.btnCercaFile.TabIndex = 2;
            this.btnCercaFile.Text = "Cerca";
            this.btnCercaFile.UseVisualStyleBackColor = true;
            this.btnCercaFile.Click += new System.EventHandler(this.btnCercaFile_Click);
            // 
            // txtRisultati
            // 
            this.txtRisultati.Location = new System.Drawing.Point(110, 93);
            this.txtRisultati.Multiline = true;
            this.txtRisultati.Name = "txtRisultati";
            this.txtRisultati.ReadOnly = true;
            this.txtRisultati.Size = new System.Drawing.Size(752, 465);
            this.txtRisultati.TabIndex = 3;
            // 
            // btnApri
            // 
            this.btnApri.Location = new System.Drawing.Point(787, 27);
            this.btnApri.Name = "btnApri";
            this.btnApri.Size = new System.Drawing.Size(75, 30);
            this.btnApri.TabIndex = 4;
            this.btnApri.Text = "Apri";
            this.btnApri.UseVisualStyleBackColor = true;
            this.btnApri.Click += new System.EventHandler(this.btnApri_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 607);
            this.Controls.Add(this.btnApri);
            this.Controls.Add(this.txtRisultati);
            this.Controls.Add(this.btnCercaFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Migrazione DiBa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnCercaFile;
        private System.Windows.Forms.TextBox txtRisultati;
        private System.Windows.Forms.Button btnApri;
    }
}

