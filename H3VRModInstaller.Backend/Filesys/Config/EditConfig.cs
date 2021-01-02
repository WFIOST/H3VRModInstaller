using System.IO;
using System.Text.RegularExpressions;

namespace H3VRModInstaller.Filesys.Config
{
    /// <summary>
    /// This class edits the config file of a .cfg file!
    /// </summary>
    public class Configs
    {
        /// <summary>
        /// Defines what type of edit is to be carried out in the file
        /// </summary>
        public enum TypeOfEdit
        {
            /// <summary>
            /// Boolean
            /// </summary>
            Bool,
            /// <summary>
            /// String
            /// </summary>
            String, 
            /// <summary>
            /// BepInEx, possible inputs: //TODO: add possible inputs (LogChannel)
            /// </summary>
            LogChannel,
            /// <summary>
            /// BepInEx, possible inputs: //TODO: add possible inputs (ConsoleOutRedirectType)
            /// </summary>
            ConsoleOutRedirectType,
            /// <summary>
            /// BepInEx, possible inputs: //TODO: add possible inputs (LogLevel)
            /// </summary>
            LogLevel
        }
        /// <summary>
         /// Gets all the info in a <c>config</c> file, then gets all the editable fields, and edits them to have the correct info
         /// </summary>
         /// <param name="fileToEdit"></param>
         /// <param name="fieldToEdit"></param>
         /// <param name="textToAdd"></param>
         /// <returns><c>true</c></returns>
        public static bool EditConfigFile(string fileToEdit, string[] fieldToEdit, string[] textToAdd)
        {
            string[] fileContents = File.ReadAllLines(@fileToEdit);

            for (int i = 0; i <= fileContents.Length; i++)
            {
                //string[] fields = reg
            }
            
            bool finishedEditing = false;
            
            return true;
        }
    }
}