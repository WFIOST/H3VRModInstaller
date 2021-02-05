namespace H3VRModInstaller.Common
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