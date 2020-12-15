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

				string[] inputargs = input.Split(' ');

				switch (inputargs[0])
				{
					case "dl":
						downloader.downloadModDirector(inputargs[1]);
						break;
					case "launch":

						break;
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
	}
}