namespace AnalisiOrdiniVendita
{
    partial class RicercaForm
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
            this.dgvOC = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRiferimento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModello = new System.Windows.Forms.TextBox();
            this.btnCerca = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFullNumDoc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOC)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOC
            // 
            this.dgvOC.AllowUserToAddRows = false;
            this.dgvOC.AllowUserToDeleteRows = false;
            this.dgvOC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOC.Location = new System.Drawing.Point(2, 121);
            this.dgvOC.Name = "dgvOC";
            this.dgvOC.ReadOnly = true;
            this.dgvOC.Size = new System.Drawing.Size(1267, 662);
            this.dgvOC.TabIndex = 1;
            this.dgvOC.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvOC_RowStateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Riferimento";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtRiferimento
            // 
            this.txtRiferimento.Location = new System.Drawing.Point(90, 20);
            this.txtRiferimento.Name = "txtRiferimento";
            this.txtRiferimento.Size = new System.Drawing.Size(297, 20);
            this.txtRiferimento.TabIndex = 3;
            this.txtRiferimento.TextChanged += new System.EventHandler(this.txtCommessa_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Articolo";
            // 
            // txtModello
            // 
            this.txtModello.Location = new System.Drawing.Point(90, 75);
            this.txtModello.Name = "txtModello";
            this.txtModello.Size = new System.Drawing.Size(297, 20);
            this.txtModello.TabIndex = 3;
            // 
            // btnCerca
            // 
            this.btnCerca.Location = new System.Drawing.Point(623, 18);
            this.btnCerca.Name = "btnCerca";
            this.btnCerca.Size = new System.Drawing.Size(161, 35);
            this.btnCerca.TabIndex = 4;
            this.btnCerca.Text = "Cerca";
            this.btnCerca.UseVisualStyleBackColor = true;
            this.btnCerca.Click += new System.EventHandler(this.btnCerca_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Commessa";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtFullNumDoc
            // 
            this.txtFullNumDoc.Location = new System.Drawing.Point(90, 46);
            this.txtFullNumDoc.Name = "txtFullNumDoc";
            this.txtFullNumDoc.Size = new System.Drawing.Size(297, 20);
            this.txtFullNumDoc.TabIndex = 3;
            this.txtFullNumDoc.TextChanged += new System.EventHandler(this.txtCommessa_TextChanged);
            // 
            // RicercaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 782);
            this.Controls.Add(this.btnCerca);
            this.Controls.Add(this.txtModello);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFullNumDoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRiferimento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOC);
            this.Name = "RicercaForm";
            this.Text = "Analisi ordini vendita";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RicercaForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRiferimento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModello;
        private System.Windows.Forms.Button btnCerca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFullNumDoc;
    }
}

