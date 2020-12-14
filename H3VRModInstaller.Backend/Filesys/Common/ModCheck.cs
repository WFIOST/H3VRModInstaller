using System.Collections.Generic;
using System.IO;
using H3VRModInstaller.Common;

namespace H3VRModInstaller.Filesys.Common
{
    public class ModCheck
    {

        public bool CheckBepInEx()
        {
            if (Directory.Exists(Directories.bepinexDir))
            {
                return true; 
            }
            else
            {
                return false;
            }
        }
        public bool CheckSideloader()
        {
            if (File.Exists(Directories.pluginsDir + "H3VR.Sideloader.dll") )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool CheckDeli()
        {
            if (File.Exists(Directories.pluginsDir + "Deli/Deli.Runtime.dll") )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckTNHTweaker()
        {
            if (File.Exists(Directories.pluginsDir + "TakeAndHoldTweaker.dll") )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckWurstMod()
        {
            if (File.Exists(Directories.modsDirs + "WurstMod.deli") )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckCursedDlls()
        {
            if (Directory.Exists(Directories.pluginsDir + "CursedDlls") )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckLSIIC()
        {
            if (Directory.Exists(Directories.pluginsDir + "LSIIC") )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<string> CheckMods(List<string> installedMods)
        {
            if (CheckDeli())
            {
                installedMods.Add("Deli");
            }

            if (CheckSideloader())
            {
                installedMods.Add("Sideloader");
            }

            if (CheckCursedDlls())
            {
                installedMods.Add("Cursed DLLs");
            }

            if (CheckWurstMod())
            {
                installedMods.Add("Wurst Mod");
                
            }

            if (CheckBepInEx())
            {
                installedMods.Add("BepInEx");
                
            }

            if (CheckTNHTweaker())
            {
                installedMods.Add("TNH Tweaker");
                
            }

            if (CheckLSIIC())
            {
                installedMods.Add("LSIIC");
                
            }

            return installedMods;
        }
    }
}