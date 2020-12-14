using System;
using System.IO;
using System.IO.Compression;

namespace H3VRModInstaller.Filesys
{
	internal class InstallMods
	{
		private static readonly Zip installer = new();

		public bool installMod(string name, string[,] args, bool delArchive = false)
		{
			bool _parsed = false;
			for (int i = 0; i < args.GetLength(0); i++)
			{
				if (args[i, 1] == name)
				{
					if (args[i, 0] == "moveToFolder")
					{
						moveToFolder(args[i, 2], args[i, 3], args[i, 4]);
						if (args[i, 10] != "DoNotParse") _parsed = true;
					}
					if (args[i, 0] == "unzipToDir")
					{
						Console.WriteLine("Unzipping...");
						installer.unzip("download.zip", Directory.GetCurrentDirectory() + "/" + args[i, 2], delArchive);
						if (args[i, 10] != "DoNotParse") _parsed = true;
					}
					if (args[i, 0] == "addFolder")
					{
						Console.WriteLine("Creating Directory " + args[i, 2]);
						Directory.CreateDirectory(args[i, 2]);
						if (args[i, 10] != "DoNotParse") _parsed = true;
					}
					if (args[i, 0] == "break") break;
				}
			}

			if (_parsed != true) { installer.unzip("download.zip", Directory.GetCurrentDirectory() + "/", delArchive); Console.WriteLine("Unzipping..."); }

			Console.WriteLine("Installed " + name);
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
