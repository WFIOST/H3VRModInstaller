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

			if (MainClass.enableDebugging) Console.WriteLine("");
			for (int i = 0; i < args.Length; i++)
			{
				if (MainClass.enableDebugging) Console.Write(args[i] + ", ");
			}

			for (int i = 0; i < args.Length; i++)
			{
				if (args[i] == "moveToFolder")
				{
					moveToFolder(args[i + 1], args[i + 2], args[i + 3]);
				}
				if (args[i] == "unzipToDir")
				{
					if (MainClass.enableDebugging) Console.WriteLine("Unzipping to " + args[i + 1]);
					Zip.unzip(fileinfo[0], JSONModList.h3vrdir + "/" + args[i + 1], delArchive);
				}
				if (args[i] == "addFolder")
				{
					if (MainClass.enableDebugging) Console.WriteLine("Creating Directory " + args[i + 1]);
					Directory.CreateDirectory(JSONModList.h3vrdir + args[i + 1]);
				}
				if (args[i] == "break") break;
			}

			Console.WriteLine("Installed " + fileinfo[0]);
			return true;
		}
		public static bool moveToFolder(string mod, string dir, string renameTo = "")
		{
			if (renameTo == "") renameTo = mod;
			dir = JSONModList.h3vrdir + @"\" + dir;
			if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
			if (MainClass.enableDebugging) Console.WriteLine("Moving " + mod + " to dir " + dir + " as " + renameTo);
			if(File.Exists(Directory.GetCurrentDirectory() + @"\" + mod))
			{
				File.Move(Directory.GetCurrentDirectory() + @"\" + mod, dir + renameTo, true);
			}
			if(Directory.Exists(Directory.GetCurrentDirectory() + @"\" + mod))
			{
				Directory.Move(Directory.GetCurrentDirectory() + @"\" + mod, dir + renameTo);
			}
			return true;
		}
	}
}
