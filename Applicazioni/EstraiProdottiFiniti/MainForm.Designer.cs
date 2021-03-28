namespace EstraiProdottiFiniti
{
    partial class EstraiProdottoFinito
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
            this.tvDiBa = new System.Windows.Forms.TreeView();
            this.txtArticolo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCercaDiBa = new System.Windows.Forms.Button();
            this.dgvNodi = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODELLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodi)).BeginInit();
            this.SuspendLayout();
            // 
            // tvDiBa
            // 
            this.tvDiBa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvDiBa.Location = new System.Drawing.Point(12, 69);
            this.tvDiBa.Name = "tvDiBa";
            this.tvDiBa.Size = new System.Drawing.Size(458, 727);
            this.tvDiBa.TabIndex = 0;
            this.tvDiBa.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDiBa_NodeMouseClick);
            // 
            // txtArticolo
            // 
            this.txtArticolo.Location = new System.Drawing.Point(88, 29);
            this.txtArticolo.Name = "txtArticolo";
            this.txtArticolo.Size = new System.Drawing.Size(205, 20);
            this.txtArticolo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Articolo";
            // 
            // btnCercaDiBa
            // 
            this.btnCercaDiBa.Location = new System.Drawing.Point(331, 27);
            this.btnCercaDiBa.Name = "btnCercaDiBa";
            this.btnCercaDiBa.Size = new System.Drawing.Size(130, 23);
            this.btnCercaDiBa.TabIndex = 3;
            this.btnCercaDiBa.Text = "Cerca DiBa";
            this.btnCercaDiBa.UseVisualStyleBackColor = true;
            this.btnCercaDiBa.Click += new System.EventHandler(this.btnCercaDiBa_Click);
            // 
            // dgvNodi
            // 
            this.dgvNodi.AllowUserToAddRows = false;
            this.dgvNodi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNodi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNodi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MODELLO,
            this.QUANTITA});
            this.dgvNodi.Location = new System.Drawing.Point(486, 69);
            this.dgvNodi.Name = "dgvNodi";
            this.dgvNodi.Size = new System.Drawing.Size(946, 413);
            this.dgvNodi.TabIndex = 4;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // MODELLO
            // 
            this.MODELLO.DataPropertyName = "Modello";
            this.MODELLO.Frozen = true;
            this.MODELLO.HeaderText = "MODELLO";
            this.MODELLO.Name = "MODELLO";
            // 
            // QUANTITA
            // 
            this.QUANTITA.DataPropertyName = "Quantita";
            this.QUANTITA.HeaderText = "QUANTITA";
            this.QUANTITA.Name = "QUANTITA";
            this.QUANTITA.ReadOnly = true;
            // 
            // EstraiProdottoFinito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 808);
            this.Controls.Add(this.dgvNodi);
            this.Controls.Add(this.btnCercaDiBa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArticolo);
            this.Controls.Add(this.tvDiBa);
            this.Name = "EstraiProdottoFinito";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvDiBa;
        private System.Windows.Forms.TextBox txtArticolo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCercaDiBa;
        private System.Windows.Forms.DataGridView dgvNodi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODELLO;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITA;
    }
}

