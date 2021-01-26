namespace FlussoFatture
{
    partial class FrmModificaPrezziMAMI
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
            this.btnSalva = new System.Windows.Forms.Button();
            this.dgvMateriali = new System.Windows.Forms.DataGridView();
            this.IDMATERIALIMAMI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTABTIPM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INFATTURA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PREZZO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriali)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalva
            // 
            this.btnSalva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalva.Location = new System.Drawing.Point(261, 426);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(118, 53);
            this.btnSalva.TabIndex = 0;
            this.btnSalva.Text = "Salva modifiche";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // dgvMateriali
            // 
            this.dgvMateriali.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMateriali.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDMATERIALIMAMI,
            this.DESTABTIPM,
            this.INFATTURA,
            this.PREZZO});
            this.dgvMateriali.Location = new System.Drawing.Point(12, 21);
            this.dgvMateriali.Name = "dgvMateriali";
            this.dgvMateriali.Size = new System.Drawing.Size(632, 342);
            this.dgvMateriali.TabIndex = 2;
            // 
            // IDMATERIALIMAMI
            // 
            this.IDMATERIALIMAMI.DataPropertyName = "IDMATERIALIMAMI";
            this.IDMATERIALIMAMI.HeaderText = "IDMATERIALIMAMI";
            this.IDMATERIALIMAMI.Name = "IDMATERIALIMAMI";
            this.IDMATERIALIMAMI.Visible = false;
            // 
            // DESTABTIPM
            // 
            this.DESTABTIPM.DataPropertyName = "DESTABTIPM";
            this.DESTABTIPM.HeaderText = "MATERIALE";
            this.DESTABTIPM.Name = "DESTABTIPM";
            this.DESTABTIPM.ReadOnly = true;
            // 
            // INFATTURA
            // 
            this.INFATTURA.DataPropertyName = "INFATTURA";
            this.INFATTURA.HeaderText = "IN FATTURA";
            this.INFATTURA.Name = "INFATTURA";
            // 
            // PREZZO
            // 
            this.PREZZO.DataPropertyName = "PREZZO";
            this.PREZZO.HeaderText = "PREZZO";
            this.PREZZO.Name = "PREZZO";
            // 
            // FrmModificaPrezziMAMI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 537);
            this.Controls.Add(this.dgvMateriali);
            this.Controls.Add(this.btnSalva);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModificaPrezziMAMI";
            this.Text = "Modifica Prezzi MAMI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmModificaPrezziMAMI_FormClosing);
            this.Load += new System.EventHandler(this.FrmModificaPrezziMAMI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriali)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.DataGridView dgvMateriali;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMATERIALIMAMI;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTABTIPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn INFATTURA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PREZZO;
    }
}