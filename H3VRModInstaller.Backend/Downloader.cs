using System;
using System.Net;
using System.IO;

namespace H3VRModInstaller.Backend.Net
{
    class Downloader
    {
        private readonly WebClient downloader = new();
        private readonly InstallMods installer = new();
        private readonly ModList mods = new();

        public bool downloadMod(string locationOfFile, string fileToDownload)
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

            return true;
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
						installer.installMod(mods.getModInfo(_mod).Item1[i]);
					}
				}
            }
            else
            {
				var result = mods.getModInfo(mod);
				for (var i = 1; i < result.Item3.Length - 1; i++)
				{
					if (result.Item2[i] == "") break;
					downloadMod(result.Item2[i], result.Item1[i]);
					installer.installMod(result.Item1[i]);
				}
            }
            return true;
        }
    }

    /*	internal class DownloadMods
        {
            private readonly Downloader downloader = new();
            private readonly InstallMods installer = new();
            private readonly ModList mods = new();


            public bool downloadMod(bool hasBepInEx, MainClass.ListMods mod, bool downloadAll = false)
            {
                if (!hasBepInEx)
                {
                    Console.WriteLine("BepInEx not detected! Downloading.");
                    downloader.downloadMod(mods.wurstModPaths[0], mods.wurstModFiles[0]);
                    installer.installBepInEx();
                }
                if (downloadAll)
                {
                    for (int i = 0; i < Enum.GetNames(typeof(MainClass.ListMods)).Length; i++)
                    {
                        var _mod = (MainClass.ListMods)i;
                        for (var x = 1; x < mods.getModFile(_mod).Item1.Length; x++) downloader.downloadMod(mods.getModFile(_mod).Item2[i], mods.getModFile(_mod).Item1[i]);
                    }
                }
                else
                {
                    for (var i = 1; i < mods.getModFile(mod).Item1.Length; i++) downloader.downloadMod(mods.getModFile(mod).Item2[i], mods.getModFile(mod).Item1[i]);
                }
                return true;
            }

                    public bool downloadCursedDlls(bool hasBepInEx)
                    {
                        if (!hasBepInEx)
                        {
                            Console.WriteLine("BepInEx not detected! Downloading.");
                            downloader.downloadMod(mods.wurstModPaths[0], mods.wurstModFiles[0]);
                            installer.installBepInEx();
                        }

                        for (var i = 1; i < 3; i++) downloader.downloadMod(mods.cursedDllsPaths[i], mods.cursedDllsFiles[i]);
                        return true;
                    }

                    public bool downloadTNHTweaker(bool hasBepInEx)
                    {
                        if (!hasBepInEx)
                        {
                            Console.WriteLine("BepInEx not detected! Downloading.");
                            downloader.downloadMod(mods.wurstModPaths[0], mods.wurstModFiles[0]);
                            installer.installBepInEx();
                        }

                        for (var i = 1; i < 2; i++) downloader.downloadMod(mods.TNHTweakerPaths[i], mods.TNHTweakerFiles[i]);
                        return true;
                    }

                    public bool downloadAll(bool hasBepInEx)
                    {
                        if (!hasBepInEx)
                        {
                            Console.WriteLine("BepInEx not detected! Downloading.");
                            downloader.downloadMod(mods.wurstModPaths[0], mods.wurstModFiles[0]);
                            installer.installBepInEx();
                        }

                        for (var i = 1; i < 3; i++)
                        {
                            downloader.downloadMod(mods.wurstModPaths[i], mods.wurstModFiles[i]);
                            downloader.downloadMod(mods.cursedDllsPaths[i], mods.cursedDllsFiles[i]);
                        }

                        for (var i = 1; i < 2; i++)
                            downloader.downloadMod(mods.TNHTweakerPaths[i], mods.TNHTweakerFiles[i]);

                        return true;
                    }
        }*/
}
