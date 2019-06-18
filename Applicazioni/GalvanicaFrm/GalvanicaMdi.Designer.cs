namespace GalvanicaFrm
{
    partial class GalvanicaMdi
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
            this.odlInRepartoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odiernoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finestreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disponiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orizzontaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.odlInRepartoToolStripMenuItem,
            this.finestreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.finestreToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1408, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // odlInRepartoToolStripMenuItem
            // 
            this.odlInRepartoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.odiernoToolStripMenuItem,
            this.storicoToolStripMenuItem});
            this.odlInRepartoToolStripMenuItem.Name = "odlInRepartoToolStripMenuItem";
            this.odlInRepartoToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.odlInRepartoToolStripMenuItem.Text = "Analisi";
            // 
            // odiernoToolStripMenuItem
            // 
            this.odiernoToolStripMenuItem.Name = "odiernoToolStripMenuItem";
            this.odiernoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.odiernoToolStripMenuItem.Text = "Attività odierna";
            this.odiernoToolStripMenuItem.Click += new System.EventHandler(this.odiernoToolStripMenuItem_Click);
            // 
            // storicoToolStripMenuItem
            // 
            this.storicoToolStripMenuItem.Name = "storicoToolStripMenuItem";
            this.storicoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.storicoToolStripMenuItem.Text = "Storico";
            this.storicoToolStripMenuItem.Click += new System.EventHandler(this.storicoToolStripMenuItem_Click);
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
            this.disponiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.disponiToolStripMenuItem.Text = "Disponi";
            // 
            // cascataToolStripMenuItem
            // 
            this.cascataToolStripMenuItem.Name = "cascataToolStripMenuItem";
            this.cascataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cascataToolStripMenuItem.Text = "Cascata";
            this.cascataToolStripMenuItem.Click += new System.EventHandler(this.cascataToolStripMenuItem_Click);
            // 
            // orizzontaleToolStripMenuItem
            // 
            this.orizzontaleToolStripMenuItem.Name = "orizzontaleToolStripMenuItem";
            this.orizzontaleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.orizzontaleToolStripMenuItem.Text = "Orizzontale";
            this.orizzontaleToolStripMenuItem.Click += new System.EventHandler(this.orizzontaleToolStripMenuItem_Click);
            // 
            // GalvanicaMdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 818);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GalvanicaMdi";
            this.Text = "Galvanica";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GalvanicaMdi_FormClosing);
            this.Load += new System.EventHandler(this.GalvanicaMdi_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem odlInRepartoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odiernoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finestreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disponiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orizzontaleToolStripMenuItem;
    }
}