using System;
using System.IO;
using H3VRModInstaller.Backend.Net;
using H3VRModInstaller.Backend.Filesys;
using H3VRModInstaller.Backend.Filesys.Common;

namespace H3VRModInstaller.Backend
{
    class MainClass
    {
        private static bool BypassH3VR = true;
        private static readonly ModList mods = new ModList();
        private static readonly Downloader downloader = new Downloader();
        private static readonly InstallMods installer = new InstallMods();
        
        
        public enum ListMods
        {
			BepInEx,
			ResourceRedirector,
			Deli,
			Monomod,
            WurstMod,
            CursedDLLs,
            TnHTweaker,
			Sideloader,
			LSIIC
        }

        public static void Main(string[] args)
        {

			if (File.Exists("H3VR.exe") || BypassH3VR)
			{
				Console.WriteLine("H3VR.exe detected");
				Console.WriteLine("Welcome to the H3VR Mod installer!");
				Start:
				Console.WriteLine("Please select the mod you would like to install!");
				Console.WriteLine("1: WurstMod");
				Console.WriteLine("2: Cursed DLLs");
				Console.WriteLine("3: TNHTweaker");
				Console.WriteLine("4: All");
				Console.Write("Input the mod you would like to install: ");
				var input = Console.ReadLine();

				switch (input)
				{
					case "dl wurstmod":
						Console.WriteLine("Downloading WurstMod!");
						downloader.downloadModDirector(ListMods.WurstMod);
						break;
					case "dl curseddlls":
						Console.WriteLine("Downloading CursedDLLs!");
						downloader.downloadModDirector(ListMods.CursedDLLs);
						break;
					case "dl tnhtweaker":
						Console.WriteLine("Downloading TnHTweaker!");
						downloader.downloadModDirector(ListMods.TnHTweaker);
						break;
					case "dl all":
						Console.WriteLine("Downloading all!");
						downloader.downloadModDirector(ListMods.WurstMod, true);
						break;
					case "exit":
						return;
					/*
					case "dl basemods":
						Console.WriteLine("Downloading base mods!");
						downloader.downloadModDirector(ListMods.WurstMod);
						downloader.downloadModDirector(ListMods.TnHTweaker);
						break;
					*/
				}
				Console.ReadKey();

			}
			else
			{
				Console.WriteLine("H3VR.exe not detected!");
				Console.ReadKey();
			}
			Console.ReadKey();
		}
	
		public void startInstall(ListMods mod, bool installAll = false)
		{
			Console.WriteLine( mod + " selected");
			if (mods.onlineCheck())
			{
				downloader.downloadModDirector(mod, installAll);
				Console.Write("Press any key to exit the installer");
				Console.ReadKey();
				return;
			}
		}
	}
    /*
        public struct Mods
        {
            public string[] Path { get; set; }
            public string[] Files { get; set; }
        }
    */
}