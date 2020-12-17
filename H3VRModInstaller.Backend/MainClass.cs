using System;
using System.Diagnostics;
using System.IO;
using H3VRModInstaller.Net;
//using H3VRModInstaller.Json;

namespace H3VRModInstaller
{
    class MainClass
    {
	    //private static Serialisation Json = new Serialisation();
        private static bool BypassH3VR = false;
        private static readonly Downloader downloader = new Downloader();
        public static void Main(string[] args)
        {        
	        
	        
	        if (File.Exists("H3VR.exe") || BypassH3VR)
			{
				Console.WriteLine("H3VR.exe detected");
				Console.WriteLine("Welcome to the H3VR Mod installer!");

				Start:
				Console.WriteLine("Please select the mod you would like to install using 'dl [modnamehere]' ");
				Console.WriteLine("ex: 'dl wurstmod'");
				Console.WriteLine("For a full list of mods, type 'list all', 'list dependencies', 'list scripts', or 'list items'");
				var input = Console.ReadLine();

				string[] inputargs = input.Split(' ');

				Array.Resize<string>(ref inputargs, 10);

				switch (inputargs[0])
				{
					case "dl":
						downloader.DownloadModDirector(inputargs[1]);
						break;
					case "launch":
						Process.Start("h3vr.exe");
						break;
					case "list":
						switch (inputargs[1])
						{
							case "dependencies":
								listAllDependencyMods();
								break;
							case "scripts":
								listAllCustomScripts();
								break;
							case "items":
								listAllCustomItems();
								break;
							case "all":
								listAllDependencyMods();
								Console.WriteLine("");
								listAllCustomScripts();
								Console.WriteLine("");
								listAllCustomItems();
								break;
						}
						break;
					case "rm":
						
					case "exit":
						return;
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

		public static void listAllDependencyMods()
		{
			Console.WriteLine("List of all dependency mods (Does not add any content by itself, allows other mods to add content)");
			Console.WriteLine("bepinex");
			Console.WriteLine("resourceredirector");
			Console.WriteLine("deli");
			Console.WriteLine("monomod");
			Console.WriteLine("wurstmod");
			Console.WriteLine("tnhtweaker");
			Console.WriteLine("sideloader");
			Console.WriteLine("lsiic");
			Console.WriteLine("h3vrutils");
			Console.WriteLine("configurationmanager");
		}

		public static void listAllCustomScripts()
		{
			Console.WriteLine("List of all custom scripts");
			Console.WriteLine("curseddlls");
			Console.WriteLine("meatyceiver");
		}

		public static void listAllCustomItems()
		{
			Console.WriteLine("List of all custom items (NOTE: downloads are real slow, just sit tight.)");
			Console.WriteLine("pccg");
			Console.WriteLine("modular");
			Console.WriteLine("meatssidecharger");
			Console.WriteLine("meatsrigs");
			Console.WriteLine("meatsmags");
			Console.WriteLine("meatsmodulsr");
			Console.WriteLine("meatsmodulpp");
			Console.WriteLine("meatsmodulak");
			Console.WriteLine("meatsmodularparts");
			Console.WriteLine("meatsmpx");
			Console.WriteLine("meatsmodulm4");
			Console.WriteLine("ebr");
		}
	}
}