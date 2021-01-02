using System;
using System.IO;
using System.IO.Compression;
using H3VRModInstaller.Common;
using H3VRModInstaller.JSON;

namespace H3VRModInstaller.Filesys
{
	/// <summary>
	/// This class manages the installation of mods!
	/// </summary>
	public class Installer
	{

		/// <summary>
		/// This function installs a mod based off the parameters provided. The first parameter is the an 5-length array which represents the file info. The second parameter is a bool which determines if the archive will be deleted after installation.
		/// </summary>
		/// <param name="File Info"></param>
		/// <param name="Delete Archive"></param>
		/// <returns>Boolean</returns>
		public static bool installMod(ModFile fileinfo, bool delArchive = false)
		{
			fileinfo.Arguments.Replace("BACKSLASH", @"\");

			if (fileinfo.Arguments == "")
			{
				fileinfo.Arguments = "unzipToDir?";
			}
			string[] args = fileinfo.Arguments.Split('?');

			ModInstallerCommon.DebugLog("");
			for (int i = 0; i < args.Length; i++)
			{
				ModInstallerCommon.DebugLog(args[i] + ", ");
			}

			for (int i = 0; i < args.Length; i++)
			{
				if (args[i] == "moveToFolder")
				{
					moveToFolder(args[i + 1], args[i + 2], args[i + 3]);
				}
				if (args[i] == "unzipToDir")
				{
					ModInstallerCommon.DebugLog("Unzipping to " + args[i + 1]);
					Zip.unzip(fileinfo.RawName, ModInstallerCommon.MainFiledir + "/" + args[i + 1], delArchive);
				}
				if (args[i] == "addFolder")
				{
					ModInstallerCommon.DebugLog("Creating Directory " + args[i + 1]);
					Directory.CreateDirectory(ModInstallerCommon.MainFiledir + args[i + 1]);
				}
				if (args[i] == "break") break;
			}

			Console.WriteLine("Installed " + fileinfo.Name);
			return true;
		}
		/// <summary>
		/// This function moves the mod (first parameter) to the second parameter location, and renames it to the third parameter
		/// </summary>
		/// <param name="Mod to Move"></param>
		/// <param name="Directory to move to"></param>
		/// <param name="String to rename to"></param>
		/// <returns></returns>
		public static bool moveToFolder(string mod, string dir, string renameTo = "")
		{
			if (renameTo == "") renameTo = mod;
			dir = ModInstallerCommon.MainFiledir + @"\" + dir;
			if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
			ModInstallerCommon.DebugLog("Moving " + Directory.GetCurrentDirectory() + @"\" + mod + " to dir " + dir + " as " + renameTo);
			if (File.Exists(ModInstallerCommon.MainFiledir + @"\" + mod))
			{
				ModInstallerCommon.DebugLog("Moving as file!");
				File.Move(ModInstallerCommon.MainFiledir + @"\" + mod, dir + renameTo, true);
			}
			if (File.Exists(Directory.GetCurrentDirectory() + @"\" + mod))
			{
				ModInstallerCommon.DebugLog("Moving as file!");
				File.Move(Directory.GetCurrentDirectory() + @"\" + mod, dir + renameTo, true);
			}
			else
			if (Directory.Exists(ModInstallerCommon.MainFiledir + @"\" + mod))
			{
				ModInstallerCommon.DebugLog("Moving as directory!");
				Directory.Move(ModInstallerCommon.MainFiledir + @"\" + mod, dir + renameTo);
			}
			if (Directory.Exists(Directory.GetCurrentDirectory() + @"\" + mod))
			{
				ModInstallerCommon.DebugLog("Moving as directory!");
				Directory.Move(Directory.GetCurrentDirectory() + @"\" + mod, dir + renameTo);
			}
			else Console.WriteLine("Cannot find file to move!");
			return true;
		}
	}
}
