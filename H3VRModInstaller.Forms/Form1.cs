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
using System.Windows.Forms.VisualStyles;
using H3VRModInstaller.Common;
using H3VRModInstaller.JSON;
using H3VRModInstaller.JSON.Common;
using H3VRModInstaller.Net;

namespace H3VRModInstaller.GUI
{
    public partial class mainwindow : Form
    {

        public mainwindow()
        {
            InitializeComponent();
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

            if (ModsEnabled.Checked) if (File.Exists(ModInstallerCommon.Files.MainFiledir + GUICommon.Files.DisabledName)) File.Move(ModInstallerCommon.Files.MainFiledir + GUICommon.Files.DisabledName, ModInstallerCommon.Files.MainFiledir + GUICommon.Files.EnabledName);
            
            
            if (!ModsEnabled.Checked) File.Move(ModInstallerCommon.Files.MainFiledir + GUICommon.Files.EnabledName, ModInstallerCommon.Files.MainFiledir +GUICommon.Files.DisabledName);
            
            if (ModInstallerCommon.enableDebugging)
            {
                MessageBox.Show("Launching H3VR at: \n" + GUICommon.Files.EXEPath);
                MessageBox.Show($"Directories: \n {ModInstallerCommon.Files.MainFiledir} \n {Directory.GetCurrentDirectory()}");
            }

            Process.Start(GUICommon.Files.EXEPath);
            
        }

        private void LoadGUI(object sender, EventArgs e)
        {
            InstallButton.Hide();
            UpdateButton.Hide();
            Delete.Hide();

            ModsEnabled.Checked = true;

            ModFile[] input = ModInstallerCommon.GetAllMods();

            ModFile[] installedMods = JSON.InstalledMods.GetInstalledMods();

            MessageBox.Show($"MODS LENGTH: {input.Length.ToString()}");
            for (int i = 0; i < input.Length; i++)
            {
                MessageBox.Show($"Mods: {installedMods[i].RawName}");
                //try
                //{
                    if (input[i].RawName == installedMods[i].RawName) 
                    {
                        var installedMod = new ListViewItem(input[i].Name, 0);
                        
                        installedMod.SubItems.Add(input[i].Version);
                        
                        installedMod.SubItems.Add(input[i].Author[0]);
                        
                        installedMod.SubItems.Add(input[i].Description);
                        
                        installedMod.SubItems.Add(input[i].ModId);
                        
                        InstalledModsList.Items.Add(installedMod);
                    }
                //}
                //catch (Exception exception)
                //{
                //}

                var mod = new ListViewItem(input[i].Name, 0);
                
                mod.SubItems.Add(input[i].Version);
                
                mod.SubItems.Add(input[i].Author[0]);
                
                mod.SubItems.Add(input[i].Description);
                
                mod.SubItems.Add(input[i].ModId);
                
                DownloadableModsList.Items.Add(mod);
                
            }
            
        }

        private void DownloadableModsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            InstallButton.Show();
            try
            {
                SelectedModText.Text = "Selected Mod: " + DownloadableModsList.SelectedItems[0].Text;

                
                ModInfo.Text = DownloadableModsList.SelectedItems[0].SubItems[3].Text;
            }
            catch (Exception exception)
            {
                Console.WriteLine("winforms is doing it again");
                //throw;
            }
            
            
            
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            var modToDownload = DownloadableModsList.SelectedItems[0].SubItems[4].Text;
            MessageBox.Show($"Mod to download: {modToDownload}");

            
            Downloader.DownloadModDirector(modToDownload);
        }

        private void InstalledModsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButton.Show();
            Delete.Show();
        }
    }
}
