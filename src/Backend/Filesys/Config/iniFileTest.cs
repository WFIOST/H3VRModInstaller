using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace H3VRModInstaller.Filesys.Config
{
    public class MIConfig
    {
        #region thanks stackoverflow
        private readonly string EXE = Assembly.GetExecutingAssembly().GetName().Name;
        private readonly string Path;
        public MIConfig(string IniPath = null) => Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }
        public void Write(string Key, string Value, string Section = null) => WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        public void DeleteKey(string Key, string Section = null) => Write(Key, null, Section ?? EXE);
        public void DeleteSection(string Section = null) => Write(null, null, Section ?? EXE);
        public bool KeyExists(string Key, string Section = null) { return Read(Key, Section).Length > 0; }
        
        #endregion
        
        public class SettingsFile
        {
            public bool RemoveConfigOnDeletion { get; set; }
            
            public bool DeleteArchivesOnInstallFinish { get; set; }
            
            public string H3VRPath { get; set; }
            
            public string OverridePath { get; set; }

            public SettingsFile()
            {
                
            }
        }
    }
    
}