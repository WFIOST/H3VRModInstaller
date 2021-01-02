using System.IO;
using System;
using System.IO.Compression;

namespace H3VRModInstaller.Filesys
{
    /// <summary>
    /// Class which manages unzipping
    /// </summary>
    public class Zip
    {

        /// <summary>
        /// This bool unzips the compressed mod and moves it into the correct location
        /// </summary>
        /// <param name="File to Unzip"></param>
        /// <param name="Unzip Location"></param>
        /// <param name="Delete Archive after Unzip?"></param>
        /// <returns>Returns True</returns>
        public static bool unzip(string fileToUnzip, string unzipLocation, bool deleteArchiveAfterUnzip)
        {
            //why do I even have this?
            Console.WriteLine("Unzipping " + fileToUnzip);
            ZipFile.ExtractToDirectory(fileToUnzip, unzipLocation, true);
				if (deleteArchiveAfterUnzip)
					Console.WriteLine("Cleaning up");
            File.Delete(fileToUnzip);
            return true;
        }
    }
}