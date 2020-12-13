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
			for (int i = 0; i <= args.GetLength(0); i++)
			{
				if (args[i, 0] == "moveToFolder" && args[i, 1] == name) {
					moveToFolder(args[i, 2], args[i, 3], args[i, 4]);
					_parsed = true;
				}
				if (args[i, 0] == "unzipToDir" && args[i, 1] == name)
					{installer.unzip("download.zip", Directory.GetCurrentDirectory() + "/", delArchive);
					_parsed = true;
				}
				if (args[i, 0] == "break") break;
			}

			if (_parsed != true) installer.unzip("download.zip", Directory.GetCurrentDirectory() + "/", delArchive);

			Console.WriteLine("Installed " + name);
			return true;
		}
		public static bool moveToFolder(string mod, string dir, string renameTo = "")
		{
			if (renameTo == "") renameTo = mod;
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);
			Console.WriteLine("Moving " + mod + " to dir " + dir + " as " + renameTo);
			File.Move(mod, dir + renameTo);
			return true;
		}
	}
}
