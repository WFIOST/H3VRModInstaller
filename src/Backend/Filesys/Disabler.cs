using System;
using System.IO;
using H3VRModInstaller.Common;
using H3VRModInstaller.JSON;


namespace H3VRModInstaller.Filesys 
{
    public class Disabler //written up by taters
    {
        public static void EnableDisableMod(string modid)
        {
            ModFile mf = ModParsing.GetSpecificMod(modid);
            string path = Path.Combine(Utilities.GameDirectory, mf.DelInfo.Split('?')[0]);
            Console.WriteLine("Detecting if {0} exists...", path);
            if (File.Exists(path) || Directory.Exists(path)) //if it is not disabled
                DisableMod(modid); //disable
            else EnableMod(modid); //else enable
        }
        
        public static void DisableMod(string modid)
        {
            ModFile mf = ModParsing.GetSpecificMod(modid); //get modfile
            string[] delinfos = mf.DelInfo.Split('?');
            for (int i = 0; i < delinfos.Length; i++)
            {
                Installer.MoveToFolder(Path.Combine(delinfos[i]), Utilities.DisableCache); //move to cache
            }
        }
        
        public static void EnableMod(string modid)
        {
            ModFile mf = ModParsing.GetSpecificMod(modid); //get modfile
            string[] delinfos = mf.DelInfo.Split('?');
            for (int i = 0; i < delinfos.Length; i++)
            {
                string delinfopath = Path.Combine(Utilities.GameDirectoryOrThrow + delinfos[i]);
                string delinfotrimmed =
                    new DirectoryInfo(delinfos[i]).Name; //get last part of file name (e.g VirtualObjects/asdf to asdf)
                string path =
                    Path.Combine(Utilities.DisableCache + delinfotrimmed); //get path to disabledmods cache file
                Installer.MoveToFolder(path, Directory.GetParent(delinfopath).ToString() + "/"); //move back to loc
            }
        }
    }
}