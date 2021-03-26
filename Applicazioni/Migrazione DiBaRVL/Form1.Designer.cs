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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtMsgAnagrafiche = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtMsgCicli = new System.Windows.Forms.TextBox();
            this.chkSalvaAnagrafiche = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtMsgDistinte = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
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
            this.txtRisultati.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRisultati.Location = new System.Drawing.Point(3, 3);
            this.txtRisultati.Multiline = true;
            this.txtRisultati.Name = "txtRisultati";
            this.txtRisultati.ReadOnly = true;
            this.txtRisultati.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRisultati.Size = new System.Drawing.Size(858, 423);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(15, 125);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(872, 458);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtRisultati);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(864, 429);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Messaggi";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtMsgAnagrafiche);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(864, 429);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Anagrafiche";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtMsgAnagrafiche
            // 
            this.txtMsgAnagrafiche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsgAnagrafiche.Location = new System.Drawing.Point(3, 3);
            this.txtMsgAnagrafiche.Multiline = true;
            this.txtMsgAnagrafiche.Name = "txtMsgAnagrafiche";
            this.txtMsgAnagrafiche.ReadOnly = true;
            this.txtMsgAnagrafiche.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgAnagrafiche.Size = new System.Drawing.Size(858, 423);
            this.txtMsgAnagrafiche.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtMsgCicli);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(864, 429);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cicli";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtMsgCicli
            // 
            this.txtMsgCicli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsgCicli.Location = new System.Drawing.Point(3, 3);
            this.txtMsgCicli.Multiline = true;
            this.txtMsgCicli.Name = "txtMsgCicli";
            this.txtMsgCicli.ReadOnly = true;
            this.txtMsgCicli.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgCicli.Size = new System.Drawing.Size(858, 423);
            this.txtMsgCicli.TabIndex = 0;
            // 
            // chkSalvaAnagrafiche
            // 
            this.chkSalvaAnagrafiche.AutoSize = true;
            this.chkSalvaAnagrafiche.Location = new System.Drawing.Point(110, 76);
            this.chkSalvaAnagrafiche.Name = "chkSalvaAnagrafiche";
            this.chkSalvaAnagrafiche.Size = new System.Drawing.Size(151, 20);
            this.chkSalvaAnagrafiche.TabIndex = 6;
            this.chkSalvaAnagrafiche.Text = "Salva ANAGRAFICA";
            this.chkSalvaAnagrafiche.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtMsgDistinte);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(864, 429);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Distinte";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtMsgDistinte
            // 
            this.txtMsgDistinte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsgDistinte.Location = new System.Drawing.Point(3, 3);
            this.txtMsgDistinte.Multiline = true;
            this.txtMsgDistinte.Name = "txtMsgDistinte";
            this.txtMsgDistinte.ReadOnly = true;
            this.txtMsgDistinte.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgDistinte.Size = new System.Drawing.Size(858, 423);
            this.txtMsgDistinte.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 607);
            this.Controls.Add(this.chkSalvaAnagrafiche);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnApri);
            this.Controls.Add(this.btnCercaFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Migrazione DiBa";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnCercaFile;
        private System.Windows.Forms.TextBox txtRisultati;
        private System.Windows.Forms.Button btnApri;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtMsgAnagrafiche;
        private System.Windows.Forms.CheckBox chkSalvaAnagrafiche;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtMsgCicli;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtMsgDistinte;
    }
}

