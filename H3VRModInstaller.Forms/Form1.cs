using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using H3VRModInstaller.Common;

namespace H3VRModInstaller.GUI
{
    public partial class mainwindow : Form
    {

        public mainwindow()
        {
            InitializeComponent();

            ModsEnabled.Checked = true;
        }

        private void ModsEnabled_CheckedChanged(object sender, EventArgs e)
        {
        }
        
        
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void InfoPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void DownloadableModsLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void launch_Click(object sender, EventArgs e)
        {

            if (ModsEnabled.Checked)
                if (File.Exists(ModInstallerCommon.Files.MainFiledir + GUICommon.Files.DisabledName))
                        File.Move(ModInstallerCommon.Files.MainFiledir + GUICommon.Files.DisabledName, ModInstallerCommon.Files.MainFiledir + GUICommon.Files.EnabledName);
                else
                {
                    goto FuckYou;
                }
            
            if (!ModsEnabled.Checked)
                File.Move(ModInstallerCommon.Files.MainFiledir + GUICommon.Files.EnabledName, ModInstallerCommon.Files.MainFiledir +GUICommon.Files.DisabledName);

            FuckYou:
            if (ModInstallerCommon.enableDebugging)
            {
                MessageBox.Show("Launching H3VR at: \n" + GUICommon.Files.EXEPath);
                MessageBox.Show($"Directories: \n {ModInstallerCommon.Files.MainFiledir} \n {Directory.GetCurrentDirectory()}");
            }

            Process.Start(GUICommon.Files.EXEPath);
            
        }
    }
}
