using H3VRModInstaller.Common;
using H3VRModInstaller.JSON.Common;

namespace H3VRModInstaller.GUI
{
    /// <summary>
    ///     Common fields for the GUI
    /// </summary>
    public class GUICommon
    {
        /// <summary>
        /// lmao it made me xml comment this
        /// </summary>
        public string SelectedModText = "Selected Mod: ";
        /// <summary>
        /// File stuff, but for the GUI
        /// </summary>
        public struct Files
        {
            /// <summary>
            /// H3VR EXE path, but for the GUI because for some reason using the one from Backend breaks it
            /// </summary>
            public static string EXEPath = ModInstallerCommon.Files.MainFiledir + @"\h3vr.exe";
            /// <summary>
            /// Enabled name of the file which enables mods
            /// </summary>
            public static string EnabledName = @"/winhttp.dll";
            /// <summary>
            /// Disabled name of the file which enables mods
            /// </summary>
            public static string DisabledName = @"/WinHTTP.dll.DISABLED";
        }


    }
}