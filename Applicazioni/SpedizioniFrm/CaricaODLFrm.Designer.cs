namespace SpedizioniFrm
{
    partial class CaricaODLFrm
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
            this.txtOdl = new System.Windows.Forms.TextBox();
            this.barcode = new System.Windows.Forms.Label();
            this.ubicazione = new System.Windows.Forms.Label();
            this.txtubicazione = new System.Windows.Forms.TextBox();
            this.btnesegui = new System.Windows.Forms.Button();
            this.lblOdl = new System.Windows.Forms.Label();
            this.lblUbicazione = new System.Windows.Forms.Label();
            this.lblEsito = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtOdl
            // 
            this.txtOdl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOdl.Location = new System.Drawing.Point(44, 58);
            this.txtOdl.Name = "txtOdl";
            this.txtOdl.Size = new System.Drawing.Size(193, 20);
            this.txtOdl.TabIndex = 5;
            this.txtOdl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOdl_KeyDown);
            // 
            // barcode
            // 
            this.barcode.AutoSize = true;
            this.barcode.Location = new System.Drawing.Point(44, 40);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(32, 15);
            this.barcode.TabIndex = 6;
            this.barcode.Text = "ODL";
            // 
            // ubicazione
            // 
            this.ubicazione.AutoSize = true;
            this.ubicazione.Location = new System.Drawing.Point(44, 125);
            this.ubicazione.Name = "ubicazione";
            this.ubicazione.Size = new System.Drawing.Size(69, 15);
            this.ubicazione.TabIndex = 7;
            this.ubicazione.Text = "Ubicazione";
            // 
            // txtubicazione
            // 
            this.txtubicazione.Location = new System.Drawing.Point(44, 143);
            this.txtubicazione.Name = "txtubicazione";
            this.txtubicazione.Size = new System.Drawing.Size(193, 21);
            this.txtubicazione.TabIndex = 8;
            this.txtubicazione.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtubicazione_KeyDown);
            // 
            // btnesegui
            // 
            this.btnesegui.Location = new System.Drawing.Point(47, 256);
            this.btnesegui.Name = "btnesegui";
            this.btnesegui.Size = new System.Drawing.Size(238, 43);
            this.btnesegui.TabIndex = 10;
            this.btnesegui.Text = "Esegui Operazione";
            this.btnesegui.UseVisualStyleBackColor = true;
            this.btnesegui.Click += new System.EventHandler(this.btnesegui_Click);
            // 
            // lblOdl
            // 
            this.lblOdl.AutoSize = true;
            this.lblOdl.Location = new System.Drawing.Point(44, 90);
            this.lblOdl.Name = "lblOdl";
            this.lblOdl.Size = new System.Drawing.Size(32, 15);
            this.lblOdl.TabIndex = 12;
            this.lblOdl.Text = "ODL";
            // 
            // lblUbicazione
            // 
            this.lblUbicazione.AutoSize = true;
            this.lblUbicazione.Location = new System.Drawing.Point(44, 167);
            this.lblUbicazione.Name = "lblUbicazione";
            this.lblUbicazione.Size = new System.Drawing.Size(58, 15);
            this.lblUbicazione.TabIndex = 13;
            this.lblUbicazione.Text = "XHDFGH";
            // 
            // lblEsito
            // 
            this.lblEsito.AutoSize = true;
            this.lblEsito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEsito.Location = new System.Drawing.Point(44, 215);
            this.lblEsito.Name = "lblEsito";
            this.lblEsito.Size = new System.Drawing.Size(70, 16);
            this.lblEsito.TabIndex = 14;
            this.lblEsito.Text = "XHDFGH";
            // 
            // CaricaODLFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 393);
            this.Controls.Add(this.lblEsito);
            this.Controls.Add(this.lblUbicazione);
            this.Controls.Add(this.lblOdl);
            this.Controls.Add(this.btnesegui);
            this.Controls.Add(this.txtubicazione);
            this.Controls.Add(this.ubicazione);
            this.Controls.Add(this.barcode);
            this.Controls.Add(this.txtOdl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CaricaODLFrm";
            this.Text = "Carica ODL in ubicazione";
            this.Load += new System.EventHandler(this.CaricaODLFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtOdl;
        private System.Windows.Forms.Label barcode;
        private System.Windows.Forms.Label ubicazione;
        private System.Windows.Forms.TextBox txtubicazione;
        private System.Windows.Forms.Button btnesegui;
        private System.Windows.Forms.Label lblOdl;
        private System.Windows.Forms.Label lblUbicazione;
        private System.Windows.Forms.Label lblEsito;
    }
}