using H3VRModInstaller.Backend.Common;

namespace H3VRModInstaller.Backend.GUI
{
    /// <summary>
    ///     Common fields for the GUI
    /// </summary>
    public static class GuiCommon
    {
        /// <summary>
        ///     lmao it made me xml comment this
        /// </summary>
        public const string SelectedModText = "Selected Mod: ";

        /// <summary>
        ///     File stuff, but for the GUI
        /// </summary>
        public struct Files
        {
            /// <summary>
            ///     H3VR EXE path, but for the GUI because for some reason using the one from Backend breaks it
            /// </summary>
            public static readonly string ExecutablePath = ModInstallerCommon.Files.MainFiledir + @"\h3vr.exe";

            /// <summary>
            ///     Enabled name of the file which enables mods
            /// </summary>
            public const string EnabledName = @"/winhttp.dll";

            /// <summary>
            ///     Disabled name of the file which enables mods
            /// </summary>
            public const string DisabledName = @"/WinHTTP.dll.DISABLED";
        }
    }
}