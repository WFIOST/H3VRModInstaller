using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using H3VRModInstaller.Common;
using Microsoft.VisualBasic.ApplicationServices;

namespace H3VRModInstaller
{
    public partial class Settings : Form
    {
        private string _databaseLocation;
        private string _gameDirectory;
        
        public Settings()
        {
            InitializeComponent();
            var config = ModInstallerConfig.Config;

            DatabaseInfoLocationText.Text = config.DatabaseInfoLocation;
            GameDirectoryText.Text = config.GameDirectory;

            _databaseLocation = config.DatabaseInfoLocation;
            _gameDirectory = config.GameDirectory;
        }

        private void DatabaseInfoSelector_Click(object sender, EventArgs e)
        {
            using 
            (
                var selector = new OpenFileDialog()
                {
                    InitialDirectory = Directory.GetCurrentDirectory(),
                    Filter = "ModInstaller Database file (*.MIInfo)|*.MIInfo|All files (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    Title = "Select ModInstaller Database file",
                    Multiselect = false
                }
            )
            {
                selector.ShowDialog();
                DatabaseInfoLocationText.Text = selector.FileName;
                _databaseLocation = selector.FileName;
            }
        }
        
        private void GameDirectorySelector_Click(object sender, EventArgs e)
        {
            using 
            (
                var selector = new OpenFileDialog()
                {
                    InitialDirectory = Directory.GetCurrentDirectory(),
                    Filter = "H3VR executable (h3vr.exe)|*.exe|All files (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    Title = "Select H3VR executable",
                    Multiselect = false
                }
            )
            {
                selector.ShowDialog();
                var trim = selector.SafeFileName.ToCharArray();

                var path = selector.FileName.Trim(trim);
                
                GameDirectoryText.Text = path;
                
                _gameDirectory = path;
            }
        }

        private void SaveConfig_Click(object sender, EventArgs e)
        {
            ModInstallerConfig.Config = new ModInstallerConfig()
            {
                DatabaseInfoLocation = _databaseLocation,
                GameDirectory = _gameDirectory
            };
            MessageBox.Show
            (
                $"Saved config file to {ModInstallerConfig.ConfigPath}", 
                "Saved config!", 
                MessageBoxButtons.OK
            );
            Program.Startup();
            
            Close();
        }


    
    }
}
