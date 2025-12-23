using Proiect_MIP_1;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Proiect_MIP
{
    public partial class Form1 : Form
    {
        private readonly List<string> keywords = new List<string>();
        private WebBrowser webBrowser;
        public Form1()
        {
            InitializeComponent();

            string dataFile = Path.GetFullPath(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "..", "..", "..", "Data", "keywords.db"));

            string dbPath = System.IO.Path.Combine(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            "..", "..", "..", "Data", "keywords.db"));

            SQLiteHandler.GetInstance().ConnectToDb(dbPath);


            ToolStripTextBox tsTextBox = null;

            var field = this.GetType().GetField("toolStripTextBoxUrl");
            if (field != null)
            {
                tsTextBox = field.GetValue(this) as ToolStripTextBox;
            }

            if (tsTextBox == null)
            {
                var toolStrip = this.Controls.OfType<ToolStrip>().FirstOrDefault();
                if (toolStrip == null)
                {
                    toolStrip = this.Controls
                        .OfType<Control>()
                        .SelectMany(c => c.Controls.OfType<ToolStrip>())
                        .FirstOrDefault();
                }

                if (toolStrip != null)
                {
                    tsTextBox = toolStrip.Items
                        .OfType<ToolStripTextBox>()
                        .FirstOrDefault(i => string.Equals(i.Name, "toolStripTextBoxUrl", StringComparison.OrdinalIgnoreCase))
                        ?? toolStrip.Items.OfType<ToolStripTextBox>().FirstOrDefault();
                }
            }

            if (tsTextBox != null)
            {
                tsTextBox.AutoSize = false;
                tsTextBox.Width = 400;
                tsTextBox.Text = "";

                tsTextBox.KeyDown += toolStripTextBoxUrl_KeyDown;
            }

            webBrowser = new WebBrowser();
            webBrowser.Dock = DockStyle.Fill;
            webBrowser.ScriptErrorsSuppressed = true;

            this.Controls.Add(webBrowser);
            webBrowser.BringToFront();

            var foundToolStrip = this.Controls.OfType<ToolStrip>().FirstOrDefault();
            if (foundToolStrip != null) foundToolStrip.BringToFront();

            var foundMenuStrip = this.Controls.OfType<MenuStrip>().FirstOrDefault();
            if (foundMenuStrip != null) foundMenuStrip.BringToFront();

            btnGo.Click += btnGo_Click;
            btnBack.Click += btnBack_Click;
            btnForward.Click += btnForward_Click;
            btnHome.Click += btnHome_Click;

            webBrowser.Navigated += (s, e) =>
            {
                if (tsTextBox != null)
                {
                    tsTextBox.Text = webBrowser.Url?.ToString() ?? "";
                }
            };

            webBrowser.Navigating += webBrowser_Navigating;

            webBrowser.Navigate("https://www.msn.com/en-xl?ocid=iehp&bv=midlevel");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            NavigateFromTextbox();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoBack) webBrowser.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoForward) webBrowser.GoForward();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            webBrowser.GoHome();
        }

        private void toolStripTextBoxUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                NavigateFromTextbox();
            }
        }

        private void NavigateFromTextbox()
        {
            string url = null;

            var field = this.GetType().GetField("toolStripTextBoxUrl");
            if (field != null)
            {
                var tb = field.GetValue(this) as ToolStripTextBox;
                if (tb != null) url = tb.Text;
            }

            if (url == null)
            {
                var toolStrip = this.Controls.OfType<ToolStrip>().FirstOrDefault();
                if (toolStrip == null)
                {
                    toolStrip = this.Controls
                        .OfType<Control>()
                        .SelectMany(c => c.Controls.OfType<ToolStrip>())
                        .FirstOrDefault();
                }

                var tb = toolStrip?.Items.OfType<ToolStripTextBox>()
                    .FirstOrDefault(i => string.Equals(i.Name, "toolStripTextBoxUrl", StringComparison.OrdinalIgnoreCase))
                    ?? toolStrip?.Items.OfType<ToolStripTextBox>().FirstOrDefault();

                if (tb != null) url = tb.Text;
            }

            url = (url ?? "").Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("URL-ul este gol", "Eroare");
                return;
            }

            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                url = "https://" + url;
            }

            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri uri))
            {
                MessageBox.Show("URL invalid.", "Eroare");
                return;
            }

            webBrowser.Navigate(uri);
        }

        private void addKeywordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("click ok");
            using (var f = new AddKeywordForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    string k = f.KeywordValue?.ToString().Trim() ?? "";

                    if (k == "")
                    {
                        MessageBox.Show("Keyword estr gol.");
                        return;
                    }

                    if (k.Length > 64)
                    {
                        MessageBox.Show("Maxim 64 caractere.");
                        return;
                    }

                    if (keywords.Any(x => string.Equals(x, k, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Keyword duplicat.");
                        return;
                    }

                    keywords.Add(k);
                    MessageBox.Show("Keyword adaugat!");
                }
            }
        }

        private void viewDeleteKeywordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (keywords.Count == 0)
            {
                MessageBox.Show("Nu exista keywords.");
                return;
            }

            using (var f = new DeleteKeywordForm(keywords))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrWhiteSpace(f.SelectedKeyword))
                    {
                        keywords.RemoveAll(x =>
                            string.Equals(x, f.SelectedKeyword, StringComparison.OrdinalIgnoreCase));

                        MessageBox.Show("Keyword sters");
                    }
                }
            }
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (keywords.Count == 0) return;

            string url = e.Url?.ToString() ?? "";
            if (url == "") return;

            foreach (var k in keywords)
            {
                if (string.IsNullOrWhiteSpace(k)) continue;

                if (url.IndexOf(k, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    e.Cancel = true;
                    MessageBox.Show("Navigare blocata. Keyword gasit: " + k, "Blocat");
                    return;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {

        }

        private void keywordsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
