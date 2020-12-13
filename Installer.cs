using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.NetworkInformation;

namespace H3VRModInstaller
{
	internal class Installer
	{
		public bool unzip(string fileToUnzip, string unzipLocation, bool deleteArchiveAfterUnzip)
		{
			//why do I even have this?
			Console.WriteLine("Unzipping " + fileToUnzip);
			ZipFile.ExtractToDirectory(fileToUnzip, unzipLocation);
			if (deleteArchiveAfterUnzip)
				Console.WriteLine("Cleaning up");
			File.Delete(fileToUnzip);
			return true;
		}



		public bool installDeliMod(string deliMod, string modsDir = "Mods/")
		{
			if (!Directory.Exists(modsDir))
				Directory.CreateDirectory(modsDir);
			File.Move(deliMod, modsDir + deliMod);
			return true;
		}
	}

	internal class InstallMods
	{
		private static readonly Installer installer = new();

		public bool installBepInEx()
		{
			installer.unzip("BepInEx_x64_5.4.4.0.zip", Directory.GetCurrentDirectory() + "/", false);
			Console.WriteLine("Installed BepInEx!");
			return true;
		}

		public bool installWurstMod()
		{
			installer.unzip("Deli-v0.2.5.zip", Directory.GetCurrentDirectory(), true);
			Console.WriteLine("Installed Deli!");

			installer.installDeliMod("WurstMod.deli");
			Console.WriteLine("Installed WurstMod!");
			return true;
		}

		public bool installCurseddlls()
		{
			installer.unzip("BepInEx.MonoMod.Loader_1.0.0.0.zip", Directory.GetCurrentDirectory() + "/", true);
			Console.WriteLine("Installed Monomod!");
			installer.unzip("CursedDlls.BepInEx_v1.3.zip", Directory.GetCurrentDirectory() + "/", true);
			Console.WriteLine("Installed Cursed.Dlls!");
			return true;
		}

		public bool installTNHTweaker()
		{
			func.moveFileToPlugins("/TakeAndHoldTweaker.dll");
			Console.WriteLine("Installed TNH Tweaker!");
			return true;
		}

		public bool installAll()
		{
			Console.WriteLine("Installing WurstMod!");
			installWurstMod();
			Console.WriteLine("Installing Cursed Dlls!");
			installCurseddlls();
			Console.WriteLine("Installing TNH Tweaker!");
			installTNHTweaker();

			Console.WriteLine("Successfully installed ALL mods!");
			return true;
		}
	}
}
