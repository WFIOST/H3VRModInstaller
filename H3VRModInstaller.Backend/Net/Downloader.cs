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

        public string downloadMod(string locationOfFile, string fileToDownload)
        {
            Console.WriteLine("Downloading Mod \"{0}\" from \"{1}{0}\"\n", fileToDownload, locationOfFile);

            downloader.DownloadFile(locationOfFile + fileToDownload, fileToDownload);

			string dir = Directory.GetCurrentDirectory();
			dir += @"\";

			string fullLocOfFile = dir + fileToDownload;
			Console.WriteLine(fullLocOfFile);

			System.IO.FileInfo fi = new System.IO.FileInfo(fullLocOfFile);


			if (fi.Exists){
				Console.WriteLine("found downloaded file!");
				fi.MoveTo(dir + "download.zip");}
			else Console.WriteLine("Can't find downloaded file!");

			Console.WriteLine("Successfully Downloaded Mod \"{0}\" from \"{1}{0}\"\n", fileToDownload, locationOfFile);

            return fileToDownload;
        }

		public bool downloadModDirector(MainClass.ListMods mod, bool downloadAll = false)
        {
			if (!mods.onlineCheck()) { Console.WriteLine("Not connected to internet, or GitHub is down!"); return false; }
 /*           if (!Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"))
            {
                Console.WriteLine("BepInEx not detected! Downloading.");
                downloadMod(mods.BepInExInfo[1], mods.BepInExInfo[0]);
                installer.installMod("BepInEx", true);
            }*/
            if (downloadAll)
            {
                for (int i = 0; i < Enum.GetNames(typeof(MainClass.ListMods)).Length; i++)
                {
                    var _mod = (MainClass.ListMods)i;
					for (var x = 1; x < mods.getModInfo(_mod).Item1.Length; x++)
					{
						downloadMod(mods.getModInfo(_mod).Item2[i], mods.getModInfo(_mod).Item1[i]);
//						installer.installMod(mods.getModInfo(_mod).Item1[i]);
					}
				}
            }
            else
            {
				var result = mods.getModInfo(mod);
				for (var i = 0; i < result.Item3.Length - 1; i++)
				{
					if (result.Item2[i] == "") break;
					downloadMod(result.Item2[i], result.Item1[i]);
					installer.installMod(result.Item1[i], result.Item4);
				}
            }
            return true;
        }
    }
}
