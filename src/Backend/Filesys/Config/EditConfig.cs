using System.Collections.Generic;
using System.IO;
using H3VRModInstaller.Backend.Common;
using H3VRModInstaller.GUI;

namespace H3VRModInstaller.Backend.Filesys.Config
{
    /// <summary>
    ///     This class edits the config file of a .cfg file!
    /// </summary>
    public class Configs
    {
        /// <summary>
        ///     Gets all the info in a <c>config</c> file, then gets all the editable fields, and edits them to have the correct
        ///     info
        /// </summary>
        /// <param name="fileToEdit">The file to be edited</param>
        /// <param name="fieldToEdit">Which field in the file is going to be edited (REGEX)</param>
        /// <param name="textToAdd">What to add to the file</param>
        public static void EditConfigFile(string fileToEdit, string fieldToEdit, string textToAdd)
        {
        }


        /// <summary>
        ///     Get Config Fields
        /// </summary>
        private static string[] GetConfigFields()
        {
            var Fields = new List<string>();

            var ConfigFiles = Directory.GetFiles(Path.Combine(Utilities.GameDirectoryOrThrow, "BepInEx", "config"));

            var lines = new string[0];

            foreach (var file in ConfigFiles) lines = File.ReadAllLines(file);

            File.WriteAllLines("", lines);

            return Fields.ToArray();
        }
    }
}


/*
            /// <summary>
            ///     BepInEx, possible inputs: None, Info, IL, Warn, Error, Debug, All
            /// </summary>
            LogChannel,

            /// <summary>
            ///     BepInEx, possible inputs: Auto, ConsoleOut, StandardOut
            /// </summary>
            ConsoleOutRedirectType,

            /// <summary>
            ///     BepInEx, possible inputs: None, Fatal, Error, Warning, Message, Info, Debug, All
            /// </summary>
            LogLevel
*/