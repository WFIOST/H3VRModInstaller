using System;
using System.Net;
using System.IO;
using H3VRModInstaller.Filesys;
using H3VRModInstaller.Filesys.Common;

namespace H3VRModInstaller.Net
{
	class Downloader
	{
		private readonly WebClient downloader = new();
		private readonly InstallMods installer = new();
		private readonly ModList mods = new();

		public bool downloadMod(string[] fileinfo)
		{
			if(fileinfo[0] == "" || fileinfo[0] == null) { return false; }

			string fileToDownload = fileinfo[0];
			string locationOfFile = fileinfo[1];

			Console.WriteLine("Downloading Mod \"{0}\" from \"{1}{0}\"\n", fileToDownload, locationOfFile);

			downloader.DownloadFile(locationOfFile + fileToDownload, fileToDownload);

			Console.WriteLine("File Downloaded");

			string dir = Directory.GetCurrentDirectory();
			dir += @"\";

			string fullLocOfFile = dir + fileToDownload;
			Console.WriteLine(fullLocOfFile);

			System.IO.FileInfo fi = new System.IO.FileInfo(fullLocOfFile);


/*			if (fi.Exists)
			{
				Console.WriteLine("found downloaded file!");
				fi.MoveTo(dir + "download.zip");
			}
			else Console.WriteLine("Can't find downloaded file!");*/

			Console.WriteLine("Successfully Downloaded Mod \"{0}\" from \"{1}{0}\"\n", fileToDownload, locationOfFile);

			installer.installMod(fileinfo);

			return true;
		}

		public bool downloadModDirector(string mod, bool downloadAll = false)
		{
			if (!mods.onlineCheck()) { Console.WriteLine("Not connected to internet, or GitHub is down!"); return false; }
			var result = mods.getModInfo(mod);

			for (var i = 0; i < result.Item1.GetLength(0); i++)
			{
				string[] fileinfo = new string[3];
				fileinfo[0] = result.Item1[i, 0];
				fileinfo[1] = result.Item1[i, 1];
				fileinfo[2] = result.Item1[i, 2];
				downloadMod(fileinfo);
			}
			return true;
		}
	}
}
