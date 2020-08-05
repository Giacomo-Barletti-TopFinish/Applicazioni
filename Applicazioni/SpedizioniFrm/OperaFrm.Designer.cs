namespace SpedizioniFrm
{
    partial class OperaFrm
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
            this.btnCerca = new System.Windows.Forms.Button();
            this.btnLeggiFile = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnSimula = new System.Windows.Forms.Button();
            this.dgvExcelCaricato = new System.Windows.Forms.DataGridView();
            this.btnCreaOpera = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelCaricato)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "File";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(87, 26);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(381, 21);
            this.txtFile.TabIndex = 1;
            // 
            // btnCerca
            // 
            this.btnCerca.Location = new System.Drawing.Point(499, 25);
            this.btnCerca.Name = "btnCerca";
            this.btnCerca.Size = new System.Drawing.Size(96, 23);
            this.btnCerca.TabIndex = 2;
            this.btnCerca.Text = "Cerca";
            this.btnCerca.UseVisualStyleBackColor = true;
            this.btnCerca.Click += new System.EventHandler(this.btnCerca_Click);
            // 
            // btnLeggiFile
            // 
            this.btnLeggiFile.Location = new System.Drawing.Point(623, 25);
            this.btnLeggiFile.Name = "btnLeggiFile";
            this.btnLeggiFile.Size = new System.Drawing.Size(96, 23);
            this.btnLeggiFile.TabIndex = 2;
            this.btnLeggiFile.Text = "Leggi file";
            this.btnLeggiFile.UseVisualStyleBackColor = true;
            this.btnLeggiFile.Click += new System.EventHandler(this.leggiFile_click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(22, 69);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 16);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "message";
            // 
            // btnSimula
            // 
            this.btnSimula.Location = new System.Drawing.Point(748, 26);
            this.btnSimula.Name = "btnSimula";
            this.btnSimula.Size = new System.Drawing.Size(96, 23);
            this.btnSimula.TabIndex = 8;
            this.btnSimula.Text = "Simula";
            this.btnSimula.UseVisualStyleBackColor = true;
            this.btnSimula.Click += new System.EventHandler(this.btnSimula_Click);
            // 
            // dgvExcelCaricato
            // 
            this.dgvExcelCaricato.AllowUserToAddRows = false;
            this.dgvExcelCaricato.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExcelCaricato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcelCaricato.Location = new System.Drawing.Point(25, 88);
            this.dgvExcelCaricato.Name = "dgvExcelCaricato";
            this.dgvExcelCaricato.Size = new System.Drawing.Size(1248, 781);
            this.dgvExcelCaricato.TabIndex = 7;
            this.dgvExcelCaricato.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExcelCaricato_CellValidated);
            // 
            // btnCreaOpera
            // 
            this.btnCreaOpera.Location = new System.Drawing.Point(876, 24);
            this.btnCreaOpera.Name = "btnCreaOpera";
            this.btnCreaOpera.Size = new System.Drawing.Size(96, 23);
            this.btnCreaOpera.TabIndex = 9;
            this.btnCreaOpera.Text = "Crea Opera";
            this.btnCreaOpera.UseVisualStyleBackColor = true;
            this.btnCreaOpera.Click += new System.EventHandler(this.btnCreaOpera_Click);
            // 
            // OperaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 894);
            this.Controls.Add(this.btnCreaOpera);
            this.Controls.Add(this.btnSimula);
            this.Controls.Add(this.dgvExcelCaricato);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnLeggiFile);
            this.Controls.Add(this.btnCerca);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OperaFrm";
            this.Text = "OPERA";
            this.Load += new System.EventHandler(this.OperaFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelCaricato)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnCerca;
        private System.Windows.Forms.Button btnLeggiFile;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnSimula;
        private System.Windows.Forms.DataGridView dgvExcelCaricato;
        private System.Windows.Forms.Button btnCreaOpera;
    }
}