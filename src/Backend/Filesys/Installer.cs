using System;
using System.IO;
using H3VRModInstaller.Backend.Common;
using H3VRModInstaller.Backend.JSON;
using H3VRModInstaller.GUI;

namespace H3VRModInstaller.Backend.Filesys
{
    /// <summary>
    ///     This class manages the installation of mods!
    /// </summary>
    public class Installer
    {
        /// <summary>
        ///     This function installs a mod based off the parameters provided. The first parameter is the an 5-length array which
        ///     represents the file info. The second parameter is a bool which determines if the archive will be deleted after
        ///     installation.
        /// </summary>
        /// <param name="fileinfo">ModFile class, gets the <c>rawname</c> from it</param>
        /// <param name="delArchive">Defines if the archive should be deleted after installation</param>
        /// <returns>Boolean</returns>
        public static bool InstallMod(ModFile fileinfo, bool delArchive = true)
        {
            fileinfo.Arguments.Replace("BACKSLASH", @"\");

            if (fileinfo.Arguments == "") fileinfo.Arguments = "unzipToDir?";
            var args = fileinfo.Arguments.Split('?');

            ModInstallerCommon.DebugLog("");
            for (var i = 0; i < args.Length; i++) ModInstallerCommon.DebugLog(args[i] + ", ");

            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == "moveToFolder") MoveToFolder(args[i + 1], args[i + 2], args[i + 3]);
                if (args[i] == "unzipToDir")
                {
                    ModInstallerCommon.DebugLog("Unzipping to " + args[i + 1]);

                    var ArchiveType = Archives.ArchiveType.Zip;

                    if (fileinfo.RawName.EndsWith(".rar") || fileinfo.RawName.EndsWith(".RAR"))
                        ArchiveType = Archives.ArchiveType.RAR;

                    if (fileinfo.RawName.EndsWith(".7z") || fileinfo.RawName.EndsWith(".7Z"))
                        ArchiveType = Archives.ArchiveType.SevenZip;

                    Archives.UnArchive(fileinfo.RawName, Path.Combine(Utilities.GameDirectoryOrThrow, args[i + 1]), delArchive, ArchiveType);
                }

                if (args[i] == "addFolder")
                {
                    ModInstallerCommon.DebugLog("Creating Directory " + args[i + 1]);
                    Directory.CreateDirectory(Path.Combine(Utilities.GameDirectoryOrThrow, args[i + 1]));
                }

                if (args[i] == "break") break;
            }

            Console.WriteLine("Installed " + fileinfo.Name);
            return true;
        }

        /// <summary>
        ///     This function moves the mod (first parameter) to the second parameter location, and renames it to the third
        ///     parameter
        /// </summary>
        /// <param name="mod">The mod to be moved</param>
        /// <param name="dir">The Directory to be moved to</param>
        /// <param name="renameTo">What the file should be renamed to after</param>
        /// <returns>Boolean, true</returns>
        /// <remarks>
        ///     Honestly, this function needs a lot of work, its disgusting //TODO: fix this shit
        /// </remarks>
        public static bool MoveToFolder(string mod, string dir, string renameTo = "")
        {
            if (renameTo == "") renameTo = mod;
            dir = Path.Combine(Utilities.GameDirectoryOrThrow, dir);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            ModInstallerCommon.DebugLog("Moving " + Directory.GetCurrentDirectory() + @"\" + mod + " to dir " + dir + " as " + renameTo);
            var path = Path.Combine(Utilities.GameDirectoryOrThrow, mod);
            
            if (File.Exists(path))
            {
                ModInstallerCommon.DebugLog("Moving as file!");
                File.Move(path, dir + renameTo, true);
            }

            if (File.Exists(Directory.GetCurrentDirectory() + @"\" + mod))
            {
                ModInstallerCommon.DebugLog("Moving as file!");
                File.Move(Directory.GetCurrentDirectory() + @"\" + mod, dir + renameTo, true);
            }
            else if (Directory.Exists(path))
            {
                ModInstallerCommon.DebugLog("Moving as directory!");
                Directory.Move(path, dir + renameTo);
            }

            if (Directory.Exists(Directory.GetCurrentDirectory() + @"\" + mod))
            {
                ModInstallerCommon.DebugLog("Moving as directory!");
                Directory.Move(Directory.GetCurrentDirectory() + @"\" + mod, dir + renameTo);
            }
            else
            {
                Console.WriteLine("Cannot find file to move!");
            }

            return true;
        }
    }
}