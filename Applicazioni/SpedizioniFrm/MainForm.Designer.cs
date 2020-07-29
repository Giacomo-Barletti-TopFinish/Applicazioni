namespace SpedizioniFrm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magazzinoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ubicazioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saldiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saldiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.finestreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disponiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orizzontaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUserLoggato = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.stUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.operaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ySLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.magazzinoToolStripMenuItem,
            this.saldiToolStripMenuItem,
            this.operaToolStripMenuItem,
            this.finestreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.finestreToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1157, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // magazzinoToolStripMenuItem
            // 
            this.magazzinoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ubicazioniToolStripMenuItem,
            this.movimentiToolStripMenuItem});
            this.magazzinoToolStripMenuItem.Name = "magazzinoToolStripMenuItem";
            this.magazzinoToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.magazzinoToolStripMenuItem.Text = "Magazzino";
            // 
            // ubicazioniToolStripMenuItem
            // 
            this.ubicazioniToolStripMenuItem.Name = "ubicazioniToolStripMenuItem";
            this.ubicazioniToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.ubicazioniToolStripMenuItem.Text = "Ubicazioni";
            this.ubicazioniToolStripMenuItem.Click += new System.EventHandler(this.ubicazioniToolStripMenuItem_Click);
            // 
            // movimentiToolStripMenuItem
            // 
            this.movimentiToolStripMenuItem.Name = "movimentiToolStripMenuItem";
            this.movimentiToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.movimentiToolStripMenuItem.Text = "Movimenti";
            // 
            // saldiToolStripMenuItem
            // 
            this.saldiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saldiToolStripMenuItem1});
            this.saldiToolStripMenuItem.Name = "saldiToolStripMenuItem";
            this.saldiToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.saldiToolStripMenuItem.Text = "Saldi";
            // 
            // saldiToolStripMenuItem1
            // 
            this.saldiToolStripMenuItem1.Name = "saldiToolStripMenuItem1";
            this.saldiToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.saldiToolStripMenuItem1.Text = "Saldi";
            this.saldiToolStripMenuItem1.Click += new System.EventHandler(this.saldiToolStripMenuItem1_Click);
            // 
            // finestreToolStripMenuItem
            // 
            this.finestreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disponiToolStripMenuItem});
            this.finestreToolStripMenuItem.Name = "finestreToolStripMenuItem";
            this.finestreToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.finestreToolStripMenuItem.Text = "Finestre";
            // 
            // disponiToolStripMenuItem
            // 
            this.disponiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascataToolStripMenuItem,
            this.orizzontaleToolStripMenuItem});
            this.disponiToolStripMenuItem.Name = "disponiToolStripMenuItem";
            this.disponiToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.disponiToolStripMenuItem.Text = "Disponi";
            // 
            // cascataToolStripMenuItem
            // 
            this.cascataToolStripMenuItem.Name = "cascataToolStripMenuItem";
            this.cascataToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.cascataToolStripMenuItem.Text = "Cascata";
            this.cascataToolStripMenuItem.Click += new System.EventHandler(this.cascataToolStripMenuItem_Click_1);
            // 
            // orizzontaleToolStripMenuItem
            // 
            this.orizzontaleToolStripMenuItem.Name = "orizzontaleToolStripMenuItem";
            this.orizzontaleToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.orizzontaleToolStripMenuItem.Text = "Orizzontale";
            this.orizzontaleToolStripMenuItem.Click += new System.EventHandler(this.orizzontaleToolStripMenuItem_Click_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserLoggato,
            this.lblStatusBar,
            this.stUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 762);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1157, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "cdcStatus";
            // 
            // lblUserLoggato
            // 
            this.lblUserLoggato.Name = "lblUserLoggato";
            this.lblUserLoggato.Size = new System.Drawing.Size(0, 17);
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(0, 17);
            // 
            // stUser
            // 
            this.stUser.Name = "stUser";
            this.stUser.Size = new System.Drawing.Size(118, 17);
            this.stUser.Text = "toolStripStatusLabel1";
            // 
            // operaToolStripMenuItem
            // 
            this.operaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ySLToolStripMenuItem});
            this.operaToolStripMenuItem.Name = "operaToolStripMenuItem";
            this.operaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.operaToolStripMenuItem.Text = "Opera";
            // 
            // ySLToolStripMenuItem
            // 
            this.ySLToolStripMenuItem.Name = "ySLToolStripMenuItem";
            this.ySLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ySLToolStripMenuItem.Text = "YSL";
            this.ySLToolStripMenuItem.Click += new System.EventHandler(this.ySLToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 784);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finestreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disponiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orizzontaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magazzinoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ubicazioniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saldiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saldiToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUserLoggato;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel stUser;
        private System.Windows.Forms.ToolStripMenuItem operaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ySLToolStripMenuItem;
    }
}

