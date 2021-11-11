using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pizzaria1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aDDCLIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addcliente add = new addcliente();
            add.ShowDialog();
        }

        private void sAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void oPÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
