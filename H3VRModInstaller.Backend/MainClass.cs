using System;
using System.IO;
using H3VRModInstaller.Net;
using H3VRModInstaller.Filesys;
using H3VRModInstaller.Filesys.Common;
using H3VRModInstaller.Common;


namespace H3VRModInstaller
{
    class MainClass
    {
        private static bool BypassH3VR = true;
        private static readonly ModList mods = new ModList();
        private static readonly Downloader downloader = new Downloader();
        private static readonly InstallMods installer = new InstallMods();
        
        
        public enum ListMods // do NOT assign ints to them, you will fuck up the installer.
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
				Console.WriteLine("Please select the mod you would like to install using 'dl [modnamehere]' ");
				Console.WriteLine("ex: 'dl wurstmod'");
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
					case "dl lsiic":
						Console.WriteLine("Downloading all!");
						downloader.downloadModDirector(ListMods.LSIIC, true);
						break;
					case "dl sideloader":
						Console.WriteLine("Downloading all!");
						downloader.downloadModDirector(ListMods.Sideloader, true);
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
				goto Start;

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