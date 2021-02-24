using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
        public static bool enableDebugging = true;

        /// <summary>
        ///     Bypasses the check for H3VR.EXE
        /// </summary>
        public static bool BypassExec = false;

        /// <summary>
        ///     Website used to ping to ensure internet access
        /// </summary>
        public static string Pingsite = "www.github.com";

        /// <summary>
        ///     Current version.
        /// </summary>
        public static Version ModInstallerVersion = new(1, 0, 2);


        /// <summary>
        ///     Writes line if enabledebugging is true.
        /// </summary>
        public static void DebugLog(string input)
        {
            if (enableDebugging) Console.WriteLine(input);
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
            var strng = "";
            for (var i = 0; i < array.Length; i++)
            {
                strng += array[i];
                strng += ", ";
            }

            return strng;
        }

        /// <summary>
        ///     Useful fields for filesystem work
        /// </summary>
        public class Files
        {
            /// <summary>
            ///     loc of the MI lists.
            /// </summary>
            public static string Modinstallerdir = Directory.GetCurrentDirectory() + @"/ModInstallerLists/";
            
            public static string DataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\H3VR Mod Installer\\");

            public static string ConfigFile = Path.Combine(DataDir + "config.H3VRMI");

            public static string H3VRSteamLoc = "steam://rungameid/450540";
        }
        
        /// <summary>
        ///     Function that gets the overrides for debugging
        /// </summary>
        public static void OverrideModInstallerVariables()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + "MICoverride.json")) return;
            Console.WriteLine("MICOverride.json detected!");
            var depinput = JsonConvert.DeserializeObject<MICoverrideVars>(File.ReadAllText(Directory.GetCurrentDirectory() + "/" + "MICoverride.json"));
            if (depinput.DatabaseInfo != null)
            {
                Console.WriteLine("Overriding DatabaseInfo with " + depinput.DatabaseInfo);
                Utilities.DatabaseInfo = depinput.DatabaseInfo;
            }
            if (depinput.RootFolderName != null)
            {
                Console.WriteLine("Overriding Game Name with " + depinput.RootFolderName);
                Utilities.gamename = depinput.RootFolderName;
            }
            if (depinput.ACFname != null)
            {
                Console.WriteLine("Overriding ACFname with " + depinput.ACFname);
                Utilities.acfpath = depinput.ACFname;
            }
        }

        public class MICoverrideVars
        {
            public string RootFolderName { get; set; }
            public string DatabaseInfo { get; set; }
            public string ACFname { get; set; }
        }
    }
    
    

    
    
    public static class Utilities
    {
        private static bool scanned;
        private static string _gameLocation = "";
		public static string gamename = "H3VR";
		public static string acfpath = "appmanifest_450540.acf";

		/// <summary>
		///     Returns GameDirectory. Terminates with a \, so DONT add it.
		/// </summary>
		public static string GameDirectory
        {
            get
            {
                // If the game isn't found, return null
                if (scanned) return string.IsNullOrEmpty(_gameLocation) ? null : _gameLocation;
                scanned = true;

                //lmao
                if (!OperatingSystem.IsWindows()) return null;

                // Get the main steam installation location via registry.
                var steamDir =
                    Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", "") as string;
                if (string.IsNullOrEmpty(steamDir))
                    steamDir = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath",
                        "") as string;
                if (string.IsNullOrEmpty(steamDir)) return null;

                // Check main steamapps library folder for h3 manifest.
                var result = "";
                if (File.Exists(steamDir + @"\steamapps\" + acfpath))
                    result = steamDir + @"\steamapps\common\" + gamename + @"\";
                else
                    // We didn't find it, look at other library folders by lazily parsing libraryfolders.
                    foreach (var ii in File.ReadAllLines(steamDir + "/steamapps/libraryfolders.vdf").Skip(4)
                        .Where(x => x.Length != 0 && x[0] != '}')
                        .Select(x => x.Split('\t')[3].Trim('"').Replace(@"\\", @"\"))
                        .Where(ii => File.Exists(ii + @"\steamapps\" + acfpath)))
                    {
                        result = ii + @"\steamapps\common\" + gamename + @"\";
                        break;
                    }

                _gameLocation = result;
                if (!string.IsNullOrEmpty(_gameLocation)) return _gameLocation;
                MessageBox.Show(
                    "Could not auto-detect H3VR installation directory. Is your game installed outside Steam or pirated?",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (!skip) sb.AppendLine(line);
            }

            // Write the output
            var path = Path.Join(GameDirectoryOrThrow, "tree_output.txt");
            File.WriteAllText(path, sb.ToString());
            MessageBox.Show($"Written tree output to {path}.", "Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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