using System;
using System.IO;
using H3VRModInstaller.Net;
using H3VRModInstaller.Json;


namespace H3VRModInstaller
{
    class MainClass
    {
        private static bool BypassH3VR = true;
        private static readonly Downloader downloader = new Downloader();


        /*       public enum ListMods // do NOT assign ints to them, you will fuck up the installer.
               {
			       BepInEx,
			       ResourceRedirector,
			       Deli,
			       Monomod,
       
                   WurstMod,
                   TnHTweaker,
			       Sideloader,
			       LSIIC,
			       H3VRUtilities,
       
			       CursedDLLs,
			       pccg,
			       meatyceiver,
			       meatssidecharger,
			       meatsrigs,
			       meatsmags,
			       meatsmodulsr,
			       meatsmodulpp,
			       meatsmodulak,
			       modular,
			       meatsmodularparts,
			       ebr
       
               }*/

        public static void Main(string[] args)
        {
	        Serialisation.Deserialise("");	        
	        
	        
	        if (File.Exists("H3VR.exe") || BypassH3VR)
			{
				Console.WriteLine("H3VR.exe detected");
				Console.WriteLine("Welcome to the H3VR Mod installer!");
				Start:
				Console.WriteLine("Please select the mod you would like to install using 'dl [modnamehere]' ");
				Console.WriteLine("ex: 'dl wurstmod'");
				var input = Console.ReadLine();

				string[] inputargs = input.Split(' ');

				switch (inputargs[0])
				{
					case "dl":
						downloader.downloadModDirector(inputargs[1]);
					break;
				}

/*				switch (input)
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
						Console.WriteLine("Downloading LSIIC!");
						downloader.downloadModDirector(ListMods.LSIIC);
						break;
					case "dl sideloader":
						Console.WriteLine("Downloading Sideloader!");
						downloader.downloadModDirector(ListMods.Sideloader);
						break;
					case "dl h3vrutils":
						Console.WriteLine("Downloading H3VR Utilities!");
						downloader.downloadModDirector(ListMods.H3VRUtilities);
						break;
					case "dl meatyceiver":
						Console.WriteLine("Downloading Meatyceiver!");
						downloader.downloadModDirector(ListMods.meatyceiver);
						break;
					case "dl pccg":
						Console.WriteLine("Downloading Potatoes' Compiled Custom Guns!");
						downloader.downloadModDirector(ListMods.pccg);
						break;
					case "dl meatssidecharger":
						Console.WriteLine("Downloading Meat's  Side ChARger!");
						downloader.downloadModDirector(ListMods.meatssidecharger);
						break;
					case "dl meatsrigs":
						Console.WriteLine("Downloading Meat's Rigs!");
						downloader.downloadModDirector(ListMods.meatsrigs);
						break;
					case "dl meatsmags":
						Console.WriteLine("Downloading Meat's Mags!");
						downloader.downloadModDirector(ListMods.meatsmags);
						break;
					case "dl meatsmodulsr":
						Console.WriteLine("Downloading Meat's ModulSR!");
						downloader.downloadModDirector(ListMods.meatsmodulsr);
						break;
					case "dl meatsmodulpp":
						Console.WriteLine("Downloading Meat's ModulPP!");
						downloader.downloadModDirector(ListMods.meatsmodulpp);
						break;
					case "dl meatsmodulak":
						Console.WriteLine("Downloading Meat's ModulAK!");
						downloader.downloadModDirector(ListMods.meatsmodulak);
						break;
					case "dl meatsmodularparts":
						Console.WriteLine("Downloading Meat's ModulAR Parts!");
						downloader.downloadModDirector(ListMods.meatsmodularparts);
						break;
					case "dl modular":
						Console.WriteLine("Downloading ModulAR!");
						downloader.downloadModDirector(ListMods.modular);
						break;
					case "dl meats":
						Console.WriteLine("Downloading all of Meat's mods!");
						downloader.downloadModDirector(ListMods.meatssidecharger);
						downloader.downloadModDirector(ListMods.meatsrigs);
						downloader.downloadModDirector(ListMods.meatsmags);
						downloader.downloadModDirector(ListMods.meatsmodulsr);
						downloader.downloadModDirector(ListMods.meatsmodulpp);
						downloader.downloadModDirector(ListMods.meatsmodulak);
						downloader.downloadModDirector(ListMods.meatsmodularparts);
						downloader.downloadModDirector(ListMods.modular);
						break;
					case "dl ebr":
						Console.WriteLine("Downloading MK14 EBR!");
						downloader.downloadModDirector(ListMods.ebr);
						break;
					case "dl all":
						Console.WriteLine("Downloading all!");
						downloader.downloadModDirector(ListMods.WurstMod, true);
						break;

					case "exit":
						return;
						
					
					case "dl basemods":
						Console.WriteLine("Downloading base mods!");
						downloader.downloadModDirector(ListMods.WurstMod);
						downloader.downloadModDirector(ListMods.TnHTweaker);
						break;
					
				}*/
				goto Start;

			}
			else
			{
				Console.WriteLine("H3VR.exe not detected!");
				Console.ReadKey();
			}
			Console.ReadKey();
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