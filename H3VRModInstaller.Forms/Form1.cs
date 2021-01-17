using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using H3VRModInstaller.Common;
using H3VRModInstaller.Filesys;
using H3VRModInstaller.JSON;
using H3VRModInstaller.JSON.Common;
using H3VRModInstaller.Net;

namespace H3VRModInstaller.GUI
{
    public partial class mainwindow : Form
    {
        public string[] command;

        public string impModID;

        public mainwindow()
        {
            InitializeComponent();
            Downloader.NotifyForms.NotifyUpdateProgressBar += _nu_updatebar;
        }


        public void StartTerminator(string strngcommand)
        {
            if (!Terminator.IsBusy)
            {
                command = strngcommand.Split(' ');
                Terminator.RunWorkerAsync();
            }
			StatusReport.Text = "Working...";
        }

        public void _nu_updatebar(float[] info)
        {
//			updatebar(info);
        }

        public void updatebar(float[] info)
        {
//			ProgressBar.Value = (int)info[0];
        }

        public void trycatchtext(Label label, string text)
        {
            try
            {
                label.Text = text;
            }
            catch
            {
            }
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
                if (File.Exists(ModInstallerCommon.Files.MainFiledir + GuiCommon.Files.DisabledName))
                    File.Move(ModInstallerCommon.Files.MainFiledir + GuiCommon.Files.DisabledName,
                        ModInstallerCommon.Files.MainFiledir + GuiCommon.Files.EnabledName);


            if (!ModsEnabled.Checked)
                File.Move(ModInstallerCommon.Files.MainFiledir + GuiCommon.Files.EnabledName,
                    ModInstallerCommon.Files.MainFiledir + GuiCommon.Files.DisabledName);

            if (ModInstallerCommon.enableDebugging)
                MessageBox.Show("Launching H3VR at: \n" + GuiCommon.Files.ExecutablePath);
            //MessageBox.Show($"Directories: \n {ModInstallerCommon.Files.MainFiledir} \n {Directory.GetCurrentDirectory()}");

            Process.Start(GuiCommon.Files.ExecutablePath);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        private void LoadGUI(object sender, EventArgs e)
        {
			AllocConsole();
			InstallButton.Hide();
			UpdateButton.Hide();
			ModVer.Hide();
			Delete.Hide();
			CheckButton.Hide();
			InstalledModsList.Hide();
			DownloadableModsList.Hide();

			ModsEnabled.Checked = true;
            UpdateModList();
			UpdateCatagories();
        }

        private void DownloadableModsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            InstallButton.Show();
            CheckButton.Show();
            UpdateButton.Hide();
            ModVer.Hide();
            Delete.Hide();


            try
            {
                trycatchtext(SelectedModText, "Selected Mod: " + DownloadableModsList.SelectedItems[0].Text);
                trycatchtext(ModInfo, DownloadableModsList.SelectedItems[0].SubItems[3].Text);
                impModID = DownloadableModsList.SelectedItems[0].SubItems[4].Text;
            }
            catch (Exception exception)
            {
                //sike lmao
            }
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            StartTerminator("dl " + impModID);
        }

        private void InstalledModsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButton.Show();
            Delete.Show();
            CheckButton.Show();


            ModVer.Show();
            try
            {
                trycatchtext(SelectedModText, "Selected Mod: " + DownloadableModsList.SelectedItems[0].Text);
                trycatchtext(ModInfo, DownloadableModsList.SelectedItems[0].SubItems[3].Text);
                impModID = DownloadableModsList.SelectedItems[0].SubItems[4].Text;
            }
            catch (Exception exception)
            {
                //sike lmao
            }

            try
            {
                impModID = InstalledModsList.SelectedItems[0].SubItems[4].Text;
                SelectedModText.Text = "Selected Mod: " + InstalledModsList.SelectedItems[0].Text;
                ModInfo.Text = InstalledModsList.SelectedItems[0].SubItems[3].Text;
                ModVer.Text = "Current Ver: " + InstalledModsList.SelectedItems[0].SubItems[1].Text +
                              ", Online Version: " + ModParsing
                                  .GetSpecificMod(InstalledModsList.SelectedItems[0].SubItems[4].Text).Version;
            }
            catch
            {
            }
        }

