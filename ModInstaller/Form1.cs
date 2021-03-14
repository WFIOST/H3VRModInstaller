using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows.Forms;
using H3VRModInstaller.Common;
using H3VRModInstaller.Filesys;
using H3VRModInstaller.JSON;
using H3VRModInstaller.Net;
using System.Threading;
using H3VRModInstaller.GUI;
using AutoUpdaterDotNET;
using Newtonsoft.Json;


namespace H3VRModInstaller
{

    public partial class mainwindow : Form //AAA I FUCKING HATE THIS FILE IT GODDAMN HAUNTS MY DREAMS --potatoes
    { //just a note; this file has reached its peak. after v1.1 im going to rewrite the fuck out of this shit, i've had it. i no longer understand what the fuck is going on here. --potatoes
        private static string publicdispcat = "n/a";
        
        public string[] command;

        public string[] impModID = new string[0];

        public WebClient wc = new WebClient();

        public mainwindow()
        {
            InitializeComponent();
        }


        public void StartTerminator(string strngcommand)
        {
            if (!Terminator.IsBusy)
            {
                command = new string[impModID.Length + 1];
                command[0] = strngcommand;
                for (int i = 0; i < impModID.Length; i++)
                {
                    command[i + 1] = impModID[i];
                    Console.WriteLine("Added {0}", impModID[i]);
                }
                Terminator.RunWorkerAsync();
            }

            StatusReport.Text = "Installing";
        }

        private System.Windows.Forms.Timer timer1;

        public void InitTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 0020; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try //this part tries to see if the DL amount reset, and if it did, it means it moved on to another mod so pls update modlist
            {
                float curnum = float.Parse(Downloader.DLprogress, NumberStyles.Any);
                float prevnum = -999;
                try
                {
                    prevnum = float.Parse(StatusReport.Text);
                }
                catch
                {
                    
                }

                if (curnum < prevnum) //this doesnt even work properly
                {
                    UpdateModList();
                }
            }
            catch
            {
                
            }
            
            StatusReport.Text = Downloader.DLprogress ?? "Ready!";

            if (FinishedThread)
            {
                Console.WriteLine("Displaying Image!");
                FinishGetImage();
            }
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

