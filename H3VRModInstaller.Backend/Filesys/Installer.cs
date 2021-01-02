using System;
using System.IO;
using System.IO.Compression;
using H3VRModInstaller.JSON;

namespace H3VRModInstaller.Filesys
{
	public class Installer
	{

		public static bool installMod(string[] fileinfo, bool delArchive = false)
		{
			fileinfo[2].Replace("BACKSLASH", @"\");

			if (fileinfo[2] == "")
			{
				fileinfo[2] = "unzipToDir?";
			}
			string[] args = fileinfo[2].Split('?');

			MICommon.DebugLog("");
			for (int i = 0; i < args.Length; i++)
			{
				MICommon.DebugLog(args[i] + ", ");
			}

			for (int i = 0; i < args.Length; i++)
			{
				if (args[i] == "moveToFolder")
				{
					moveToFolder(args[i + 1], args[i + 2], args[i + 3]);
				}
				if (args[i] == "unzipToDir")
				{
					MICommon.DebugLog("Unzipping to " + args[i + 1]);
					Zip.unzip(fileinfo[0], MICommon.MainFiledir + "/" + args[i + 1], delArchive);
				}
				if (args[i] == "addFolder")
				{
					MICommon.DebugLog("Creating Directory " + args[i + 1]);
					Directory.CreateDirectory(MICommon.MainFiledir + args[i + 1]);
				}
				if (args[i] == "break") break;
			}

			Console.WriteLine("Installed " + fileinfo[0]);
			return true;
		}
		public static bool moveToFolder(string mod, string dir, string renameTo = "")
		{
			if (renameTo == "") renameTo = mod;
			dir = MICommon.MainFiledir + @"\" + dir;
			if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
			MICommon.DebugLog("Moving " + Directory.GetCurrentDirectory() + @"\" + mod + " to dir " + dir + " as " + renameTo);
			if (File.Exists(MICommon.MainFiledir + @"\" + mod))
			{
				MICommon.DebugLog("Moving as file!");
				File.Move(MICommon.MainFiledir + @"\" + mod, dir + renameTo, true);
			}
			if (File.Exists(Directory.GetCurrentDirectory() + @"\" + mod))
			{
				MICommon.DebugLog("Moving as file!");
				File.Move(Directory.GetCurrentDirectory() + @"\" + mod, dir + renameTo, true);
			}
			else
			if (Directory.Exists(MICommon.MainFiledir + @"\" + mod))
			{
				MICommon.DebugLog("Moving as directory!");
				Directory.Move(MICommon.MainFiledir + @"\" + mod, dir + renameTo);
			}
			if (Directory.Exists(Directory.GetCurrentDirectory() + @"\" + mod))
			{
				MICommon.DebugLog("Moving as directory!");
				Directory.Move(Directory.GetCurrentDirectory() + @"\" + mod, dir + renameTo);
			}
			else Console.WriteLine("Cannot find file to move!");
			return true;
		}
	}
}
