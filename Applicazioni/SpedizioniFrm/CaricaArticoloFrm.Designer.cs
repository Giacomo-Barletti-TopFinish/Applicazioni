namespace SpedizioniFrm
{
    partial class CaricaArticoloFrm
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
            this.txtarticolo = new System.Windows.Forms.TextBox();
            this.btnricerca = new System.Windows.Forms.Button();
            this.lblarticolo = new System.Windows.Forms.Label();
            this.txtmodello = new System.Windows.Forms.TextBox();
            this.txtquantita = new System.Windows.Forms.TextBox();
            this.lblmodello = new System.Windows.Forms.Label();
            this.lblquantita = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblEsito = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtarticolo
            // 
            this.txtarticolo.Location = new System.Drawing.Point(56, 53);
            this.txtarticolo.MaxLength = 30;
            this.txtarticolo.Name = "txtarticolo";
            this.txtarticolo.Size = new System.Drawing.Size(170, 20);
            this.txtarticolo.TabIndex = 0;
            // 
            // btnricerca
            // 
            this.btnricerca.Location = new System.Drawing.Point(232, 50);
            this.btnricerca.Name = "btnricerca";
            this.btnricerca.Size = new System.Drawing.Size(75, 23);
            this.btnricerca.TabIndex = 2;
            this.btnricerca.Text = "Ricerca";
            this.btnricerca.UseVisualStyleBackColor = true;
            this.btnricerca.Click += new System.EventHandler(this.btnricerca_Click_1);
            // 
            // lblarticolo
            // 
            this.lblarticolo.AutoSize = true;
            this.lblarticolo.Location = new System.Drawing.Point(56, 34);
            this.lblarticolo.Name = "lblarticolo";
            this.lblarticolo.Size = new System.Drawing.Size(42, 13);
            this.lblarticolo.TabIndex = 4;
            this.lblarticolo.Text = "Articolo";
            // 
            // txtmodello
            // 
            this.txtmodello.Location = new System.Drawing.Point(57, 120);
            this.txtmodello.Name = "txtmodello";
            this.txtmodello.Size = new System.Drawing.Size(100, 20);
            this.txtmodello.TabIndex = 6;
            // 
            // txtquantita
            // 
            this.txtquantita.Location = new System.Drawing.Point(242, 120);
            this.txtquantita.Name = "txtquantita";
            this.txtquantita.Size = new System.Drawing.Size(100, 20);
            this.txtquantita.TabIndex = 7;
            // 
            // lblmodello
            // 
            this.lblmodello.AutoSize = true;
            this.lblmodello.Location = new System.Drawing.Point(57, 102);
            this.lblmodello.Name = "lblmodello";
            this.lblmodello.Size = new System.Drawing.Size(60, 13);
            this.lblmodello.TabIndex = 9;
            this.lblmodello.Text = "Ubicazione";
            // 
            // lblquantita
            // 
            this.lblquantita.AutoSize = true;
            this.lblquantita.Location = new System.Drawing.Point(242, 102);
            this.lblquantita.Name = "lblquantita";
            this.lblquantita.Size = new System.Drawing.Size(47, 13);
            this.lblquantita.TabIndex = 10;
            this.lblquantita.Text = "Quantita";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Causale";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(56, 203);
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 20);
            this.textBox1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Salva";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnricerca_Click_1);
            // 
            // lblEsito
            // 
            this.lblEsito.AutoSize = true;
            this.lblEsito.Location = new System.Drawing.Point(53, 337);
            this.lblEsito.Name = "lblEsito";
            this.lblEsito.Size = new System.Drawing.Size(30, 13);
            this.lblEsito.TabIndex = 12;
            this.lblEsito.Text = "Esito";
            // 
            // CaricaArticoloFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 450);
            this.Controls.Add(this.lblEsito);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblquantita);
            this.Controls.Add(this.lblmodello);
            this.Controls.Add(this.txtquantita);
            this.Controls.Add(this.txtmodello);
            this.Controls.Add(this.lblarticolo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnricerca);
            this.Controls.Add(this.txtarticolo);
            this.Name = "CaricaArticoloFrm";
            this.Text = "CaricaArticolo";
            this.Load += new System.EventHandler(this.CaricaArticoloFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtarticolo;
        private System.Windows.Forms.Button btnricerca;
        private System.Windows.Forms.Label lblarticolo;
        private System.Windows.Forms.TextBox txtmodello;
        private System.Windows.Forms.TextBox txtquantita;
        private System.Windows.Forms.Label lblmodello;
        private System.Windows.Forms.Label lblquantita;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblEsito;
    }
}