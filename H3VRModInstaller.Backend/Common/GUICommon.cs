using H3VRModInstaller.Common;
using H3VRModInstaller.JSON;
using H3VRModInstaller.JSON.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3VRModInstaller.GUI
{
    /// <summary>
    /// Common fields for the GUI
    /// </summary>
    public class GUICommon
    {
        public struct Files
        {
            public static string EXEPath = ModInstallerCommon.Files.MainFiledir + @"\h3vr.exe";
            public static string EnabledName = @"/winhttp.dll";
            public static string DisabledName = @"/WinHTTP.dll.DISABLED";
        }


        public class ModListFile
        {
            public string Name { get; set; }
            public string Version { get; set; }
            public string[] Dependencies { get; set; }
        }
        
        public ModListFile[] MapModList(ModListFile[] output)
        {
            ModFile[] input = JsonCommon.GetAllMods();

            output = new ModListFile[JsonCommon.JsonFiles.Length];

            for (int i = 0; i <= JsonCommon.JsonFiles.Length; i++)
            {
                input[i].Name = output[i].Name;
                input[i].Version = output[i].Version;
                input[i].Dependencies = output[i].Dependencies;
            }

            return output;
        }

        public string SelectedModText = "Selected Mod: ";
    }
}