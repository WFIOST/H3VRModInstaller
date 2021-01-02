using System.IO;
using System.Text.RegularExpressions;

namespace H3VRModInstaller.Filesys.Config
{
    /// <summary>
    /// This class edits the config file of a .cfg file!
    /// </summary>
    public class Configs
    {
        public enum TypeOfEdit
        {
            Bool,
            String, 
            LogChannel,
            ConsoleOutRedirectType,
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