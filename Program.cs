using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace H3VRModInstaller
{
    class Program
    {
        private static ModList mods = new ModList();
        private static DownloadMods downloader = new DownloadMods();
        private static InstallMods installer = new InstallMods();
        static void Main(string[] args)
        {
                if (File.Exists("H3VR.exe"))
                {
                    Console.WriteLine("H3VR.exe detected");
                    Console.WriteLine("Welcome to the H3VR Mod installer!");
                    Console.WriteLine("Please select the mod you would like to install!");
                    Console.WriteLine("1: WurstMod");
                    Console.WriteLine("2: Cursed DLLs");
                    Console.WriteLine("3: TNHTweaker");
                    Console.WriteLine("4: All");
                    Console.Write("Input the mod you would like to install: ");
                    string input = Console.ReadLine();
                        if (input == "WurstMod" | input == "Wurst Mod" | input == "wurstmod" | input == "wurst mod" | input == "1")
                        {
                            
                        
                            Console.WriteLine("WurstMod selected");
                            if (mods.onlineCheck())
                            {
                                downloader.downloadWurstMod(Directory.Exists("BepInEx"));
                                installer.installWurstMod();
                                
                            }
                            
                        }
                        if (input == "CursedDLLs" | input == "Cursed dlls" | input == "curseddlls" | input == "Cursed.dlls" | input == "cursed dll" | input == "curseddll" | input == "2")
                        {
                            Console.WriteLine("CursedDLLs selected");
                            if (mods.onlineCheck())
                            {
                                downloader.downloadCursedDlls(Directory.Exists("BepInEx"));
                                installer.installCurseddlls();
                            }
                        }
                        if (input == "TNHTweaker" | input == "TNH Tweaker" | input == "tnhtweaker" | input == "tnh tweaker" | input == "3")
                        {
                            Console.WriteLine("TNHTweaker selected");
                            if (mods.onlineCheck())
                            {
                                downloader.downloadTNHTweaker(Directory.Exists("BepInEx"));
                                installer.installTNHTweaker();
                            }

                        }
                        if (input == "All" | input == "all" | input == "4")
                        {
                            Console.WriteLine("All selected");
                            if(mods.onlineCheck())
                                downloader.downloadAll(Directory.Exists("BepInEx"));
                        }
                        else
                        {
                            Console.WriteLine("INVALID INPUT");
                            return;
                        }


                    }

                    
                    else
                    {
                        Console.WriteLine("H3VR.exe not detected!");
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
    class ModList
    {
        public string[] wurstModPaths = {"https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/", "https://github.com/Deli-Counter/Deli/releases/download/v0.2.5/", "https://github.com/Nolenz/WurstMod/releases/download/v2.0.2.0/"};
        public string[] wurstModFiles = {"BepInEx_x64_5.4.4.0.zip", "Deli-v0.2.5.zip", "WurstMod.deli"};
        public string[] cursedDllsPaths = {"https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/", "https://github.com/BepInEx/BepInEx.MonoMod.Loader/releases/download/v1.0.0.0/", "https://github.com/drummerdude2003/CursedDlls.BepinEx/releases/download/v1.3/"};
        public string[] cursedDllsFiles = {"BepInEx_x64_5.4.4.0.zip", "BepInEx.MonoMod.Loader_1.0.0.0.zip", "CursedDlls.BepInEx_v1.3.zip"};
        public string[] TNHTweakerPaths = {"https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/", "https://github.com/devyndamonster/TakeAndHoldTweaker/releases/download/v1.3.0/"};
        public string[] TNHTweakerFiles = {"BepInEx_x64_5.4.4.0.zip", "TakeAndHoldTweaker.dll"};
        public bool onlineCheck()
        {
            CheckOnline checkOnline = new CheckOnline();

            if (checkOnline.isOnline("www.github.com"))
            {
                Console.WriteLine("GitHub is Online!");
                return true;
            }

            else
            {
                Console.WriteLine("Github is either down, or no internet is detected!");
                return false;
            }
        }
    }

    class CheckOnline
    {

        public bool isOnline(string URL)
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send(URL, 1000);


            if(reply.Status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }



        }



    }

    class Downloader
    {
        private WebClient downloader = new WebClient();

        public bool downloadMod(string locationOfFile, string fileToDownload)
        {

            Console.WriteLine("Downloading Mod \"{0}\" from \"{1}{0}\"\n", fileToDownload, locationOfFile);
            

            downloader.DownloadFile(locationOfFile + fileToDownload, fileToDownload);

            Console.WriteLine("Successfully Downloaded Mod \"{0}\" from \"{1}{0}\"\n", fileToDownload, locationOfFile);

            return true;
        }
    }

    class DownloadMods
    {
        private Downloader downloader = new Downloader();
        private ModList mods = new ModList();
        private InstallMods installer = new InstallMods();

        public bool downloadWurstMod(bool hasBepInEx)
        {
            if(!hasBepInEx)
                Console.WriteLine("BepInEx not detected! Downloading.");
                downloader.downloadMod(mods.wurstModPaths[0], mods.wurstModFiles[0]);
                installer.installBepInEx();
                
            /*
            var wurstModDeps = new List<Mods>
            {
                new Mods {Path = mods.wurstModPaths, Files = mods.wurstModFiles}
            };
            */

            for (int i = 1; i < 3; i++)
            {
                downloader.downloadMod(mods.wurstModPaths[i], mods.wurstModFiles[i]);
            }
            return true;
        }

        public bool downloadCursedDlls(bool hasBepInEx)
        { 
            if(!hasBepInEx)
                Console.WriteLine("BepInEx not detected! Downloading.");
                downloader.downloadMod(mods.wurstModPaths[0], mods.wurstModFiles[0]);
                installer.installBepInEx();
            for (int i = 1; i < 3; i++)
            {
                downloader.downloadMod(mods.cursedDllsPaths[i], mods.cursedDllsFiles[i]);
            }
            return true;
        }
        public bool downloadTNHTweaker(bool hasBepInEx)
        { 
            if(!hasBepInEx)
                Console.WriteLine("BepInEx not detected! Downloading.");
                downloader.downloadMod(mods.wurstModPaths[0], mods.wurstModFiles[0]);
                installer.installBepInEx();
            for (int i = 1; i < 2; i++)
            {
                downloader.downloadMod(mods.TNHTweakerPaths[i], mods.TNHTweakerFiles[i]);
            }
            return true;
        }
        
        public bool downloadAll(bool hasBepInEx)
        {
            if(!hasBepInEx)
                Console.WriteLine("BepInEx not detected! Downloading.");
                downloader.downloadMod(mods.wurstModPaths[0], mods.wurstModFiles[0]);
                installer.installBepInEx();
            for (int i = 1; i < 3; i++)
            {
                downloader.downloadMod(mods.wurstModPaths[i], mods.wurstModFiles[i]);
                downloader.downloadMod(mods.cursedDllsPaths[i], mods.cursedDllsFiles[i]);
            }
            for (int i = 1; i < 2; i++)
            {
                downloader.downloadMod(mods.TNHTweakerPaths[i], mods.TNHTweakerFiles[i]);
            }
            return true;
        }


    }
    class Installer
    {
        public bool unzip(string fileToUnzip, string unzipLocation, bool deleteArchiveAfterUnzip)
        {
            //why do I even have this?
            Console.WriteLine("Unzipping " + fileToUnzip);
            ZipFile.ExtractToDirectory(fileToUnzip, unzipLocation);
            if (deleteArchiveAfterUnzip)
                Console.WriteLine("Cleaning up");
                File.Delete(fileToUnzip);
            return true;
        }
        public bool moveFileToPlugins(string fileToMove, string locationToMoveTo = "BepInEx/Plugins")
        {
            //this is even more redundant!
            File.Move(fileToMove, locationToMoveTo);
            return true;
        }
        public bool moveDirToBepInEx(string dirToMove, string locationToMoveTo)
        {
            //more redundancy
            Directory.Move(dirToMove, locationToMoveTo);
            return true;
        }
        public bool installDeliMod(string deliMod, string modsDir = "Mods/")
        {
            if(!Directory.Exists(modsDir))
                Directory.CreateDirectory(modsDir);
            File.Move(deliMod, modsDir);
            return true;
        }


    }

    class InstallMods
    {
        private static Installer installer = new Installer();

        public bool installBepInEx()
        {
            installer.unzip("BepInEx_x64_5.4.4.0.zip", "", false);

            Console.WriteLine("Finishing BepInEx installation");
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("H3VR.exe");
                bool bepinexInstalled = Directory.Exists("BepInEx/Plugins");
                while (bepinexInstalled)
                {
                    foreach (var proccess in Process.GetProcessesByName("H3VR"))
                    {
                        proccess.Kill();
                    }
                }
            }
            Console.WriteLine("Installed BepInEx!");
            return true;
        }
        public bool installWurstMod()
        {
            installer.unzip("Deli-v0.2.5.zip", "", true);
            Console.WriteLine("Installed Deli!");

            installer.installDeliMod("WurstMod.deli");
            Console.WriteLine("Installed WurstMod!");
            return true;
        }

        public bool installCurseddlls()
        {

            installer.unzip("BepInEx.MonoMod.Loader_1.0.0.0.zip", "", true);
            Console.WriteLine("Installed Monomod!");
            installer.unzip("CursedDlls.BepInEx_v1.3.zip", "", true);
            Console.WriteLine("Installed Cursed.Dlls!");
            return true;
        }

        public bool installTNHTweaker()
        {
            installer.moveFileToPlugins("TNHTweaker.dll");
            Console.WriteLine("Installed TNH Tweaker!");

            return true;
        }


    }
}
