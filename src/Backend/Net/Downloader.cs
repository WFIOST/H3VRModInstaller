using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text.RegularExpressions;
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

		public static void dlm(ModFile mf)
		{
			ModFile[] installedmods = InstalledMods.GetInstalledMods();
			ModFile[] mfs = ModParsing.GetModInfoAndDependencies(mf);

			for (int i = 0; i < mfs.Length; i++)
			{
				if(ModParsing.IsInInstalledMods(mfs[i]) && i != 0) { continue; }
				
				_Downloader.DownloadFileCompleted += Dlcomplete;
				_Downloader.DownloadProgressChanged += Dlprogress;


				Console.WriteLine("Downloading {0} from {1}{0}", mfs[i].RawName, mfs[i].Path);
				if (mfs[i].Path.Contains('%'))
				{
					mfs[i].Path = String.Join("", mfs[i].Path.Split('%'));
					_Downloader.DownloadFileAsync(new Uri(mfs[i].Path), mfs[i].RawName);
				}
				else
				{
					_Downloader.DownloadFileAsync(new Uri(mfs[i].Path + mfs[i].RawName), mfs[i].RawName);
				}

				while (!_finished) {Thread.Sleep(100);}
				_finished = false;
				Console.WriteLine("Successfully Downloaded file");
				Installer.InstallMod(mfs[i]);
				InstalledMods.AddInstalledMod(mfs[i].ModId);
			}
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
		public static bool DownloadModDirector(string mod)
		{
			if (!NetCheck.isOnline(ModInstallerCommon.Pingsite))
			{
				Console.WriteLine("Not connected to internet, or " + ModInstallerCommon.Pingsite + " is down!");
				return false;
			}
			
				dlm(ModParsing.GetSpecificMod(mod));

				return true;
		}
	}
}