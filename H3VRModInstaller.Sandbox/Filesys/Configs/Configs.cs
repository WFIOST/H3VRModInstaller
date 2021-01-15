using System;
using System.IO;
using System.Collections.Generic;
using H3VRModInstaller.Common;

namespace H3VRModInstaller.Sandbox.Filesys.Config
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
        public static void EditConfigFile(string fileToEdit = "", string fieldToEdit = "", string textToAdd = "")
        {
            var fields = GetConfigfields();
            return;
        }


        /// <summary>
        /// Get Config fields
        /// </summary>
        private static string[] GetConfigfields()
        {
            var fields = new string[0];
            if(!Directory.Exists(Directory.GetCurrentDirectory() + "/configs/")) Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/configs/");
            var ConfigsDir = Directory.GetCurrentDirectory() + "/configs/";
            var TestConfigFile = ConfigsDir + "test.h3vrMI";
            fields = File.ReadAllLines(TestConfigFile);

            var listOfFields = new List<string>(fields);
            
            

            return listOfFields.ToArray();
        }
    }
}