        private void Terminator_DoWork(object sender, DoWorkEventArgs e)
        {
            var mod = impModID;
            try
            {
                MainClass.doCommand(command);
            }
            catch (Exception exception)
            {
                Terminator.CancelAsync();
                MessageBox.Show(
                    "Failed to " + command[0] +
                    " on mod {DownloadableModsList.SelectedItems[0].SubItems[4].Text} \n \n {exception.Message}!",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Terminator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var downloadedMod = "";
            try //try getting selected downloadablemodslist
            {
                downloadedMod = DownloadableModsList.SelectedItems[0].SubItems[4].Text;
            }
            catch //if it fails to, get the selected installedmodslist
            {
                downloadedMod = InstalledModsList.SelectedItems[0].SubItems[4].Text;
            } //probably the stupidest bodge i've ever done lel --potatoes

            UpdateModList();
            MessageBox.Show("Sucessfully " + command[0] + "ed mod {downloadedMod}", "Sucess!", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
			StatusReport.Text = "Idle";
		}

        private void Terminator_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        public void UpdateModList(string dispcat = "customitems")
        {
            DownloadableModsList.Items.Clear();
            InstalledModsList.Items.Clear();

            var totalmods = JsonCommon.GetAllMods();

			var dispmods = JsonModList.GetDeserializedModListFormatOnline(dispcat).Modlist;

            var installedMods = JSON.InstalledMods.GetInstalledMods();

            ModFile[] list = null;

            var relevantint = 0;

            for (var i = 0; i < totalmods.Length; i++)
            {
                //this just checks if the mod we're working with is an installedmod, or a dl mod in isinstldmod
                var isinstldmod = false;
                var x = 0;
                for (x = 0; x < installedMods.Length; x++)
                    if (totalmods[i].ModId == installedMods[x].ModId)
                    {
                        isinstldmod = true;
                        break;
                    }

				var isdispmod = false;
				for (int y = 0; y < dispmods.Length; y++)
				{
					if(totalmods[i].ModId == dispmods[y].ModId)
					{
						isdispmod = true;
						break;
					}
				}
				
                //sets vars to installedmods or input
                if (isinstldmod)
                {
                    list = installedMods;
                    relevantint = x;
                }
                else
                {
                    list = totalmods;
                    relevantint = i;
                }


                var mod = new ListViewItem(list[relevantint].Name, 0); //0
                mod.SubItems.Add(list[relevantint].Version); //1
                mod.SubItems.Add(list[relevantint].Author[0]); //2
                mod.SubItems.Add(list[relevantint].Description); //3
                mod.SubItems.Add(list[relevantint].ModId); //4


				if (!isinstldmod && isdispmod) DownloadableModsList.Items.Add(mod);
				if (isinstldmod) InstalledModsList.Items.Add(mod);
            }
        }

		public void UpdateCatagories()
		{
			var catagories = JsonModList.GetModLists();

			for(int i = 0; i < catagories.Length; i++)
			{
				
				var mod = new ListViewItem(catagories[i].modlistname, 0); //0
//				mod.SubItems.Add(catagories[i].modlistid); //1
				CatagoriesComboBox.Items.Add(mod);
			}
		}

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            StartTerminator("dl " + impModID);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            StartTerminator("rm " + impModID);
        }

		private void CheckButton_Click(object sender, EventArgs e)
		{
			StartTerminator("check " + impModID);
		}

		private void ModList_Paint(object sender, PaintEventArgs e)
		{
			
		}



		private void InstalledMods_Click(object sender, EventArgs e)
		{
			InstalledModsList.Show();
			DownloadableModsList.Hide();
		}

		private void DownloadableModsButton_Click(object sender, EventArgs e)
		{
			InstalledModsList.Hide();
			DownloadableModsList.Show();
		}

		private void CatagoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			try { UpdateModList(CatagoriesList.SelectedItems[0].SubItems[1].Text); } catch { }
		}
	}
}