        void Form_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.R)
            {
                AllocConsole();
				Thread t = new Thread(startdebugconsole);
				t.Start();
                ModInstallerCommon.DebugLog("STARTED DEBUG CONSOLE");
			}
		}

		void startdebugconsole()
		{
			debugconsole dbc = new debugconsole();
			dbc.mainform = this;
			Application.Run(dbc);
		}


		[DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        private void LoadGUI(object sender, EventArgs e)
        {
            AutoUpdater.InstalledVersion = new Version("1.2.2");
            AutoUpdater.Start("https://raw.githubusercontent.com/WFIOST/H3VR-Mod-Installer-Database/main/Database/updateinfo.xml");
            //displays screen if out of date, updates automatically. no downside other than it uses fucking xml -- potaotes
            //also note it gets the current ver from the assembly file ver, so make sure to update that!

            KeyDown += Form_KeyDown;

			if (!File.Exists(Utilities.ModCache))
			{
				MessageBox.Show("Thank you for downloading H3VRModInstaller!\nIf there are any issues, or if you want a mod added, please hit us up on the Homebrew discord (@Frityet and @Potatoes)", "Thank you!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("1. Do NOT report bugs in a modded installation to the devs!\n2. Please read the mod's description before reporting an issue with it!", "One note beforehand!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            InitTimer(); //progress timer
            //AllocConsole(); //enables console

            InstallButton.Hide();
            UpdateButton.Hide();
            ModVer.Hide();
            Delete.Hide();
            CheckButton.Hide();
            UpdateModList();
            UpdateCatagories();
            DisEnaButton.Hide();
            OccupiedSlotsList.Hide();
            ImgDisp.Hide();

            textBox1.Text = "Search for mod name here...";
                
            CatagoriesComboBox.SelectedIndex = 0;
			InstalledModsCatagoryBox.SelectedIndex = 0;
        }

        private void DownloadableModsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            InstallButton.Show();
            CheckButton.Show();
            UpdateButton.Hide();
            ModVer.Hide();
            Delete.Hide();
            DisEnaButton.Hide();
            
            

            try
            {
                DispExtraInfo(DownloadableModsList.SelectedItems[0].SubItems[4].Text);
                trycatchtext(SelectedModText, "Selected Mod: " + DownloadableModsList.SelectedItems[0].Text);
                trycatchtext(ModInfo, DownloadableModsList.SelectedItems[0].SubItems[3].Text);
                impModID = new string[DownloadableModsList.SelectedItems.Count];
                for (int i = 0; i < DownloadableModsList.SelectedItems.Count; i++)
                {
                    impModID[i] = DownloadableModsList.SelectedItems[i].SubItems[4].Text;
                }
            }
            catch
            {
                // ignored
            }
        }

        private void DispExtraInfo(string modid)
        {
            Size newSize = new Size(466, 321);
            
            ModFile mf = ModParsing.GetSpecificMod(modid);
            if (mf.SingularModData != null)
            {
                newSize.Width = 301;
                OccupiedSlotsList.Show();
                List<string> txt = new List<string>();
                txt.Add("Affected Things:");
                for (int i = 0; i < mf.SingularModData.OccupiesName.Length; i++)
                {
                    txt.Add("- " + mf.SingularModData.OccupiesName[i]);
                }
                OccupiedSlotsList.Lines = txt.ToArray();
            } else { OccupiedSlotsList.Hide();}
            if (mf.ImgLoc != null)
            {
                newSize.Height = 148;
                ImgDisp.Show();
                Console.WriteLine("Getting image from " + mf.ImgLoc + "!");
                imgloc = mf.ImgLoc;
                ImgDisp.Image = null;
                Thread getimagethread = new Thread(new ThreadStart(GetImage));
                getimagethread.Start();
            } else {ImgDisp.Hide();}
            
            
            ModInfo.Size = newSize;
        }

        private string imgloc;
        private Image img;
        private bool FinishedThread;
        private void GetImage()
        {
            var request = WebRequest.Create(imgloc);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                img = Bitmap.FromStream(stream);
                FinishedThread = true;
            }
        }

        private void FinishGetImage()
        {
            FinishedThread = false;
            ImgDisp.Image = img;
            //not stackoverflow code
            var wfactor = (double)img.Width / 449;
            var hfactor = (double)img.Height / 170;
            var resizeFactor = Math.Max(wfactor, hfactor);
            ImgDisp.Location = new Point((int)(8 + 449 - img.Width / resizeFactor), 170);
            ImgDisp.Size = new Size((int)(img.Width / resizeFactor), (int)(img.Height / resizeFactor));
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            StartTerminator("dl");
        }

        private void InstalledModsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButton.Show();
            Delete.Show();
            CheckButton.Show();
            DisEnaButton.Show();
            try
            {
                DispExtraInfo(InstalledModsList.SelectedItems[0].SubItems[4].Text);
                ModFile modinfo = ModParsing.GetSpecificMod(InstalledModsList.SelectedItems[0].SubItems[4].Text);
                
                //if cached mod is disabled
                if (!String.IsNullOrEmpty(modinfo.DelInfo))
                {

                    string path =
                        Path.Combine(Utilities.GameDirectory,
                            modinfo.DelInfo.Split('?')[0]); //split to get the first delinfo arg
                    if (!File.Exists(path) && !Directory.Exists(path)) //if it is not disabled
                    {
                        DisEnaButton.Text = "Enable";
                        if (modinfo.Version == "0.0.0")
                        {
                            UpdateButton.Hide();
                        }
                    }
                    else
                    {
                        DisEnaButton.Text = "Disable";
                        UpdateButton.Show();
                    }
                }
            } catch{}


            ModVer.Show();
            try
            {
                trycatchtext(SelectedModText, "Selected Mod: " + DownloadableModsList.SelectedItems[0].Text);
                trycatchtext(ModInfo, DownloadableModsList.SelectedItems[0].SubItems[3].Text);
                impModID = new string[DownloadableModsList.SelectedItems.Count];
                for (int i = 0; i < DownloadableModsList.SelectedItems.Count; i++)
                {
                    impModID[i] = DownloadableModsList.SelectedItems[i].SubItems[4].Text;
                }
            }
            catch
            {
                // ignored
            }

            try
            {
                impModID = new string[InstalledModsList.SelectedItems.Count];
                for (int i = 0; i < InstalledModsList.SelectedItems.Count; i++)
                {
                    impModID[i] = InstalledModsList.SelectedItems[i].SubItems[4].Text;
                }
//                impModID = InstalledModsList.SelectedItems[0].SubItems[4].Text;
                SelectedModText.Text = "Selected Mod: " + InstalledModsList.SelectedItems[0].Text;
                ModInfo.Text = InstalledModsList.SelectedItems[0].SubItems[3].Text;
                ModVer.Text = "Current Ver: " + InstalledModsList.SelectedItems[0].SubItems[1].Text +
                              ", Online Version: " + ModParsing
                                  .GetSpecificMod(InstalledModsList.SelectedItems[0].SubItems[4].Text).Version;
            }
            catch
            {
            }
            try
            {
                var mf = ModParsing.GetSpecificMod(InstalledModsList.SelectedItems[0].SubItems[4].Text);
                if (ReturnIncompatableMods(mf, InstalledMods.GetInstalledMods(), false) != null)
                {
                    ModVer.Text = "Mod is incompatable with " +
                                  ReturnIncompatableMods(mf, InstalledMods.GetInstalledMods(), false)[0].Name;
//                    InstalledModsList.SelectedItems[0].BackColor = Color.Red;
                }
            } catch {}
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
                { }
            } //probably the stupidest bodge i've ever done lel --potatoes

            UpdateModList();
            MessageBox.Show("Sucessfully " + command[0] + $"ed mod {downloadedMod}", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StatusReport.Text = "Ready!";
        }

        private void Terminator_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        
        public void UpdateModList(string dispcat = "n/a", string filter = "")
        {
            DownloadableModsList.Items.Clear();
            InstalledModsList.Items.Clear();

            if (dispcat == "n/a") {dispcat = publicdispcat;}
            publicdispcat = dispcat;

            var totalmods = ModParsing.GetAllMods();

            if (dispcat == "n/a") {dispcat = "dependencies";}

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
                {
                    if (totalmods[i].ModId == installedMods[x].ModId)
                    {
                        isinstldmod = true;
                        break;
                    }
                }

                var isdispmod = false;
                for (var y = 0; y < dispmods.Length; y++)
                {
                    if (totalmods[i].ModId == dispmods[y].ModId)
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
                    if (publicdispcat == "n/a") {goto Finish;}
                    list = totalmods;
                    relevantint = i;
                }

                ModFile dbmf = ModParsing.GetSpecificMod(list[relevantint].ModId);
                if (dbmf == null)
                {
                    dbmf = list[relevantint];
                }
                
                var mod = new ListViewItem(dbmf.Name, 0); //0
                mod.SubItems.Add(list[relevantint].Version); //1
                mod.SubItems.Add(string.Join(", ", list[relevantint].Author)); //2
                mod.SubItems.Add(list[relevantint].Description); //3
                mod.SubItems.Add(list[relevantint].ModId); //4

                if (String.IsNullOrEmpty(filter))
                {
                    try
                    {
                        if (!isinstldmod && (isdispmod || dispcat == "all") && !dbmf.HideMod) { DownloadableModsList.Items.Add(mod); }
                        if (isinstldmod && (isdispmod || dispcat == "all")) { InstalledModsList.Items.Add(mod); }
                    } catch{}
                }
                else
                {
                    //search bar functionality
                    filter = filter.ToLower();
                    string modname = list[relevantint].Name.ToLower();
                    string authorString = string.Join("", list[relevantint].Author).ToLower();
                    string singularString = "";
                    if (list[relevantint].SingularModData != null)
                    {
                        singularString = string.Join("", list[relevantint].SingularModData.OccupiesName).ToLower();
                    }
                    if (modname.Contains(filter) || authorString.Contains(filter) || singularString.Contains(filter))
                    {
                        Console.WriteLine("");
                        if (!isinstldmod && isdispmod) DownloadableModsList.Items.Add(mod);
                        if (isinstldmod) InstalledModsList.Items.Add(mod);
                    }
                }
                
                Finish: ;
            }

            for (var i = 0; i < InstalledModsList.Items.Count; i++)
            {
                //if cached installed mod is a older version than the database
                if (new Version(InstalledModsList.Items[i].SubItems[1].Text).CompareTo(
                    new Version(ModParsing.GetSpecificMod(InstalledModsList.Items[i].SubItems[4].Text).Version)) < 0)
                {
                    InstalledModsList.Items[i].BackColor = Color.Yellow;
                }

                var mf = ModParsing.GetSpecificMod(InstalledModsList.Items[i].SubItems[4].Text);
                var mfs = ReturnIncompatableMods(mf, InstalledMods.GetInstalledMods(), false);
                if (mfs != null)
                {
                    if (mfs.Length >= 1)
                    {
                        ModVer.Text = "Mod is incompatable with " + mfs[0];
                        InstalledModsList.Items[i].BackColor = Color.Red;
                    }
                }
                
                string delinfo = ModParsing.GetSpecificMod(InstalledModsList.Items[i].SubItems[4].Text).DelInfo; //if cached mod is disabled
                
                if (!String.IsNullOrEmpty(delinfo))
                {
                    string path =
                        Path.Combine(Utilities.GameDirectory,
                            delinfo.Split('?')[0]); //split to get the first delinfo arg
                    string path2 = Path.Combine(Utilities.DisableCache,
                        new DirectoryInfo(delinfo.Split('?')[0]).Name); //basically loc of the cache area
                    if ((!File.Exists(path) && !Directory.Exists(path)) &&
                        (File.Exists(path2) || Directory.Exists(path2))) //if it is not disabled
                    {
                        InstalledModsList.Items[i].BackColor = Color.Gray;
                        UpdateButton.Hide();
                    }
                    else
                    {
                        UpdateButton.Show();
                    }
                }
            }
        }

        public static ModFile[] ReturnIncompatableMods(ModFile mf, ModFile[] mfs, bool includeDisabledMods)
        {
            List<ModFile> list = new List<ModFile>();

            //Get Direct Incompatable mods
            if(mf.IncompatableMods != null){
                for (int x = 0; x < mf.IncompatableMods.Length; x++) //for every mod this is incompatable with
                {
                    for (int y = 0; y < mfs.Length; y++) //for every mod that is given
                    { 
                        if (CheckIfILmodDisabled(mfs[y]) && !includeDisabledMods) {continue;}
                        if (mfs[y].ModId == mf.ModId) {continue;}
                        if (mf.IncompatableMods[x] == mfs[y].ModId) //if mfs[y] is in inc.mods
                        {
                             list.Add(mfs[y]); //add as incompatable with
                        }
                    } 
                }
            }
            
            //Get Singular Incompatable Mods
            if(mf.SingularModData != null){
                for (int x = 0; x < mf.SingularModData.OccupiesID.Length; x++) //for every mod space this takes up
                {
                    for (int y = 0; y < mfs.Length; y++) //for every mod given
                    {
                        if (CheckIfILmodDisabled(mfs[y]) && !includeDisabledMods) {continue;}
                        if (mfs[y].ModId == mf.ModId) {continue;}
                        if (mfs[y].SingularModData == null) { continue; } //if mfs[y] doesn't occupy anything, ignore
                        for (int z = 0; z < mfs[y].SingularModData.OccupiesID.Length; z++) //if one of mfs[y]'s occupies place is also in mf
                        {
                            if (mf.SingularModData.OccupiesID[x] == mfs[y].SingularModData.OccupiesID[z])
                            {
                                list.Add(mfs[y]); //add as incompatable with
                            }
                        }
                    } 
                }
            }
            
            return list.ToArray();
        }
        
        public static bool CheckIfILmodDisabled(ModFile mf)
        {
            
            if (!String.IsNullOrEmpty(mf.DelInfo))
            {
                //Location of where the mod should be to load
                string InstLoc = Path.Combine(Utilities.GameDirectory, mf.DelInfo.Split('?')[0]);
                //last part of a dir, eg dir1/dir2.jpeg > dir2.jpeg
                string DisLocPostFix = new DirectoryInfo(mf.DelInfo.Split('?')[0]).Name;
                //Location of where the mod should be to be disabled
                string DisLoc = Path.Combine(Utilities.DisableCache, DisLocPostFix);
                //if it does not exist to run, but is disabled
                if (!funcUtils.FileOrDirExists(InstLoc) && funcUtils.FileOrDirExists(DisLoc))
                {
                    return true;
                }
            } else { Console.WriteLine("Delinfo of {0} is empty!", mf.ModId);}
            return false;
        }

        public ModListFormat[] catagories = new ModListFormat[0];
        public void UpdateCatagories()
        {
            catagories = JsonModList.GetModLists();
            ModListFormat mlfall = new ModListFormat();
            mlfall.ModListID = "all";
            mlfall.ModListName = "All Mods";
            mlfall.Modlist = new ModFile[0];
            
            Array.Resize(ref catagories, catagories.Length + 1);
            for (int i = catagories.Length - 2; i >= 0; i--)
            {
                catagories[i + 1] = catagories[i];
            }

            catagories[0] = mlfall;
                
            for (var i = 0; i < catagories.Length; i++)
            {
                CatagoriesComboBox.Items.Add(catagories[i].ModListName);
				InstalledModsCatagoryBox.Items.Add(catagories[i].ModListName);
			}
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            StartTerminator("dl");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string mods = "";
            for (int i = 0; i < impModID.Length; i++)
            {
                mods += ModParsing.GetSpecificMod(impModID[i]).Name + ", ";
            }
            var conf = MessageBox.Show($"Are you sure you want to delete mod(s) {mods}? A total of " + ModParsing.GetDependents(ModParsing.GetSpecificMod(impModID[0])).Length + " downloaded mods rely on this. Dependants aren't going to be deleted, but they probably won't work.", "Deletion Confirmation", MessageBoxButtons.YesNo);

            if (conf == DialogResult.Yes)
            {
                StartTerminator("rm");
            }
            else
            {
                return;
            }
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            var ml = JsonModList.GetModLists();

            for (var i = 0; i < ml.Length; i++)
            {
                for (var x = 0; x < ml[i].Modlist.Length; x++)
                {
                    if (ml[i].Modlist[x].ModId == impModID[0])
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
            }
        }

        private void ModList_Paint(object sender, PaintEventArgs e)
        {
        }

        private void CatagoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = CatagoriesComboBox.SelectedItem.ToString();
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
            //var settings = new Settings();
            //settings.Show();
            //MessageBox.Show("MADE NEW SETTINGS");
        }

        private void InitialiseAppData()
        {
            if (!Directory.Exists(Utilities.DataDir)) {Directory.CreateDirectory(Utilities.DataDir);}
            if (!File.Exists(Utilities.ConfigFile)) {File.Create(Utilities.ConfigFile);}
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateModList("n/a", textBox1.Text );
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search for mod name here...")
            {
                textBox1.Text = "";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            StartTerminator("disable");
        }

		private void OccupiedSlotsList_TextChanged(object sender, EventArgs e)
		{

		}

		private void ImgDisp_Click(object sender, EventArgs e)
        {
            var mf = ModParsing.GetSpecificMod(impModID[0]);

            var link = mf.ImgLoc;
            var psi = new ProcessStartInfo
            {
                FileName = link,
                UseShellExecute = true
            };
            Process.Start(psi);
        }

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (tabControl1.SelectedIndex == 0)
            {
                InstalledModsCatagoryBox_SelectedIndexChanged(null, null);
            }
            if (tabControl1.SelectedIndex == 1)
            { 
                CatagoriesComboBox_SelectedIndexChanged(null, null);
            }

        }

        private void InstalledModsCatagoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = InstalledModsCatagoryBox.SelectedItem.ToString();
            Console.WriteLine(name);
            for (var i = 0; i < catagories.Length; i++)
            {
                if (catagories[i].ModListName == name)
                {
                    UpdateModList(catagories[i].ModListID);
                }
            }
        }
    }
}