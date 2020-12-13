using System;
using System.IO;
using H3VRModInstaller.Backend.Net;

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
            WurstMod,
            CursedDLLs,
            TnHTweaker
        }

        public static void Main(string[] args)
        {

            if (File.Exists("H3VR.exe") || BypassH3VR)
            {
                Console.WriteLine("H3VR.exe detected");
                Console.WriteLine("Welcome to the H3VR Mod installer!");
                Console.WriteLine("Please select the mod you would like to install!");
                Console.WriteLine("1: WurstMod");
                Console.WriteLine("2: Cursed DLLs");
                Console.WriteLine("3: TNHTweaker");
                Console.WriteLine("4: All");
                Console.Write("Input the mod you would like to install: ");
                var input = Console.ReadLine();
                if ((input == "WurstMod") | (input == "Wurst Mod") | (input == "wurstmod") | (input == "wurst mod") |
                    (input == "1"))
                {
                    Console.WriteLine("WurstMod selected");
                    if (mods.onlineCheck())
                    {
                        downloader.downloadMod(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"), ListMods.WurstMod);
                        installer.installWurstMod();
                        Console.Write("Press any key to exit the installer");
                        Console.ReadKey();
                        return;
                    }
                }

                if ((input == "CursedDLLs") | (input == "Cursed dlls") | (input == "curseddlls") |
                    (input == "Cursed.dlls") | (input == "cursed dll") | (input == "curseddll") | (input == "2"))
                {
                    Console.WriteLine("CursedDLLs selected");
                    if (mods.onlineCheck())
                    {
                        downloader.downloadMod(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"), ListMods.CursedDLLs);
                        installer.installCurseddlls();
                        Console.Write("Press any key to exit the installer");
                        Console.ReadKey();
                        return;
                    }
                }

                if ((input == "TNHTweaker") | (input == "TNH Tweaker") | (input == "tnhtweaker") |
                    (input == "tnh tweaker") | (input == "3"))
                {
                    Console.WriteLine("TNHTweaker selected");
                    if (mods.onlineCheck())
                    {
                        downloader.downloadMod(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"), ListMods.TnHTweaker);
                        installer.installTNHTweaker();
                        Console.Write("Press any key to exit the installer");
                        Console.ReadKey();
                        return;
                    }
                }

                if ((input == "All") | (input == "all") | (input == "4"))
                {
                    Console.WriteLine("All selected");
                    if (mods.onlineCheck())
                        downloader.downloadMod(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"), ListMods.TnHTweaker, true);
                    installer.installAll();
                    Console.Write("Press any key to exit the installer");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("INVALID INPUT");
                    Console.ReadKey();
                }
            }


            else
            {
                Console.WriteLine("H3VR.exe not detected!");
                Console.ReadKey();
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