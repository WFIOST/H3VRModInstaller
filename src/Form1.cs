using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using H3VRModInstaller.Common;
using H3VRModInstaller.Filesys;
using H3VRModInstaller.JSON;
using H3VRModInstaller.JSON.Common;
using H3VRModInstaller.Net;


namespace H3VRModInstaller
{
    public partial class mainwindow : Form
    {
        public static string publicdispcat = "n/a";
        public string[] command;

        public string impModID;

        private Timer timer1;

        public mainwindow()
        {
            InitializeComponent();
//            Downloader.NotifyForms.NotifyUpdateProgressBar += _nu_updatebar;


            
        }


        public void StartTerminator(string strngcommand)
        {
            if (!Terminator.IsBusy)
            {
                command = strngcommand.Split(' ');
                Terminator.RunWorkerAsync();
            }

            StatusReport.Text = "Installing";
        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += timer1_Tick;
            timer1.Interval = 0020; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StatusReport.Text = Downloader.dlprogress;
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
            var winHttpEnabled = Path.Combine(Utilities.GameDirectoryOrThrow, GuiCommon.Files.EnabledName);
            var winHttpDisabled = Path.Combine(Utilities.GameDirectoryOrThrow, GuiCommon.Files.DisabledName);

            if (ModsEnabled.Checked)
                if (File.Exists(winHttpDisabled))
                    File.Move(winHttpDisabled, winHttpEnabled);
                else
                    File.Move(winHttpEnabled, winHttpDisabled);

#if DEBUG
            MessageBox.Show("Launching H3VR at: \n" + Utilities.ExecutablePath);
#endif

            Process.Start(Utilities.ExecutablePath);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        private void LoadGUI(object sender, EventArgs e)
        {
            if (!File.Exists(Utilities.ModCache))
                MessageBox.Show(
                    "Thank you for downloading H3VRModInstaller!\nBe warned, ModInstaller is still in beta, and absolutely has issues.\nIf there are any issues, or if you want a mod added, please hit us up on the Homebrew discord (@Frityet and @Potatoes)",
                    "Thank you!", MessageBoxButtons.OK, MessageBoxIcon.None);
            InitTimer(); //progress timer
            AllocConsole(); //enables console
            JsonCommon.OverrideModInstallerVariables(); //overrides vars if possible

            var onlineversion = new Version(JsonModList.GetDeserializedModListFormatOnline(JsonCommon.DatabaseInfo)
                .Modlist[0].Version);
            if (ModInstallerCommon.ModInstallerVersion.CompareTo(onlineversion) < 0)
            {
                MessageBox.Show(
                    "H3VRModInstaller is out of date! (" + ModInstallerCommon.ModInstallerVersion + " vs " +
                    onlineversion + ")", "Wrong version detected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                var psi = new ProcessStartInfo
                {
                    FileName = JsonModList.GetDeserializedModListFormatOnline(JsonCommon.DatabaseInfo).Modlist[0]
                        .Website,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }

            InstallButton.Hide();
            UpdateButton.Hide();
            ModVer.Hide();
            Delete.Hide();
            CheckButton.Hide();

            ModsEnabled.Checked = true;
            UpdateModList();
            UpdateCatagories();

            CatagoriesComboBox.SelectedIndex = 0;
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
            catch
            {
                // ignored
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
            catch
            {
                // ignored
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
                Console.WriteLine(exception);
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
                try
                {
                    downloadedMod = InstalledModsList.SelectedItems[0].SubItems[4].Text;
                }
                catch
                {
                }
            } //probably the stupidest bodge i've ever done lel --potatoes

            UpdateModList();
//            MessageBox.Show("Sucessfully " + command[0] + $"ed mod {downloadedMod}", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StatusReport.Text = "Idle";
        }

        private void Terminator_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        public void UpdateModList(string dispcat = "n/a")
        {
            DownloadableModsList.Items.Clear();
            InstalledModsList.Items.Clear();

            if (dispcat == "n/a") dispcat = publicdispcat;
            publicdispcat = dispcat;

            var totalmods = JsonCommon.GetAllMods();

            if (dispcat == "n/a") dispcat = "dependencies";

            Console.WriteLine(dispcat);

            var dispmods = JsonModList.GetDeserializedModListFormatOnline(dispcat).Modlist;

            var installedMods = InstalledMods.GetInstalledMods(); //fuck you

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
                for (var y = 0; y < dispmods.Length; y++)
                    if (totalmods[i].ModId == dispmods[y].ModId)
                    {
                        isdispmod = true;
                        break;
                    }

                //sets vars to installedmods or input
                if (isinstldmod)
                {
                    list = installedMods;
                    relevantint = x;
                }
                else
                {
                    if (publicdispcat == "n/a") goto Finish;
                    list = totalmods;
                    relevantint = i;
                }


                var mod = new ListViewItem(list[relevantint].Name, 0); //0
                mod.SubItems.Add(list[relevantint].Version); //1
                mod.SubItems.Add(string.Join(", ", list[relevantint].Author)); //2
                mod.SubItems.Add(list[relevantint].Description); //3
                mod.SubItems.Add(list[relevantint].ModId); //4


                if (!isinstldmod && isdispmod) DownloadableModsList.Items.Add(mod);
                if (isinstldmod) InstalledModsList.Items.Add(mod);
                Finish: ;
            }

            for (var i = 0; i < InstalledModsList.Items.Count; i++)
                //if cached installed mod is a older version than the database
                if (new Version(InstalledModsList.Items[i].SubItems[1].Text).CompareTo(
                    new Version(ModParsing.GetSpecificMod(InstalledModsList.Items[i].SubItems[4].Text).Version)) < 0)
                    InstalledModsList.Items[i].BackColor = Color.Yellow;
        }

        public void UpdateCatagories()
        {
            var catagories = JsonModList.GetModLists();

            for (var i = 0; i < catagories.Length; i++)
                //				var mod = new ListViewItem(catagories[i].modlistname, 0); //0
//				mod.SubItems.Add(catagories[i].modlistid); //1
                CatagoriesComboBox.Items.Add(catagories[i].ModListName);
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
            var ml = JsonModList.GetModLists();

            for (var i = 0; i < ml.Length; i++)
            for (var x = 0; x < ml[i].Modlist.Length; x++)
                if (ml[i].Modlist[x].ModId == impModID)
                {
                    var link = ml[i].Modlist[x].Website;
                    var psi = new ProcessStartInfo
                    {
                        FileName = link,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
        }

        private void ModList_Paint(object sender, PaintEventArgs e)
        {
        }

        private void CatagoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = CatagoriesComboBox.SelectedItem.ToString();
            var catagories = JsonModList.GetModLists();
            for (var i = 0; i < catagories.Length; i++)
                if (catagories[i].ModListName == name)
                {
                    try
                    {
                        UpdateModList(catagories[i].ModListID);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }

                    break;
                }
        }

        private void StatusReport_Click(object sender, EventArgs e)
        {
            var settings = new Settings();
            settings.Show();
            MessageBox.Show("MADE NEW SETTINGS");
        }

        private void InitialiseAppData()
        {
            if (!Directory.Exists(ModInstallerCommon.Files.DataDir)) Directory.CreateDirectory(ModInstallerCommon.Files.DataDir);
            if (!File.Exists(ModInstallerCommon.Files.ConfigFile)) File.Create(ModInstallerCommon.Files.ConfigFile);
            
        }

        private void WriteDefaultConfig()
        {
            
        }
    }
}