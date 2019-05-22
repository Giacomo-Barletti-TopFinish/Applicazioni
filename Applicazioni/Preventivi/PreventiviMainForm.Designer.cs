namespace Preventivi
{
    partial class PreventiviMainForm
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
            this.preventiviMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.balenciagaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finestreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disponiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.preventiviMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // preventiviMenu
            // 
            this.preventiviMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preventiviMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.balenciagaToolStripMenuItem,
            this.finestreToolStripMenuItem});
            this.preventiviMenu.Location = new System.Drawing.Point(0, 0);
            this.preventiviMenu.MdiWindowListItem = this.finestreToolStripMenuItem;
            this.preventiviMenu.Name = "preventiviMenu";
            this.preventiviMenu.Size = new System.Drawing.Size(1558, 25);
            this.preventiviMenu.TabIndex = 0;
            this.preventiviMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.MergeIndex = 100;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // balenciagaToolStripMenuItem
            // 
            this.balenciagaToolStripMenuItem.Name = "balenciagaToolStripMenuItem";
            this.balenciagaToolStripMenuItem.Size = new System.Drawing.Size(82, 21);
            this.balenciagaToolStripMenuItem.Text = "Balenciaga";
            this.balenciagaToolStripMenuItem.Click += new System.EventHandler(this.balenciagaToolStripMenuItem_Click);
            // 
            // finestreToolStripMenuItem
            // 
            this.finestreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disponiToolStripMenuItem});
            this.finestreToolStripMenuItem.Name = "finestreToolStripMenuItem";
            this.finestreToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.finestreToolStripMenuItem.Text = "Finestre";
            // 
            // disponiToolStripMenuItem
            // 
            this.disponiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascataToolStripMenuItem,
            this.organizzaToolStripMenuItem});
            this.disponiToolStripMenuItem.Name = "disponiToolStripMenuItem";
            this.disponiToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.disponiToolStripMenuItem.Text = "Disponi";
            // 
            // cascataToolStripMenuItem
            // 
            this.cascataToolStripMenuItem.Name = "cascataToolStripMenuItem";
            this.cascataToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.cascataToolStripMenuItem.Text = "Cascata";
            this.cascataToolStripMenuItem.Click += new System.EventHandler(this.cascataToolStripMenuItem_Click);
            // 
            // organizzaToolStripMenuItem
            // 
            this.organizzaToolStripMenuItem.Name = "organizzaToolStripMenuItem";
            this.organizzaToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.organizzaToolStripMenuItem.Text = "Organizza orizzontale";
            this.organizzaToolStripMenuItem.Click += new System.EventHandler(this.organizzaToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 763);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1558, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // PreventiviMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1558, 785);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.preventiviMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.preventiviMenu;
            this.Name = "PreventiviMainForm";
            this.Text = "Preventivi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreventiviMainForm_FormClosing);
            this.preventiviMenu.ResumeLayout(false);
            this.preventiviMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip preventiviMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem balenciagaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finestreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disponiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem organizzaToolStripMenuItem;
    }
}

