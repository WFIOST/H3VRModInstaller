using H3VRModInstaller.Common;

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

    }
}