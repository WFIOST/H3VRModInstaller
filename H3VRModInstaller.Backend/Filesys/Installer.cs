using System;
using System.IO;
using System.IO.Compression;

namespace H3VRModInstaller.Filesys
{
	internal class InstallMods
	{
		private static readonly Zip installer = new();

		public bool installMod(string[] fileinfo, bool delArchive = false)
		{

			if (fileinfo[2] == "")
			{
				fileinfo[2] = "unzipToDir?";
			}
			string[] args = fileinfo[2].Split('?');

			Console.WriteLine("");
			for (int i = 0; i < args.Length; i++)
			{
				Console.Write(args[i] + ", ");
			}

			for (int i = 0; i < args.Length; i++)
			{
				if (args[i] == "moveToFolder")
				{
					moveToFolder(args[i + 1], args[i + 2], args[i + 3]);
				}
				if (args[i] == "unzipToDir")
				{
					Console.WriteLine("Unzipping to " + args[i + 1]);
					installer.unzip(fileinfo[0], Directory.GetCurrentDirectory() + "/" + args[i + 1], delArchive);
				}
				if (args[i] == "addFolder")
				{
					Console.WriteLine("Creating Directory " + args[i + 1]);
					Directory.CreateDirectory(args[i + 1]);
				}
				if (args[i] == "break") break;
			}

			Console.WriteLine("Installed " + fileinfo[0]);
			return true;
		}
		public static bool moveToFolder(string mod, string dir, string renameTo = "")
		{
			if (renameTo == "") renameTo = mod;
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);
			Console.WriteLine("Moving " + mod + " to dir " + dir + " as " + renameTo);
			File.Move(mod, dir + renameTo, true);
			return true;
		}
	}
}
