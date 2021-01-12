using System.IO;

namespace H3VRModInstaller.Filesys.Config
{
    /// <summary>
    ///     This class edits the config file of a .cfg file!
    /// </summary>
    public class Configs
    {
        /// <summary>
        ///     Defines what type of edit is to be carried out in the file
        /// </summary>
        public enum TypeOfEdit
        {
            /// <summary>
            ///     Boolean
            /// </summary>
            Bool,

            /// <summary>
            ///     String
            /// </summary>
            String,

            /// <summary>
            ///     BepInEx, possible inputs: //TODO: add possible inputs (LogChannel)
            /// </summary>
            LogChannel,

            /// <summary>
            ///     BepInEx, possible inputs: //TODO: add possible inputs (ConsoleOutRedirectType)
            /// </summary>
            ConsoleOutRedirectType,

            /// <summary>
            ///     BepInEx, possible inputs: //TODO: add possible inputs (LogLevel)
            /// </summary>
            LogLevel
        }

        /// <summary>
        ///     Gets all the info in a <c>config</c> file, then gets all the editable fields, and edits them to have the correct
        ///     info
        /// </summary>
        /// <param name="fileToEdit">The file to be edited</param>
        /// <param name="fieldToEdit">Which field in the file is going to be edited (REGEX)</param>
        /// <param name="textToAdd">What to add to the file</param>
        /// <returns>
        ///     <c>true</c>
        /// </returns>
        public static bool EditConfigFile(string fileToEdit, string[] fieldToEdit, string[] textToAdd)
        {
            var fileContents = File.ReadAllLines(fileToEdit);

            for (var i = 0; i <= fileContents.Length; i++)
            {
                //string[] fields = reg
            }

            var finishedEditing = false;

            return true;
        }
    }
}