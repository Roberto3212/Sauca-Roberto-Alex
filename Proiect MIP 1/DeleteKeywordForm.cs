using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_MIP_1
{
    public partial class DeleteKeywordForm : Form
    {
        public DeleteKeywordForm(List<string> keywords)
        {
            InitializeComponent();
        }

        public string SelectedKeyword { get; internal set; }

        private void DeleteKeywordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
