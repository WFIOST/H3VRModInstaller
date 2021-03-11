using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using H3VRModInstaller.JSON;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace H3VRModInstaller.Common
{
    /// <summary>
    ///     Some common variables used across the project
    /// </summary>

    public class ModInstallerCommon
    {
        /// <summary>
        ///     Enables Debugging
        /// </summary>
        public static bool enableDebugging
        {
            get
            {
                #if DEBUG
                return true;
                #endif
                return false;
            }
        }

        /// <summary>
        ///     Website used to ping to ensure internet access
        /// </summary>
        public const string Pingsite = "www.github.com";


        /// <summary>
        ///     Writes line if enabledebugging is true.
        /// </summary>
        public static void DebugLog(string input)
        {
            if (enableDebugging) {Console.WriteLine(input);}
        }

        /// <summary>
        ///     "better" errors
        /// </summary>
        /// <param name="error">Error to write</param>
        public static void throwexept(string error)
        {
            Console.Title = "ERROR! - " + error;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ReadKey();
        }

        /// <summary>
        ///     returns a string array as foo[1], foo[2], foo[3], etc
        /// </summary>
        public static string ReturnArrayInString(string[] array)
        {
            var str = "";
            for (var i = 0; i < array.Length; i++)
            {
                str += array[i];
                str += ", ";
            }

            return str;
        }

        /// <summary>
        ///     Function that gets the overrides for debugging
        /// </summary>
        public static void OverrideModInstallerVariables()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + "MICoverride.json"))
            {
                return;
            }

            var depinput =
                JsonConvert.DeserializeObject<MICoverrideVars>(
                    File.ReadAllText(Directory.GetCurrentDirectory() + "/" + "MICoverride.json"));
            if (depinput.DatabaseInfo != null)
            {
                Console.WriteLine("Overriding DatabaseInfo with " + depinput.DatabaseInfo);
                Utilities.DatabaseInfo = depinput.DatabaseInfo;
            }

            if (depinput.RootFolderName != null)
            {
                Console.WriteLine("Overriding Game Name with " + depinput.RootFolderName);
                Utilities.GameName = depinput.RootFolderName;
            }

            if (depinput.ACFname != null)
            {
                Console.WriteLine("Overriding ACFname with " + depinput.ACFname);
                Utilities.ACFpath = depinput.ACFname;
            }

        }

        /// <summary>
        /// Useful dictionaries
        /// </summary>
        public static class Dictionaries
        {
            public static Dictionary<string, ModFile> ModFileRegistry
            {
                get
                {
                    return JsonModList.GetModLists()
                        .SelectMany(list => list.Modlist)
                        .ToDictionary(mod => mod.ModId);
                }
            }

            public static Dictionary<string, ModFile[]> ModListRegistry
            {
                get
                {
                    return JsonModList.GetModLists()
                        .ToDictionary(list => list.ModListName,
                            list => list.Modlist);
                    
                }
            }

            public static Dictionary<string[], SingularMods> SingularModNameRegistry
            {
                get
                {
                    return JsonModList.GetModLists()
                        .SelectMany(list => list.Modlist
                        ).ToDictionary(mod => mod.SingularModData.OccupiesName,
                            mod => mod.SingularModData);
                }
            }
            
            public static Dictionary<string[], SingularMods> SingularModIDRegistry
            { 
                get 
                { 
                    return JsonModList.GetModLists()
                        .SelectMany(list => list.Modlist)
                        .ToDictionary(mod => mod.SingularModData.OccupiesID, 
                            mod => mod.SingularModData);
                }
            }
        }

        public class MICoverrideVars
        {
            public string RootFolderName { get; set; }
            public string DatabaseInfo { get; set; }
            public string ACFname { get; set; }
        }
    }

    public static class funcUtils
    {
        public static bool FileOrDirExists(string path)
        {
            if (File.Exists(path) || Directory.Exists(path)){ return true; }
            return false;
        }
    }
    
    

    
    
    public static class Utilities
    {
        private static bool scanned;
        private static string _gameLocation = "";
		private static string gamename = "H3VR";
		private static string acfpath = "appmanifest_450540.acf";

        public static string UpdateInfoPath
        {
            get { return "https://raw.githubusercontent.com/WFIOST/H3VR-Mod-Installer-Database/main/Database/updateinfo.xml"; }
        }
        
        public static string GameName
        {
            get => gamename;
            set => gamename = value;
        }

        public static string ACFpath
        {
            get => acfpath;
            set => acfpath = value;
        }

        public static Version ModInstallerVersion
        {
            get { return new Version(1, 1, 0); }
        }
        
		/// <summary>
		///     Returns GameDirectory. Terminates with a \, so DONT add it.
		/// </summary>
		public static string GameDirectory
        {
            get
            {
                // If the game isn't found, return null
                if (scanned) {return string.IsNullOrEmpty(_gameLocation) ? null : _gameLocation;}
                scanned = true;

                //lmao
                if (!OperatingSystem.IsWindows()) {return null;}

                // Get the main steam installation location via registry.
                var steamDir =
                    Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", "") as string;
                if (string.IsNullOrEmpty(steamDir))
                    steamDir = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath",
                        "") as string;
                if (string.IsNullOrEmpty(steamDir)) {return null;}

                // Check main steamapps library folder for h3 manifest.
                var result = "";
                if (File.Exists(steamDir + @"\steamapps\" + acfpath))
                {
                    result = steamDir + @"\steamapps\common\" + gamename + @"\";
                }
                else
                {
                    // We didn't find it, look at other library folders by lazily parsing libraryfolders.
                    foreach (var ii in File.ReadAllLines(steamDir + "/steamapps/libraryfolders.vdf").Skip(4)
                        .Where(x => x.Length != 0 && x[0] != '}')
                        .Select(x => x.Split('\t')[3].Trim('"').Replace(@"\\", @"\"))
                        .Where(ii => File.Exists(ii + @"\steamapps\" + acfpath)))
                    {
                        result = ii + @"\steamapps\common\" + gamename + @"\";
                        break;
                    }
                }

                _gameLocation = result;
/*                if (!string.IsNullOrEmpty(_gameLocation)) {return _gameLocation;}
                MessageBox.Show(
                    "Could not auto-detect H3VR installation directory. Is your game installed outside Steam or pirated?",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
                return null;
            }
        }

        public static string ExecutablePath => string.IsNullOrEmpty(GameDirectory) ? null : Path.Combine(GameDirectory, "h3vr.exe");

		private static string _modcache;

		public static string ModCache
		{
			get
			{
				if (string.IsNullOrEmpty(_modcache))
				{
					_modcache = Path.Combine(GameDirectory, "installed_mods.json");
				}
				return _modcache;
			}
			set
			{
				_modcache = value;
			}
		}

        public static string DisableCache
        {
            get
            {
                return Path.Combine(GameDirectory, "ModInstallerCache/DisabledMods/");
            }
        }
        
        /// <summary>
        ///     Where the database for modinstaller is kept
        /// </summary>
        public static string DatabaseInfo
        {
            get { return databaseInfo; }
            set { databaseInfo = value; }
        }
        private static string databaseInfo = "https://raw.githubusercontent.com/Frityet/H3VRModInstaller/master/src/Backend/JSON/Database/modinstallerinfo.h3vrmi";

		/*        public static string ModCache => string.IsNullOrEmpty(GameDirectory)
					? null
					: Path.Combine(GameDirectory, "installed_mods.json");*/

		/// <summary>
		///     Use this if you absolutely 100% need the game directory. If it was not auto discovered it will throw an exception
		/// </summary>
		public static string GameDirectoryOrThrow => GameDirectory ?? throw new FileNotFoundException("Could not find game directory.");

        public static string Modinstallerdir
        {
            get { return Directory.GetCurrentDirectory() + @"/ModInstallerLists/"; }
        }

        public static string DataDir
        {
            get {return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\H3VR Mod Installer\\");}
        }

        public static string ConfigFile{ get {return Path.Combine(DataDir + "config.H3VRMI");}}

        private static string h3vrSteamLoc = "steam://rungameid/450540";
        public static string H3VRSteamLoc {get {return h3vrSteamLoc;} set { h3vrSteamLoc = value; }} 
            
        public static string LogPath {get{return Utilities.GameDirectory + "ModInstaller.log";}} 
        
        /// <summary>
        ///     Runs the tree command on the H3 directory for additional debugging
        /// </summary>
        public static void GenerateTree()
        {
            // Create a string builder and output the current time
            var sb = new StringBuilder();
            sb.AppendLine($"Generated at {DateTime.Now}");

            // Start the tree command and wait for it to exit
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo("cmd.exe", $"/C tree /F /A {GameDirectoryOrThrow}")
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            proc.Start();
            var output = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();


            // Iterate over the output lines and remove the h3vr_Data folder from it
            var skip = false;
            foreach (var line in output.Split("\r\n"))
            {
                if (line == "\\---h3vr_Data")
                {
                    skip = true;
                    sb.AppendLine(line + " (TRUNCATED)");
                }
                else if (skip && line.StartsWith("\\---"))
                {
                    skip = false;
                }

                if (!skip) {sb.AppendLine(line);}
            }

            // Write the output
            var path = Path.Join(GameDirectoryOrThrow, "tree_output.txt");
            File.WriteAllText(path, sb.ToString());
/*            MessageBox.Show($"Written tree output to {path}.", "Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);*/
        }
    }

    public class ConfigFile
    {
        public bool RemoveConfigsOnDeletion { get; set; }
        public bool DeleteArchiveOnFinish { get; set; }
        public string H3VRPath { get; set; }
        public string OverridePath { get; set; }
        public bool DebugMode { get; set; }
    }
}