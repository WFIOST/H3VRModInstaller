using System;
using System.Threading;
using System.Net;
using H3VRModInstaller.Filesys;
using H3VRModInstaller.Net;
using H3VRModInstaller.Filesys.Common;
using H3VRModInstaller.JSON;

namespace H3VRModInstaller
{
	public class Downloader
	{

		private static readonly WebClient downloader = new();
		private static bool finished = false;

		public static bool DownloadMod(string[] fileinfo, bool autoredownload = false, bool skipdl = false)
		{
			if(skipdl == true) { Installer.installMod(fileinfo); return true; }
			string[] installedmods = InstalledMods.GetInstalledMods();
			finished = false;
			if (fileinfo[0] == "" || fileinfo[0] == null) { return false; }

			string fileToDownload = fileinfo[0];
			string locationOfFile = fileinfo[1];

			bool redownload = false;
			if (!autoredownload)
			{
				for (int i = 0; i < installedmods.Length; i++)
				{
					if (fileinfo[4] == installedmods[i])
					{
						if (fileinfo[3] == "0")
						{
						repeat:
							Console.WriteLine("Mod already installed Are you sure you want to reinstall? (y/n)");
							var input = Console.ReadLine();
							if (input == "y")
							{
								redownload = true;
								break;
							}
							else if (input == "n")
							{
								return false;
							}
							else goto repeat;
						}
						if (MainClass.enableDebugging) Console.WriteLine(fileinfo[4] + " is already installed!");
						return false;
					}
				}
			}
			else redownload = true;
			Uri fileloc = new Uri(locationOfFile + fileToDownload);

			if (MainClass.enableDebugging) Console.WriteLine("Downloading {0} from {1}{0}", fileToDownload, locationOfFile);


			Console.WriteLine("");

			downloader.DownloadFileCompleted += dlcomplete;
			downloader.DownloadProgressChanged += dlprogress;
			downloader.DownloadFileAsync(fileloc, fileToDownload);
			while (!finished)
			{
				Thread.Sleep(50);
			}
			finished = false;

			Console.WriteLine("Successfully Downloaded {0}", fileToDownload, locationOfFile);
			if (MainClass.enableDebugging) Console.Write("from {1}{0}", fileToDownload, locationOfFile);

				Installer.installMod(fileinfo);

			if(!redownload) InstalledMods.AddInstalledMods(fileinfo[4]);
			return true;
		}

		public static void dlcomplete(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			finished = true;
		}

		public static void dlprogress(object sender, DownloadProgressChangedEventArgs e)
		{
			if ((float)e.TotalBytesToReceive <= 10)
			{
				float mbs = (float)e.BytesReceived / 1000000f;
				string mbstext = String.Format("{0:00.00}", mbs);
				Console.Write("\r" + mbstext + "MBs downloaded!");
			}
			else
			{
				float percentage = ((float)e.BytesReceived / (float)e.TotalBytesToReceive) * 100;
				string percentagetext = String.Format("{0:00.00}", percentage);
				Console.Write("\r" + percentagetext + "% downloaded!");
			}
		}


		public static bool DownloadModDirector(string mod, bool skipdl = false)
		{
			if (!NetCheck.isOnline(MainClass.pingsite)) { Console.WriteLine("Not connected to internet, or " + MainClass.pingsite + " is down!"); return false; }
			var result = ModList.getModInfo(mod);
			if (result == null) return false;
			for (var i = 0; i < result.Item1.GetLength(0); i++)
			{
				string[] fileinfo = new string[5];
				fileinfo[0] = result.Item1[i, 0]; //File name
				fileinfo[1] = result.Item1[i, 1]; //File loc
				fileinfo[2] = result.Item1[i, 2]; //args
				fileinfo[3] = i.ToString(); //modnumber
				fileinfo[4] = result.Item1[i, 3]; //File ID
				DownloadMod(fileinfo, false, skipdl);
			}
			return true;
		}
		
	}
}
