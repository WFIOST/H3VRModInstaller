using System;
using System.IO;
using System.IO.Compression;
using H3VRModInstaller.JSON;

namespace H3VRModInstaller.Filesys
{
	public class Installer
	{
		//installs the mod, not sure what you expected.
		public static bool installMod(string[] fileinfo, bool delArchive = false)
		{
			//catches no args
			if (fileinfo[2] == "")
			{
				fileinfo[2] = "unzipToDir?";
			}
			string[] args = fileinfo[2].Split('?'); //spits args line by ?

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
					Zip.unzip(fileinfo[0], JsonModList.H3Vrdir + "/" + args[i + 1], delArchive);
				}
				if (args[i] == "addFolder")
				{
					if (MainClass.enableDebugging) Console.WriteLine("Creating Directory " + args[i + 1]);
					Directory.CreateDirectory(JsonModList.H3Vrdir + args[i + 1]);
				}
				if (args[i] == "break") break;
			}

			Console.WriteLine("Installed " + fileinfo[0]);
			return true;
		}

		public static bool moveToFolder(string mod, string dir, string renameTo = "")
		{
			if (renameTo == "") renameTo = mod;
			dir = JsonModList.H3Vrdir + @"\" + dir;
			if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
			if (MainClass.enableDebugging) Console.WriteLine("Moving " + Directory.GetCurrentDirectory() + @"\" + mod + " to dir " + dir + " as " + renameTo);
			
			//why is this code repeating four times over? BODGE!
			if (File.Exists(JsonModList.H3Vrdir + @"\" + mod)) //make sure the file exists
			{
				if (MainClass.enableDebugging) Console.WriteLine("Moving as file!");
				File.Move(JsonModList.H3Vrdir + @"\" + mod, dir + renameTo, true); //moves file
			}
			if (File.Exists(Directory.GetCurrentDirectory() + @"\" + mod))
			{
				if (MainClass.enableDebugging) Console.WriteLine("Moving as file!");
				File.Move(Directory.GetCurrentDirectory() + @"\" + mod, dir + renameTo, true); //i'm actually surprised this works. it really shouldn't.
			}
			else
			if (Directory.Exists(JsonModList.H3Vrdir + @"\" + mod))
			{
				if (MainClass.enableDebugging) Console.WriteLine("Moving as directory!");
				Directory.Move(JsonModList.H3Vrdir + @"\" + mod, dir + renameTo);
			}
			if (Directory.Exists(Directory.GetCurrentDirectory() + @"\" + mod))
			{
				if (MainClass.enableDebugging) Console.WriteLine("Moving as directory!");
				Directory.Move(Directory.GetCurrentDirectory() + @"\" + mod, dir + renameTo);
			}
			else Console.WriteLine("Cannot find file to move!");
			return true;
		}
	}
}
