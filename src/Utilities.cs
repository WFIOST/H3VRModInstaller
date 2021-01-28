using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace H3VRModInstaller.GUI
{
    public static class Utilities
    {
        private static bool scanned = false;
        private static string _gameLocation = "";

        public static string GameDirectory
        {
            get
            {
                // If the game isn't found, return null
                if (scanned) return string.IsNullOrEmpty(_gameLocation) ? null : _gameLocation;
                scanned = true;

                // Get the main steam installation location via registry.
                var steamDir = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", "") as string;
                if (string.IsNullOrEmpty(steamDir)) steamDir = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath", "") as string;
                if (string.IsNullOrEmpty(steamDir)) return null;

                // Check main steamapps library folder for h3 manifest.
                var result = "";
                if (File.Exists(steamDir + @"\steamapps\appmanifest_450540.acf")) result = steamDir + @"\steamapps\common\H3VR\";
                else
                {
                    // We didn't find it, look at other library folders by lazily parsing libraryfolders.
                    foreach (var ii in File.ReadAllLines(steamDir + "/steamapps/libraryfolders.vdf").Skip(4).Where(x => x.Length != 0 && x[0] != '}').Select(x => x.Split('\t')[3].Trim('"').Replace(@"\\", @"\")).Where(ii => File.Exists(ii + @"\steamapps\appmanifest_450540.acf")))
                    {
                        result = ii + @"\steamapps\common\H3VR\";
                        break;
                    }
                }

                _gameLocation = result;
                if (!string.IsNullOrEmpty(_gameLocation)) return _gameLocation;
                MessageBox.Show("Could not auto-detect H3VR installation directory. Is your game installed outside Steam or pirated?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static string ExecutablePath => string.IsNullOrEmpty(GameDirectory) ? null : Path.Combine(GameDirectory, "h3vr.exe");
        public static string ModCache => string.IsNullOrEmpty(GameDirectory) ? null : Path.Combine(GameDirectory, "installed_mods.json");

        /// <summary>
        /// Runs the tree command on the H3 directory for additional debugging
        /// </summary>
        public static void GenerateTree()
        {
            // If the H3 folder isn't found, just return and show the generic error box
            if (string.IsNullOrEmpty(GameDirectory))
            {
                ShowErrorH3NotFound();
                return;
            }

            // Create a string builder and output the current time
            var sb = new StringBuilder();
            sb.AppendLine($"Generated at {DateTime.Now}");

            // Start the tree command and wait for it to exit
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo("cmd.exe", $"/C tree /F /A {GameDirectory}")
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
                else if (skip && line.StartsWith("\\---")) skip = false;

                if (!skip) sb.AppendLine(line);
            }

            // Write the output
            var path = Path.Join(GameDirectory, "tree_output.txt");
            File.WriteAllText(path, sb.ToString());
            MessageBox.Show($"Written tree output to {path}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Generic H3 isn't found error.
        /// </summary>
        private static void ShowErrorH3NotFound()
        {
            MessageBox.Show("Cannot perform this action because your H3 install location could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}