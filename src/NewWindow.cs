using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace H3VRModInstaller.GUI
{
    public partial class NewWindow : Form
    {
        public NewWindow()
        {
            InitializeComponent();
        }


        private void treeToolStripMenuItem_Click(object sender, EventArgs e) => Utilities.GenerateTree();
    }
}