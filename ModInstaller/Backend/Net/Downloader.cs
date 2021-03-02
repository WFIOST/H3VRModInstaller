using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Threading;
using H3VRModInstaller.Common;
using H3VRModInstaller.Filesys;
using H3VRModInstaller.JSON;

namespace H3VRModInstaller.Net
{
	/// <summary>
	///     This class is for downloading mods
	/// </summary>
	public class Downloader
	{
		/// <summary>
		///     Stuff for the progress bar
		/// </summary>
		/// <param name="info">Float Array</param>
		public delegate void NotifyUpdate(float[] info);

		private static readonly WebClient _Downloader = new();
		private static bool _finished;

		public static string DLprogress
		{
			get => dlprogress;
			set => dlprogress = value;
		}

		private static string dlprogress;

		/// <summary>
		///     Downloads the mod specified
		/// </summary>
		/// <param name="fileinfo">ModFile, specify here which mod to use</param>
		/// <param name="modnum">Checks if mod already installed</param>
		/// <param name="autoredownload">Auto redownload?</param>
		/// <param name="skipdl">Skips the download process, mostly used for debugging</param>
		/// <returns>Boolean, true</returns>
		public static bool DownloadMod(ModFile fileinfo, int modnum, bool autoredownload = false, bool skipdl = false)
		{
			if (skipdl) //lol this can never be reached since 5.0 -- potatoes
			{
				Installer.InstallMod(fileinfo);
				return true;
			}

			var installedmods = InstalledMods.GetInstalledMods();
			_finished = false;
			if (string.IsNullOrEmpty(fileinfo.RawName)) {return false;}

			var fileToDownload = fileinfo.RawName; var locationOfFile = fileinfo.Path;

			if (!autoredownload)
			{
				for (var i = 0; i < installedmods.Length; i++)
				{
					if (fileinfo.ModId == installedmods[i].ModId)
					{
						if (modnum == 0)
						{
							Uninstaller.DeleteMod(fileinfo.ModId);
						}
						else
						{
							ModInstallerCommon.DebugLog(fileinfo.ModId + " is already installed!");
							return false;
						}
					}
				}
			}



			_Downloader.DownloadFileCompleted += Dlcomplete;
			_Downloader.DownloadProgressChanged += Dlprogress;


			if (ModInstallerCommon.enableDebugging) {Console.WriteLine("Downloading {0} from {1}{0}", fileToDownload, locationOfFile);}
			if (locationOfFile.Contains('%'))
			{
				locationOfFile = locationOfFile.Trim('%');
				_Downloader.DownloadFileAsync(new Uri(locationOfFile), fileToDownload);
			}
			else
			{
				_Downloader.DownloadFileAsync(new Uri(locationOfFile + fileToDownload), fileToDownload);
			}

			while (!_finished) {Thread.Sleep(50);}
			_finished = false;

			Console.WriteLine("Successfully Downloaded {0}", fileToDownload, locationOfFile);
			if (ModInstallerCommon.enableDebugging) {Console.Write("from {1}{0}", fileToDownload, locationOfFile);}

			Installer.InstallMod(fileinfo);

			InstalledMods.AddInstalledMod(fileinfo.ModId);
			return true;
		}

		/// <summary>
		///     Sender function for the GUI progress bar
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public static void Dlcomplete(object sender, AsyncCompletedEventArgs e)
		{
			dlprogress = "";
			_finished = true;
		}


		/// <summary>
		///     Reports on download progress
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Event Arguments</param>
		public static void Dlprogress(object sender, DownloadProgressChangedEventArgs e)
		{
			if ((float)e.TotalBytesToReceive <= 10)
			{
				var mbs = e.BytesReceived / 1000000f;
				var mbstext = string.Format("{0:00.00}", mbs);
				Console.Write("\r" + mbstext + "MBs downloaded!");
				dlprogress = mbstext + "MBs";
			}
			else
			{
				var percentage = e.BytesReceived / (float)e.TotalBytesToReceive * 100;
				var percentagetext = string.Format("{0:00.00}", percentage);
				Console.Write("\r" + percentagetext + "% downloaded!");
				dlprogress = percentagetext + "%";
			}

			//            NotifyForms.CallEvent();
		}


		/// <summary>
		///     Directs the mod downloading
		/// </summary>
		/// <param name="mod">Mod to direct</param>
		/// <param name="skipdl">Skips the download process</param>
		/// <returns>Boolean, true</returns>
		public static bool DownloadModDirector(string mod, bool skipdl = false)
		{
			if (!NetCheck.isOnline(ModInstallerCommon.Pingsite))
			{
				Console.WriteLine("Not connected to internet, or " + ModInstallerCommon.Pingsite + " is down!");
				return false;
			}

			var result = ModParsing.GetModInfoAndDependencies(mod);
			if (result == null) {return false;}
			for (var i = 0; i < result.Length; i++)
			{
				DownloadMod(result[i], i, false, skipdl);
			}

			return true;
		}
	}
}