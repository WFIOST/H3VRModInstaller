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
using System.Runtime.InteropServices;
using H3VRModInstaller.Filesys;

namespace H3VRModInstaller.GUI
{
	public partial class mainwindow : Form
	{

		public string impModID;

		public mainwindow()
		{
			InitializeComponent();
		}

		public void trycatchtext(Label label, string text)
		{
			try { label.Text = text; } catch { }
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


			if (!ModsEnabled.Checked) File.Move(ModInstallerCommon.Files.MainFiledir + GUICommon.Files.EnabledName, ModInstallerCommon.Files.MainFiledir + GUICommon.Files.DisabledName);

			if (ModInstallerCommon.enableDebugging)
			{
				MessageBox.Show("Launching H3VR at: \n" + GUICommon.Files.EXEPath);
				MessageBox.Show($"Directories: \n {ModInstallerCommon.Files.MainFiledir} \n {Directory.GetCurrentDirectory()}");
			}

			Process.Start(GUICommon.Files.EXEPath);

		}

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AllocConsole();

		private void LoadGUI(object sender, EventArgs e)
		{
			AllocConsole();
			InstallButton.Hide();
			UpdateButton.Hide();
			ModVer.Hide();
			Delete.Hide();

			ModsEnabled.Checked = true;

			JsonModList.DlModList();

			ModFile[] input = ModInstallerCommon.GetAllMods();

			ModFile[] installedMods = JSON.InstalledMods.GetInstalledMods();

			ModFile[] list = null;

			int relevantint = 0;

			//MessageBox.Show($"MODS LENGTH: {input.Length.ToString()}");
			for (int i = 0; i < input.Length; i++)
			{

				//this just checks if the mod we're working with is an installedmod, or a dl mod in isinstldmod
				bool isinstldmod = false;
				int x = 0;
				for (x = 0; x < installedMods.Length; x++)
				{
					if (input[i].ModId == installedMods[x].ModId) { isinstldmod = true; break; }
				}

				//sets vars to installedmods or input
				if (isinstldmod) { list = installedMods; relevantint = x; } else { list = input; relevantint = i; }


				var mod = new ListViewItem(list[relevantint].Name, 0); //0
				mod.SubItems.Add(list[relevantint].Version); //1
				mod.SubItems.Add(list[relevantint].Author[0]); //2
				mod.SubItems.Add(list[relevantint].Description); //3
				mod.SubItems.Add(list[relevantint].ModId); //4


				if (!isinstldmod) DownloadableModsList.Items.Add(mod);
				else InstalledModsList.Items.Add(mod);

			}

		}

		private void DownloadableModsList_SelectedIndexChanged(object sender, EventArgs e)
		{
			InstallButton.Show();
			UpdateButton.Hide();
			ModVer.Hide();
			Delete.Hide();

			trycatchtext(SelectedModText, "Selected Mod: " + DownloadableModsList.SelectedItems[0].Text);
			trycatchtext(ModInfo, DownloadableModsList.SelectedItems[0].SubItems[3].Text);
			impModID = DownloadableModsList.SelectedItems[0].SubItems[4].Text;



		}

		private void InstallButton_Click(object sender, EventArgs e)
		{
			if (!Terminator.IsBusy)
			{
				Terminator.RunWorkerAsync();
			}
		}

		private void InstalledModsList_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateButton.Show();
			Delete.Show();
			ModVer.Show();
			try
			{
				ModVer.Text = "Current Ver: " + InstalledModsList.SelectedItems[0].SubItems[1].Text + ", Online Version: " + ModParsing.GetSpecificMod(InstalledModsList.SelectedItems[0].SubItems[4].Text).Version;
			}
			catch { }
		}

		private void Terminator_DoWork(object sender, DoWorkEventArgs e)
		{
			string mod = "";
			try
			{
				mod = impModID;
			}
			catch
			{
				Console.WriteLine("Not a string!");
			}
			try
			{
				Console.WriteLine("Downloading modid " + mod);
				var result = MessageBox.Show($"Are you sure you want to download {mod}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.No) { return; }
				Downloader.DownloadModDirector(mod);
			}
			catch (Exception exception)
			{
				Terminator.CancelAsync();
				MessageBox.Show($"Failed to install mod {DownloadableModsList.SelectedItems[0].SubItems[4].Text} \n \n {exception.Message}!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Terminator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			var modToDownload = DownloadableModsList.SelectedItems[0].SubItems[4].Text;
			//UpdateInstalledList();
			MessageBox.Show($"Sucessfully downloaded mod {modToDownload}", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void Terminator_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			/*
            ProgressBar.Value = e.ProgressPercentage;
            PersentageText.Text = string.Format("{0}%", e.ProgressPercentage);
            ProgressBar.Update();
            */
		}

		public void UpdateInstalledList()
		{

		}

		private void UpdateButton_Click(object sender, EventArgs e)
		{

		}
	}
}
