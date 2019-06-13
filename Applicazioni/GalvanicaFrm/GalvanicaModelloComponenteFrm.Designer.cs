namespace GalvanicaFrm
{
    partial class GalvanicaModelloComponenteFrm
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
            this.lblModello = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlBrand = new System.Windows.Forms.ComboBox();
            this.ddlGalvanica = new System.Windows.Forms.ComboBox();
            this.txtSuperficie = new System.Windows.Forms.TextBox();
            this.nPezziBarra = new System.Windows.Forms.NumericUpDown();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.txtFinitura = new System.Windows.Forms.TextBox();
            this.ddlMateriale = new System.Windows.Forms.ComboBox();
            this.lblMessaggio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nPezziBarra)).BeginInit();
            this.SuspendLayout();
            // 
            // lblModello
            // 
            this.lblModello.AutoSize = true;
            this.lblModello.Location = new System.Drawing.Point(30, 13);
            this.lblModello.Name = "lblModello";
            this.lblModello.Size = new System.Drawing.Size(45, 16);
            this.lblModello.TabIndex = 0;
            this.lblModello.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Brand";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Finitura";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Materiale";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Pezzi barra";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Superficie mm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Galvanica";
            // 
            // ddlBrand
            // 
            this.ddlBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBrand.FormattingEnabled = true;
            this.ddlBrand.Location = new System.Drawing.Point(141, 77);
            this.ddlBrand.Name = "ddlBrand";
            this.ddlBrand.Size = new System.Drawing.Size(253, 24);
            this.ddlBrand.TabIndex = 1;
            // 
            // ddlGalvanica
            // 
            this.ddlGalvanica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGalvanica.FormattingEnabled = true;
            this.ddlGalvanica.Location = new System.Drawing.Point(141, 268);
            this.ddlGalvanica.Name = "ddlGalvanica";
            this.ddlGalvanica.Size = new System.Drawing.Size(253, 24);
            this.ddlGalvanica.TabIndex = 6;
            // 
            // txtSuperficie
            // 
            this.txtSuperficie.Location = new System.Drawing.Point(141, 231);
            this.txtSuperficie.MaxLength = 10;
            this.txtSuperficie.Name = "txtSuperficie";
            this.txtSuperficie.Size = new System.Drawing.Size(253, 22);
            this.txtSuperficie.TabIndex = 5;
            // 
            // nPezziBarra
            // 
            this.nPezziBarra.Location = new System.Drawing.Point(141, 196);
            this.nPezziBarra.Name = "nPezziBarra";
            this.nPezziBarra.Size = new System.Drawing.Size(253, 22);
            this.nPezziBarra.TabIndex = 4;
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.Location = new System.Drawing.Point(141, 332);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(75, 33);
            this.btnAggiungi.TabIndex = 7;
            this.btnAggiungi.Text = "Aggiungi";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(319, 332);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 33);
            this.btnAnnulla.TabIndex = 8;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // txtFinitura
            // 
            this.txtFinitura.Location = new System.Drawing.Point(141, 117);
            this.txtFinitura.MaxLength = 20;
            this.txtFinitura.Name = "txtFinitura";
            this.txtFinitura.Size = new System.Drawing.Size(253, 22);
            this.txtFinitura.TabIndex = 2;
            // 
            // ddlMateriale
            // 
            this.ddlMateriale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMateriale.FormattingEnabled = true;
            this.ddlMateriale.Location = new System.Drawing.Point(141, 156);
            this.ddlMateriale.Name = "ddlMateriale";
            this.ddlMateriale.Size = new System.Drawing.Size(253, 24);
            this.ddlMateriale.TabIndex = 3;
            // 
            // lblMessaggio
            // 
            this.lblMessaggio.AutoSize = true;
            this.lblMessaggio.ForeColor = System.Drawing.Color.Red;
            this.lblMessaggio.Location = new System.Drawing.Point(29, 43);
            this.lblMessaggio.Name = "lblMessaggio";
            this.lblMessaggio.Size = new System.Drawing.Size(45, 16);
            this.lblMessaggio.TabIndex = 0;
            this.lblMessaggio.Text = "label1";
            // 
            // GalvanicaModelloComponenteFrm
            // 
            this.AcceptButton = this.btnAggiungi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(487, 385);
            this.ControlBox = false;
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.nPezziBarra);
            this.Controls.Add(this.txtFinitura);
            this.Controls.Add(this.txtSuperficie);
            this.Controls.Add(this.ddlGalvanica);
            this.Controls.Add(this.ddlMateriale);
            this.Controls.Add(this.ddlBrand);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMessaggio);
            this.Controls.Add(this.lblModello);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GalvanicaModelloComponenteFrm";
            this.Text = "INFORMAZIONI ARTICOLO";
            this.Load += new System.EventHandler(this.GalvanicaModelloComponenteFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nPezziBarra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblModello;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlBrand;
        private System.Windows.Forms.ComboBox ddlGalvanica;
        private System.Windows.Forms.TextBox txtSuperficie;
        private System.Windows.Forms.NumericUpDown nPezziBarra;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.TextBox txtFinitura;
        private System.Windows.Forms.ComboBox ddlMateriale;
        private System.Windows.Forms.Label lblMessaggio;
    }
}