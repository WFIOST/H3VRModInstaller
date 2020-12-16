using System.IO;

namespace H3VRModInstaller.Filesys.Common
{
    public class Directories
    {
        public static string h3vrDir = Directory.GetCurrentDirectory() + "/";
        public static string bepinexDir = Directory.GetCurrentDirectory() + "/" + "BepInEx/";
        public static string pluginsDir = Directory.GetCurrentDirectory() + "/" + "BepInEx/" + "Plugins/";
        public static string modsDirs = Directory.GetCurrentDirectory() + "/" + "mods/";
    }
}