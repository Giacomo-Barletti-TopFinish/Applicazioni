namespace Preventivatore
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUserLoggato = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.stUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anagraficaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distintaBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creaDistintaBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.costiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stimaCostiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserLoggato,
            this.lblStatusBar,
            this.stUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 532);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1067, 22);
            this.statusStrip1.TabIndex = 3;
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
            // mainMenu
            // 
            this.mainMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.anagraficaToolStripMenuItem,
            this.distintaBaseToolStripMenuItem,
            this.costiToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1067, 25);
            this.mainMenu.TabIndex = 4;
            this.mainMenu.Text = "cdcMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Enabled = false;
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.loginToolStripMenuItem.Text = "Login ...";
            this.loginToolStripMenuItem.Visible = false;
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // anagraficaToolStripMenuItem
            // 
            this.anagraficaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materialiToolStripMenuItem});
            this.anagraficaToolStripMenuItem.Name = "anagraficaToolStripMenuItem";
            this.anagraficaToolStripMenuItem.Size = new System.Drawing.Size(82, 21);
            this.anagraficaToolStripMenuItem.Text = "Anagrafica";
            // 
            // materialiToolStripMenuItem
            // 
            this.materialiToolStripMenuItem.Name = "materialiToolStripMenuItem";
            this.materialiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.materialiToolStripMenuItem.Text = "Materiali";
            this.materialiToolStripMenuItem.Click += new System.EventHandler(this.materialiToolStripMenuItem_Click);
            // 
            // distintaBaseToolStripMenuItem
            // 
            this.distintaBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creaDistintaBaseToolStripMenuItem});
            this.distintaBaseToolStripMenuItem.Name = "distintaBaseToolStripMenuItem";
            this.distintaBaseToolStripMenuItem.Size = new System.Drawing.Size(94, 21);
            this.distintaBaseToolStripMenuItem.Text = "Distinta Base";
            // 
            // creaDistintaBaseToolStripMenuItem
            // 
            this.creaDistintaBaseToolStripMenuItem.Name = "creaDistintaBaseToolStripMenuItem";
            this.creaDistintaBaseToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.creaDistintaBaseToolStripMenuItem.Text = "Crea distinta base";
            // 
            // costiToolStripMenuItem
            // 
            this.costiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stimaCostiToolStripMenuItem});
            this.costiToolStripMenuItem.Name = "costiToolStripMenuItem";
            this.costiToolStripMenuItem.Size = new System.Drawing.Size(49, 21);
            this.costiToolStripMenuItem.Text = "Costi";
            // 
            // stimaCostiToolStripMenuItem
            // 
            this.stimaCostiToolStripMenuItem.Name = "stimaCostiToolStripMenuItem";
            this.stimaCostiToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.stimaCostiToolStripMenuItem.Text = "Stima costi";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Preventivatore";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUserLoggato;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel stUser;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anagraficaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distintaBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem costiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creaDistintaBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stimaCostiToolStripMenuItem;
    }
}

