<<<<<<< HEAD
<<<<<<< HEAD
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.NetworkInformation;

namespace H3VRModInstaller
{
    internal class Program
    {
        private static readonly ModList Mods = new();
        private static readonly DownloadMods Downloader = new();
        private static readonly InstallMods Installer = new();

        private static void Main(string[] args)
        {
            if (File.Exists("H3VR.exe"))
            {
                Console.WriteLine("H3VR.exe detected");
                Console.WriteLine("Welcome to the H3VR Mod installer!");
                Console.WriteLine("Please select the mod you would like to install!");
                Console.WriteLine("1: WurstMod");
                Console.WriteLine("2: Cursed DLLs");
                Console.WriteLine("3: TNHTweaker");
                //Console.WriteLine("4: All (warning, pretty buggy)");
                Console.Write("Input the mod you would like to install: ");
                var input = Console.ReadLine();
                if ((input == "WurstMod") | (input == "Wurst Mod") | (input == "wurstmod") | (input == "wurst mod") |
                    (input == "1"))
                {
                    Console.WriteLine("WurstMod selected");
                    if (ModList.OnlineCheck())
                    {
                        Downloader.DownloadWurstMod(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"));
                        InstallMods.InstallWurstMod();
                        Console.Write("Press any key to exit the installer");
                        Console.ReadKey();
                        return;
                    }
                }

                if ((input == "CursedDLLs") | (input == "Cursed dlls") | (input == "curseddlls") |
                    (input == "Cursed.dlls") | (input == "cursed dll") | (input == "curseddll") | (input == "2"))
                {
                    Console.WriteLine("CursedDLLs selected");
                    if (ModList.OnlineCheck())
                    {
                        Downloader.DownloadCursedDlls(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"));
                        InstallMods.InstallCurseddlls();
                        Console.Write("Press any key to exit the installer");
                        Console.ReadKey();
                        return;
                    }
                }

                if ((input == "TNHTweaker") | (input == "TNH Tweaker") | (input == "tnhtweaker") |
                    (input == "tnh tweaker") | (input == "3"))
                {
                    Console.WriteLine("TNHTweaker selected");
                    if (ModList.OnlineCheck())
                    {
                        Downloader.DownloadTnhTweaker(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"));
                        InstallMods.InstallTnhTweaker();
                        Console.Write("Press any key to exit the installer");
                        Console.ReadKey();
                        return;
                    }
                }

                if ((input == "All") | (input == "all") | (input == "4"))
                {
                    Console.WriteLine("All selected");
                    if (ModList.OnlineCheck())
                        Downloader.DownloadAll(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"));
                    Installer.InstallAll();
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
    internal class ModList
    {
        public readonly string[] CursedDllsFiles =
        {
            "BepInEx_x64_5.4.4.0.zip", "BepInEx.MonoMod.Loader_1.0.0.0.zip", "CursedDlls.BepInEx_v1.3.zip"
        };

        public readonly string[] CursedDllsPaths =
        {
            "https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/",
            "https://github.com/BepInEx/BepInEx.MonoMod.Loader/releases/download/v1.0.0.0/",
            "https://github.com/drummerdude2003/CursedDlls.BepinEx/releases/download/v1.3/"
        };

        public readonly string[] TnhTweakerFiles =
        {
            "BepInEx_x64_5.4.4.0.zip", "TakeAndHoldTweaker.dll"
        };

        public readonly string[] TnhTweakerPaths =
        {
            "https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/",
            "https://github.com/devyndamonster/TakeAndHoldTweaker/releases/download/v1.3.0/"
        };

        public readonly string[] WurstModFiles =
        {
            "BepInEx_x64_5.4.4.0.zip", "Deli-v0.2.5.zip", "WurstMod.deli"
        };

        public readonly string[] WurstModPaths =
        {
            "https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/",
            "https://github.com/Deli-Counter/Deli/releases/download/v0.2.5/",
            "https://github.com/Nolenz/WurstMod/releases/download/v2.0.2.0/"
        };
        
        

        public static bool OnlineCheck()
        {
            var checkOnline = new CheckOnline();

            if (CheckOnline.isOnline("www.github.com"))
            {
                Console.WriteLine("GitHub is Online!");
                return true;
            }

            Console.WriteLine("Github is either down, or no internet is detected!");
            return false;
        }
    }

    internal class CheckOnline
    {
        public static bool isOnline(string url)
        {
            var ping = new Ping();
            var reply = ping.Send(url, 1000);


            if (reply != null && reply.Status == IPStatus.Success)
                return true;

            return false;
        }
    }

    internal class Downloader
    {
        private readonly WebClient _downloader = new();

        public bool DownloadMod(string locationOfFile, string fileToDownload)
        {
            Console.WriteLine("Downloading Mod \"{0}\" from \"{1}{0}\"\n", fileToDownload, locationOfFile);


            _downloader.DownloadFile(locationOfFile + fileToDownload, fileToDownload);

            Console.WriteLine("Successfully Downloaded Mod \"{0}\" from \"{1}{0}\"\n", fileToDownload, locationOfFile);

            return true;
        }
    }

    internal class DownloadMods
    {
        private readonly Downloader _downloader = new();
        private readonly InstallMods _installer = new();
        private readonly ModList _mods = new();

        public bool DownloadWurstMod(bool hasBepInEx)
        {
            if (!hasBepInEx)
            {
                Console.WriteLine("BepInEx not detected! Downloading.");
                _downloader.DownloadMod(_mods.WurstModPaths[0], _mods.WurstModFiles[0]);
                InstallMods.InstallBepInEx();
            }

            /*
            var wurstModDeps = new List<Mods>
            {
                new Mods {Path = mods.wurstModPaths, Files = mods.wurstModFiles}
            };
            */

            for (var i = 1; i < 3; i++) _downloader.DownloadMod(_mods.WurstModPaths[i], _mods.WurstModFiles[i]);
            return true;
        }

        public bool DownloadCursedDlls(bool hasBepInEx)
        {
            if (!hasBepInEx)
            {
                Console.WriteLine("BepInEx not detected! Downloading.");
                _downloader.DownloadMod(_mods.WurstModPaths[0], _mods.WurstModFiles[0]);
                InstallMods.InstallBepInEx();
            }

            for (var i = 1; i < 3; i++) _downloader.DownloadMod(_mods.CursedDllsPaths[i], _mods.CursedDllsFiles[i]);
            return true;
        }

        public bool DownloadTnhTweaker(bool hasBepInEx)
        {
            if (!hasBepInEx)
            {
                Console.WriteLine("BepInEx not detected! Downloading.");
                _downloader.DownloadMod(_mods.WurstModPaths[0], _mods.WurstModFiles[0]);
                InstallMods.InstallBepInEx();
            }

            for (var i = 1; i < 2; i++) _downloader.DownloadMod(_mods.TnhTweakerPaths[i], _mods.TnhTweakerFiles[i]);
            return true;
        }

        public bool DownloadAll(bool hasBepInEx)
        {
            if (!hasBepInEx)
            {
                Console.WriteLine("BepInEx not detected! Downloading.");
                _downloader.DownloadMod(_mods.WurstModPaths[0], _mods.WurstModFiles[0]);
                InstallMods.InstallBepInEx();
            }

            for (var i = 1; i < 3; i++)
            {
                _downloader.DownloadMod(_mods.WurstModPaths[i], _mods.WurstModFiles[i]);
                _downloader.DownloadMod(_mods.CursedDllsPaths[i], _mods.CursedDllsFiles[i]);
            }

            for (var i = 1; i < 2; i++)
                _downloader.DownloadMod(_mods.TnhTweakerPaths[i], _mods.TnhTweakerFiles[i]);

            return true;
        }
    }

    internal class Installer
    {
        public bool Unzip(string fileToUnzip, string unzipLocation, bool deleteArchiveAfterUnzip)
        {
            //why do I even have this?
            Console.WriteLine("Unzipping " + fileToUnzip);
            ZipFile.ExtractToDirectory(fileToUnzip, unzipLocation);
            if (deleteArchiveAfterUnzip)
                Console.WriteLine("Cleaning up");
            File.Delete(fileToUnzip);
            return true;
        }

        public bool MoveFileToPlugins(string fileToMove, string locationToMoveTo = "BepInEx/Plugins")
        {
            //this is even more redundant!
            File.Move(fileToMove, locationToMoveTo + fileToMove);
            return true;
        }

        /*
        public bool moveDirToBepInEx(string dirToMove, string locationToMoveTo)
        {
            //more redundancy
            Directory.Move(dirToMove, locationToMoveTo + dirToMove);
            return true;
        }
        */
        public bool InstallDeliMod(string deliMod, string modsDir = "Mods/")
        {
            if (!Directory.Exists(modsDir))
                Directory.CreateDirectory(modsDir);
            File.Move(deliMod, modsDir + deliMod);
            return true;
        }
    }

    internal class InstallMods
    {
        private static readonly Installer Installer = new();

        public static bool InstallBepInEx()
        {
            Installer.Unzip("BepInEx_x64_5.4.4.0.zip", Directory.GetCurrentDirectory() + "/", false);
            Console.WriteLine("Installed BepInEx!");
            return true;
        }

        public static bool InstallWurstMod()
        {
            Installer.Unzip("Deli-v0.2.5.zip", Directory.GetCurrentDirectory(), true);
            Console.WriteLine("Installed Deli!");

            Installer.InstallDeliMod("WurstMod.deli");
            Console.WriteLine("Installed WurstMod!");
            return true;
        }

        public static bool InstallCurseddlls()
        {
            Installer.Unzip("BepInEx.MonoMod.Loader_1.0.0.0.zip", Directory.GetCurrentDirectory() + "/", true);
            Console.WriteLine("Installed Monomod!");
            Installer.Unzip("CursedDlls.BepInEx_v1.3.zip", Directory.GetCurrentDirectory() + "/", true);
            Console.WriteLine("Installed Cursed.Dlls!");
            return true;
        }

        public static bool InstallTnhTweaker()
        {
            Installer.MoveFileToPlugins("TakeAndHoldTweaker.dll");
            Console.WriteLine("Installed TNH Tweaker!");
            return true;
        }

        public bool InstallAll()
        {
            Console.WriteLine("Installing WurstMod!");
            InstallWurstMod();
            Console.WriteLine("Installing Cursed Dlls!");
            InstallCurseddlls();
            Console.WriteLine("Installing TNH Tweaker!");
            InstallTnhTweaker();

            Console.WriteLine("Successfully installed ALL mods!");
            return true;
        }
    }
=======
﻿using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.NetworkInformation;


namespace H3VRModInstaller
{
    internal class Program
    {
        private static readonly ModList mods = new();
        private static readonly DownloadMods downloader = new();
        private static readonly InstallMods installer = new();

        private static void Main(string[] args)
        {
            if (File.Exists("H3VR.exe"))
            {
                Console.WriteLine("H3VR.exe detected");
                Console.WriteLine("Welcome to the H3VR Mod installer!");
                Console.WriteLine("Please select the mod you would like to install!");
                Console.WriteLine("1: WurstMod");
                Console.WriteLine("2: Cursed DLLs");
                Console.WriteLine("3: TNHTweaker");
                //Console.WriteLine("4: All (warning, pretty buggy)");
                Console.Write("Input the mod you would like to install: ");
                var input = Console.ReadLine();
                if ((input == "WurstMod") | (input == "Wurst Mod") | (input == "wurstmod") | (input == "wurst mod") |
                    (input == "1"))
                {
                    Console.WriteLine("WurstMod selected");
                    if (mods.onlineCheck())
                    {
                        downloader.downloadWurstMod(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"));
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
                        downloader.downloadCursedDlls(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"));
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
                        downloader.downloadTNHTweaker(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"));
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
                        downloader.downloadAll(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"));
                    installer.installAll();
                    Console.Write("Press any key to exit the installer");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("INVALID INPUT");
                    Console.ReadKey();
                    return;
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
    internal class ModList
    {
        public string[] cursedDllsFiles =
            {"BepInEx_x64_5.4.4.0.zip", "BepInEx.MonoMod.Loader_1.0.0.0.zip", "CursedDlls.BepInEx_v1.3.zip"};

        public string[] cursedDllsPaths =
        {
            "https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/",
            "https://github.com/BepInEx/BepInEx.MonoMod.Loader/releases/download/v1.0.0.0/",
            "https://github.com/drummerdude2003/CursedDlls.BepinEx/releases/download/v1.3/"
        };

        public string[] TNHTweakerFiles = {"BepInEx_x64_5.4.4.0.zip", "TakeAndHoldTweaker.dll"};

        public string[] TNHTweakerPaths =
        {
            "https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/",
            "https://github.com/devyndamonster/TakeAndHoldTweaker/releases/download/v1.3.0/"
        };

        public string[] wurstModFiles = {"BepInEx_x64_5.4.4.0.zip", "Deli-v0.2.5.zip", "WurstMod.deli"};

        public string[] wurstModPaths =
        {
            "https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/",
            "https://github.com/Deli-Counter/Deli/releases/download/v0.2.5/",
            "https://github.com/Nolenz/WurstMod/releases/download/v2.0.2.0/"
        };

        public bool onlineCheck()
        {
            var checkOnline = new CheckOnline();

            if (checkOnline.isOnline("www.github.com"))
            {
                Console.WriteLine("GitHub is Online!");
                return true;
            }

            Console.WriteLine("Github is either down, or no internet is detected!");
            return false;
        }
    }

    internal class CheckOnline
    {
        public bool isOnline(string URL)
        {
            var ping = new Ping();
            var reply = ping.Send(URL, 1000);


            if (reply.Status == IPStatus.Success)
                return true;
            return false;
        }
    }

    internal class Downloader
    {
        private readonly WebClient downloader = new();

        public bool downloadMod(string locationOfFile, string fileToDownload)
        {
            Console.WriteLine("Downloading Mod \"{0}\" from \"{1}{0}\"\n", fileToDownload, locationOfFile);


            downloader.DownloadFile(locationOfFile + fileToDownload, fileToDownload);

            Console.WriteLine("Successfully Downloaded Mod \"{0}\" from \"{1}{0}\"\n", fileToDownload, locationOfFile);

            return true;
        }
    }

    internal class DownloadMods
    {
        private readonly Downloader downloader = new();
        private readonly InstallMods installer = new();
        private readonly ModList mods = new();

        public bool downloadWurstMod(bool hasBepInEx)
        {
            if (!hasBepInEx)
            {
                Console.WriteLine("BepInEx not detected! Downloading.");
                downloader.downloadMod(mods.wurstModPaths[0], mods.wurstModFiles[0]);
                installer.installBepInEx();
            }

            /*
            var wurstModDeps = new List<Mods>
            {
                new Mods {Path = mods.wurstModPaths, Files = mods.wurstModFiles}
            };
            */

            for (var i = 1; i < 3; i++) downloader.downloadMod(mods.wurstModPaths[i], mods.wurstModFiles[i]);
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
    }

    internal class Installer
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
            File.Move(fileToMove, locationToMoveTo + fileToMove);
            return true;
        }

        public bool moveDirToBepInEx(string dirToMove, string locationToMoveTo)
        {
            //more redundancy
            Directory.Move(dirToMove, locationToMoveTo + dirToMove);
            return true;
        }

        public bool installDeliMod(string deliMod, string modsDir = "Mods/")
        {
            if (!Directory.Exists(modsDir))
                Directory.CreateDirectory(modsDir);
            File.Move(deliMod, modsDir + deliMod);
            return true;
        }
    }

    internal class InstallMods
    {
        private static readonly Installer installer = new();

        public bool installBepInEx()
        {
            installer.unzip("BepInEx_x64_5.4.4.0.zip", Directory.GetCurrentDirectory() + "/", false);
            Console.WriteLine("Installed BepInEx!");
            return true;
        }

        public bool installWurstMod()
        {
            installer.unzip("Deli-v0.2.5.zip", Directory.GetCurrentDirectory(), true);
            Console.WriteLine("Installed Deli!");

            installer.installDeliMod("WurstMod.deli");
            Console.WriteLine("Installed WurstMod!");
            return true;
        }

        public bool installCurseddlls()
        {
            installer.unzip("BepInEx.MonoMod.Loader_1.0.0.0.zip", Directory.GetCurrentDirectory() + "/", true);
            Console.WriteLine("Installed Monomod!");
            installer.unzip("CursedDlls.BepInEx_v1.3.zip", Directory.GetCurrentDirectory() + "/", true);
            Console.WriteLine("Installed Cursed.Dlls!");
            return true;
        }

        public bool installTNHTweaker()
        {
            installer.moveFileToPlugins("TakeAndHoldTweaker.dll");
            Console.WriteLine("Installed TNH Tweaker!");
            return true;
        }

        public bool installAll()
        {
            Console.WriteLine("Installing WurstMod!");
            installWurstMod();
            Console.WriteLine("Installing Cursed Dlls!");
            installCurseddlls();
            Console.WriteLine("Installing TNH Tweaker!");
            installTNHTweaker();
            
            Console.WriteLine("Successfully installed ALL mods!");
            return true;
        }
        
    }
>>>>>>> parent of b87a9e8... More cleanup
=======
﻿using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.NetworkInformation;


namespace H3VRModInstaller
{
    internal class Program
    {
        private static readonly ModList mods = new();
        private static readonly DownloadMods downloader = new();
        private static readonly InstallMods installer = new();

        private static void Main(string[] args)
        {
            if (File.Exists("H3VR.exe"))
            {
                Console.WriteLine("H3VR.exe detected");
                Console.WriteLine("Welcome to the H3VR Mod installer!");
                Console.WriteLine("Please select the mod you would like to install!");
                Console.WriteLine("1: WurstMod");
                Console.WriteLine("2: Cursed DLLs");
                Console.WriteLine("3: TNHTweaker");
                //Console.WriteLine("4: All (warning, pretty buggy)");
                Console.Write("Input the mod you would like to install: ");
                var input = Console.ReadLine();
                if ((input == "WurstMod") | (input == "Wurst Mod") | (input == "wurstmod") | (input == "wurst mod") |
                    (input == "1"))
                {
                    Console.WriteLine("WurstMod selected");
                    if (mods.onlineCheck())
                    {
                        downloader.downloadWurstMod(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"));
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
                        downloader.downloadCursedDlls(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"));
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
                        downloader.downloadTNHTweaker(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"));
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
                        downloader.downloadAll(Directory.Exists(Directory.GetCurrentDirectory() + "/BepInEx/"));
                    installer.installAll();
                    Console.Write("Press any key to exit the installer");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("INVALID INPUT");
                    Console.ReadKey();
                    return;
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
    internal class ModList
    {
        public string[] cursedDllsFiles =
            {"BepInEx_x64_5.4.4.0.zip", "BepInEx.MonoMod.Loader_1.0.0.0.zip", "CursedDlls.BepInEx_v1.3.zip"};

        public string[] cursedDllsPaths =
        {
            "https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/",
            "https://github.com/BepInEx/BepInEx.MonoMod.Loader/releases/download/v1.0.0.0/",
            "https://github.com/drummerdude2003/CursedDlls.BepinEx/releases/download/v1.3/"
        };

        public string[] TNHTweakerFiles = {"BepInEx_x64_5.4.4.0.zip", "TakeAndHoldTweaker.dll"};

        public string[] TNHTweakerPaths =
        {
            "https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/",
            "https://github.com/devyndamonster/TakeAndHoldTweaker/releases/download/v1.3.0/"
        };

        public string[] wurstModFiles = {"BepInEx_x64_5.4.4.0.zip", "Deli-v0.2.5.zip", "WurstMod.deli"};

        public string[] wurstModPaths =
        {
            "https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/",
            "https://github.com/Deli-Counter/Deli/releases/download/v0.2.5/",
            "https://github.com/Nolenz/WurstMod/releases/download/v2.0.2.0/"
        };

        public bool onlineCheck()
        {
            var checkOnline = new CheckOnline();

            if (checkOnline.isOnline("www.github.com"))
            {
                Console.WriteLine("GitHub is Online!");
                return true;
            }

            Console.WriteLine("Github is either down, or no internet is detected!");
            return false;
        }
    }

    internal class CheckOnline
    {
        public bool isOnline(string URL)
        {
            var ping = new Ping();
            var reply = ping.Send(URL, 1000);


            if (reply.Status == IPStatus.Success)
                return true;
            return false;
        }
    }

    internal class Downloader
    {
        private readonly WebClient downloader = new();

        public bool downloadMod(string locationOfFile, string fileToDownload)
        {
            Console.WriteLine("Downloading Mod \"{0}\" from \"{1}{0}\"\n", fileToDownload, locationOfFile);


            downloader.DownloadFile(locationOfFile + fileToDownload, fileToDownload);

            Console.WriteLine("Successfully Downloaded Mod \"{0}\" from \"{1}{0}\"\n", fileToDownload, locationOfFile);

            return true;
        }
    }

    internal class DownloadMods
    {
        private readonly Downloader downloader = new();
        private readonly InstallMods installer = new();
        private readonly ModList mods = new();

        public bool downloadWurstMod(bool hasBepInEx)
        {
            if (!hasBepInEx)
            {
                Console.WriteLine("BepInEx not detected! Downloading.");
                downloader.downloadMod(mods.wurstModPaths[0], mods.wurstModFiles[0]);
                installer.installBepInEx();
            }

            /*
            var wurstModDeps = new List<Mods>
            {
                new Mods {Path = mods.wurstModPaths, Files = mods.wurstModFiles}
            };
            */

            for (var i = 1; i < 3; i++) downloader.downloadMod(mods.wurstModPaths[i], mods.wurstModFiles[i]);
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
    }

    internal class Installer
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
            File.Move(fileToMove, locationToMoveTo + fileToMove);
            return true;
        }

        public bool moveDirToBepInEx(string dirToMove, string locationToMoveTo)
        {
            //more redundancy
            Directory.Move(dirToMove, locationToMoveTo + dirToMove);
            return true;
        }

        public bool installDeliMod(string deliMod, string modsDir = "Mods/")
        {
            if (!Directory.Exists(modsDir))
                Directory.CreateDirectory(modsDir);
            File.Move(deliMod, modsDir + deliMod);
            return true;
        }
    }

    internal class InstallMods
    {
        private static readonly Installer installer = new();

        public bool installBepInEx()
        {
            installer.unzip("BepInEx_x64_5.4.4.0.zip", Directory.GetCurrentDirectory() + "/", false);
            Console.WriteLine("Installed BepInEx!");
            return true;
        }

        public bool installWurstMod()
        {
            installer.unzip("Deli-v0.2.5.zip", Directory.GetCurrentDirectory(), true);
            Console.WriteLine("Installed Deli!");

            installer.installDeliMod("WurstMod.deli");
            Console.WriteLine("Installed WurstMod!");
            return true;
        }

        public bool installCurseddlls()
        {
            installer.unzip("BepInEx.MonoMod.Loader_1.0.0.0.zip", Directory.GetCurrentDirectory() + "/", true);
            Console.WriteLine("Installed Monomod!");
            installer.unzip("CursedDlls.BepInEx_v1.3.zip", Directory.GetCurrentDirectory() + "/", true);
            Console.WriteLine("Installed Cursed.Dlls!");
            return true;
        }

        public bool installTNHTweaker()
        {
            installer.moveFileToPlugins("TakeAndHoldTweaker.dll");
            Console.WriteLine("Installed TNH Tweaker!");
            return true;
        }

        public bool installAll()
        {
            Console.WriteLine("Installing WurstMod!");
            installWurstMod();
            Console.WriteLine("Installing Cursed Dlls!");
            installCurseddlls();
            Console.WriteLine("Installing TNH Tweaker!");
            installTNHTweaker();
            
            Console.WriteLine("Successfully installed ALL mods!");
            return true;
        }
        
    }
>>>>>>> parent of b87a9e8... More cleanup
}