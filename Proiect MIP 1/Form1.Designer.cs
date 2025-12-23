namespace Proiect_MIP
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnBack;
        private System.Windows.Forms.ToolStripMenuItem btnForward;
        private System.Windows.Forms.ToolStripMenuItem btnHome;
        private System.Windows.Forms.ToolStripMenuItem btnGo;

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnBack = new System.Windows.Forms.ToolStripMenuItem();
            this.btnForward = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHome = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.keywordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addKeywordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDeleteKeywordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxUrl1 = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();

            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBack,
            this.btnForward,
            this.btnHome,
            this.btnGo,
            this.toolStripTextBoxUrl1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(697, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";

            this.btnBack.Image = global::Proiect_MIP_1.Properties.Resources.Back_jpg;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(74, 27);
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);

            this.btnForward.Image = global::Proiect_MIP_1.Properties.Resources.Forward_jpg;
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(97, 27);
            this.btnForward.Text = "Forward";

            this.btnHome.Image = global::Proiect_MIP_1.Properties.Resources.Home_jpg;
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(84, 27);
            this.btnHome.Text = "Home";

            this.btnGo.Image = global::Proiect_MIP_1.Properties.Resources.Search_jpg;
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(62, 27);
            this.btnGo.Text = "Go";

            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keywordsToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(697, 28);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";

            this.keywordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addKeywordToolStripMenuItem,
            this.viewDeleteKeywordsToolStripMenuItem});
            this.keywordsToolStripMenuItem.Name = "keywordsToolStripMenuItem";
            this.keywordsToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.keywordsToolStripMenuItem.Text = "Keywords";
            this.keywordsToolStripMenuItem.Click += new System.EventHandler(this.keywordsToolStripMenuItem_Click);
 
            this.addKeywordToolStripMenuItem.Name = "addKeywordToolStripMenuItem";
            this.addKeywordToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.addKeywordToolStripMenuItem.Text = "Add Keyword";
            this.addKeywordToolStripMenuItem.Click += new System.EventHandler(this.addKeywordToolStripMenuItem_Click);

            this.viewDeleteKeywordsToolStripMenuItem.Name = "viewDeleteKeywordsToolStripMenuItem";
            this.viewDeleteKeywordsToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.viewDeleteKeywordsToolStripMenuItem.Text = "View/Delete Keywords";
            this.viewDeleteKeywordsToolStripMenuItem.Click += new System.EventHandler(this.viewDeleteKeywordsToolStripMenuItem_Click);
 
            this.toolStripTextBoxUrl1.AutoSize = false;
            this.toolStripTextBoxUrl1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxUrl1.Name = "toolStripTextBoxUrl1";
            this.toolStripTextBoxUrl1.Size = new System.Drawing.Size(400, 27);
            this.toolStripTextBoxUrl1.Click += new System.EventHandler(this.toolStripTextBox1_Click);

            this.ClientSize = new System.Drawing.Size(697, 372);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem keywordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addKeywordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDeleteKeywordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxUrl1;
    }
}