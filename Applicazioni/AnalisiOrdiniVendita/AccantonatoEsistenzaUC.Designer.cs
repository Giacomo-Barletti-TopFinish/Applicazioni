namespace AnalisiOrdiniVendita
{
    partial class AccantonatoEsistenzaUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtQtaDestinazione = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQtaOrigine = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtModello = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDestinazione = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtQtaDestinazione
            // 
            this.txtQtaDestinazione.Location = new System.Drawing.Point(880, 14);
            this.txtQtaDestinazione.Name = "txtQtaDestinazione";
            this.txtQtaDestinazione.ReadOnly = true;
            this.txtQtaDestinazione.Size = new System.Drawing.Size(100, 20);
            this.txtQtaDestinazione.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(877, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Quantità destinazione";
            // 
            // txtQtaOrigine
            // 
            this.txtQtaOrigine.Location = new System.Drawing.Point(764, 14);
            this.txtQtaOrigine.Name = "txtQtaOrigine";
            this.txtQtaOrigine.ReadOnly = true;
            this.txtQtaOrigine.Size = new System.Drawing.Size(100, 20);
            this.txtQtaOrigine.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(761, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Quantità origine";
            // 
            // txtModello
            // 
            this.txtModello.Location = new System.Drawing.Point(134, 14);
            this.txtModello.Name = "txtModello";
            this.txtModello.ReadOnly = true;
            this.txtModello.Size = new System.Drawing.Size(160, 20);
            this.txtModello.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Modello";
            // 
            // txtDestinazione
            // 
            this.txtDestinazione.Location = new System.Drawing.Point(315, 14);
            this.txtDestinazione.Name = "txtDestinazione";
            this.txtDestinazione.ReadOnly = true;
            this.txtDestinazione.Size = new System.Drawing.Size(304, 20);
            this.txtDestinazione.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Destinazione";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "ACC ESI";
            // 
            // AccantonatoEsistenzaUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQtaDestinazione);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtQtaOrigine);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDestinazione);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtModello);
            this.Controls.Add(this.label2);
            this.Name = "AccantonatoEsistenzaUC";
            this.Size = new System.Drawing.Size(1220, 35);
            this.Load += new System.EventHandler(this.AccantonatoEsistenzaUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQtaDestinazione;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQtaOrigine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtModello;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestinazione;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
    }
}
