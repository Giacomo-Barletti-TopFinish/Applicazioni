namespace AnalisiOrdiniVendita
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOC = new System.Windows.Forms.TabPage();
            this.tabDettaglio = new System.Windows.Forms.TabPage();
            this.dgvOC = new System.Windows.Forms.DataGridView();
            this.pannello = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.tabOC.SuspendLayout();
            this.tabDettaglio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOC)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabOC);
            this.tabControl1.Controls.Add(this.tabDettaglio);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1271, 782);
            this.tabControl1.TabIndex = 0;
            // 
            // tabOC
            // 
            this.tabOC.Controls.Add(this.dgvOC);
            this.tabOC.Location = new System.Drawing.Point(4, 22);
            this.tabOC.Name = "tabOC";
            this.tabOC.Padding = new System.Windows.Forms.Padding(3);
            this.tabOC.Size = new System.Drawing.Size(1263, 756);
            this.tabOC.TabIndex = 0;
            this.tabOC.Text = "Ordini cliente";
            this.tabOC.UseVisualStyleBackColor = true;
            // 
            // tabDettaglio
            // 
            this.tabDettaglio.Controls.Add(this.pannello);
            this.tabDettaglio.Location = new System.Drawing.Point(4, 22);
            this.tabDettaglio.Name = "tabDettaglio";
            this.tabDettaglio.Padding = new System.Windows.Forms.Padding(3);
            this.tabDettaglio.Size = new System.Drawing.Size(1263, 756);
            this.tabDettaglio.TabIndex = 1;
            this.tabDettaglio.Text = "Produzione";
            this.tabDettaglio.UseVisualStyleBackColor = true;
            // 
            // dgvOC
            // 
            this.dgvOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOC.Location = new System.Drawing.Point(3, 3);
            this.dgvOC.Name = "dgvOC";
            this.dgvOC.Size = new System.Drawing.Size(1257, 750);
            this.dgvOC.TabIndex = 0;
            this.dgvOC.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvOC_RowStateChanged);
            // 
            // pannello
            // 
            this.pannello.ColumnCount = 1;
            this.pannello.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pannello.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pannello.Location = new System.Drawing.Point(3, 3);
            this.pannello.Name = "pannello";
            this.pannello.RowCount = 1;
            this.pannello.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pannello.Size = new System.Drawing.Size(1257, 750);
            this.pannello.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 782);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Analisi ordini vendita";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabOC.ResumeLayout(false);
            this.tabDettaglio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOC;
        private System.Windows.Forms.TabPage tabDettaglio;
        private System.Windows.Forms.DataGridView dgvOC;
        private System.Windows.Forms.TableLayoutPanel pannello;
    }
}

