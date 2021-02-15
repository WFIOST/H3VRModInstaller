using System;
using System.IO;
using System.Windows.Forms;
using H3VRModInstaller.Common;
using Newtonsoft.Json;

namespace H3VRModInstaller.Filesys.Deli
{
    public static class CheckDelicounter
    {
        public static bool Check()
        {
            if (File.Exists(Utilities.ModCache))
            {
                try
                {
                    var fileContents = JsonConvert.DeserializeObject<deliJSON>(Utilities.ModCache);
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class deliJSON
    {
        public string Guid { get; set; }
        
        public string VersionString { get; set; }
    }
}