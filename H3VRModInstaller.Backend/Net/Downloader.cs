using System;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using H3VRModInstaller.Filesys;
using H3VRModInstaller.Net;
using H3VRModInstaller.JSON;
using H3VRModInstaller.Common;

namespace H3VRModInstaller.Net
{
	/// <summary>
	/// This class is for downloading mods
	/// </summary>
	public class Downloader
	{

		public Dictionary<string, ModFile> stringToModfile = new Dictionary<string, ModFile>();

		private static readonly WebClient _Downloader = new();
		private static bool _finished = false;
		public static float[] dlprogress = { 0f, 9999f };

		/// <summary>
		/// Downloads the mod specified
		/// </summary>
		/// <param name="fileinfo">ModFile, specify here which mod to use</param>
		/// <param name="modnum">Checks if mod already installed</param>
		/// <param name="autoredownload">Auto redownload?</param>
		/// <param name="skipdl">Skips the download process, mostly used for debugging</param>
		/// <returns>Boolean, true</returns>
		public static bool DownloadMod(ModFile fileinfo, int modnum, bool autoredownload = false, bool skipdl = false)
		{
			if (skipdl == true) { Installer.InstallMod(fileinfo); return true; }
			ModFile[] installedmods = InstalledMods.GetInstalledMods();
			_finished = false;
			if (string.IsNullOrEmpty(fileinfo.RawName)) { return false; }

			string fileToDownload = fileinfo.RawName;
			string locationOfFile = fileinfo.Path;

			if (!autoredownload)
			{
				for (int i = 0; i < installedmods.Length; i++)
				{
					if (fileinfo.ModId == installedmods[i].ModId)
					{
						if (modnum == 0)
						{
							Uninstaller.DeleteMod(fileinfo.ModId);
						}
						ModInstallerCommon.DebugLog(fileinfo.ModId + " is already installed!");
						return false;
					}
				}
			}
			Uri fileloc = new Uri(locationOfFile + fileToDownload);

			if (ModInstallerCommon.enableDebugging) Console.WriteLine("Downloading {0} from {1}{0}", fileToDownload, locationOfFile);


			Console.WriteLine("");

			_Downloader.DownloadFileCompleted += Dlcomplete;
			_Downloader.DownloadProgressChanged += Dlprogress;
			_Downloader.DownloadFileAsync(fileloc, fileToDownload);
			while (!_finished)
			{
				Thread.Sleep(50);
			}
			_finished = false;

			Console.WriteLine("Successfully Downloaded {0}", fileToDownload, locationOfFile);
			if (ModInstallerCommon.enableDebugging) Console.Write("from {1}{0}", fileToDownload, locationOfFile);

			Installer.InstallMod(fileinfo);

			InstalledMods.AddInstalledMod(fileinfo.ModId);
			return true;
		}
		public static void Dlcomplete(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			_finished = true;
			dlprogress[0] = 0f;
			dlprogress[0] = 9999f;
		}


		/// <summary>
		/// Reports on download progress
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Event Arguments</param>
		public static void Dlprogress(object sender, DownloadProgressChangedEventArgs e)
		{
			if ((float)e.TotalBytesToReceive <= 10)
			{
				float mbs = (float)e.BytesReceived / 1000000f;
				string mbstext = String.Format("{0:00.00}", mbs);
				Console.Write("\r" + mbstext + "MBs downloaded!");
				dlprogress[0] = mbs;

			}
			else
			{
				float percentage = ((float)e.BytesReceived / (float)e.TotalBytesToReceive) * 100;
				string percentagetext = String.Format("{0:00.00}", percentage);
				Console.Write("\r" + percentagetext + "% downloaded!");
				dlprogress[0] = percentage;
				
			}
			dlprogress[1] = e.TotalBytesToReceive;
			NotifyForms.CallEvent();

		}


		public delegate void NotifyUpdate(float[] info);

		public static class NotifyForms
		{
			public static event NotifyUpdate NotifyUpdateProgressBar;

			public static void CallEvent()
			{
				NotifyUpdateProgressBar?.Invoke(dlprogress);
			}
		}



		/// <summary>
		/// Directs the mod downloading
		/// </summary>
		/// <param name="mod">Mod to direct</param>
		/// <param name="skipdl">Skips the download process</param>
		/// <returns>Boolean, true</returns>
		public static bool DownloadModDirector(string mod, bool skipdl = false)
		{
			if (!NetCheck.isOnline(ModInstallerCommon.Pingsite)) { Console.WriteLine("Not connected to internet, or " + ModInstallerCommon.Pingsite + " is down!"); return false; }
			var result = ModParsing.GetModInfoAndDependencies(mod);
			if (result == null) return false;
			for (var i = 0; i < result.Length; i++)
			{
				/*				string[] fileinfo = new string[5];
								fileinfo[0] = result.Item1[i, 0]; //File name
								fileinfo[1] = result.Item1[i, 1]; //File loc
								fileinfo[2] = result.Item1[i, 2]; //args
								fileinfo[3] = i.ToString(); //modnumber
								fileinfo[4] = result.Item1[i, 3]; //File ID*/
				DownloadMod(result[i], i, false, skipdl);
			}
			return true;

		}

	}
}
