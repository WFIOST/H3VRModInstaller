using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;

namespace H3VRModInstaller.Filesys
{
    /// <summary>
    ///     Class which manages unzipping
    /// </summary>
    public class Zip
    {
        /// <summary>
        ///     This bool unzips the compressed mod and moves it into the correct location
        /// </summary>
        /// <param name="fileToUnzip">File to Unzip</param>
        /// <param name="unzipLocation">Unzip location</param>
        /// <param name="deleteArchiveAfterUnzip">Delete archive after unzip?</param>
        /// <returns>Boolean, true</returns>
        public static bool Unzip(string fileToUnzip, string unzipLocation, bool deleteArchiveAfterUnzip)
        {
            if (fileToUnzip.EndsWith(".RAR") || fileToUnzip.EndsWith(".rar")) UnRar(fileToUnzip, unzipLocation);

            Console.WriteLine("Unzipping " + fileToUnzip);
            ZipFile.ExtractToDirectory(fileToUnzip, unzipLocation, true);
            if (deleteArchiveAfterUnzip)
                Console.WriteLine("Cleaning up");
            File.Delete(fileToUnzip);
            return true;
        }

        
        
        /// <summary>
        /// [WIP] unrar function
        /// </summary>
        /// <param name="fileToUnzip">RAR file to unzip</param> <param name="LocationToUnzipTo">Location to unzip to</param>
        public static void UnRar(string fileToUnzip, string LocationToUnzipTo)
        {
            using var archive = RarArchive.Open(fileToUnzip);
            foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
            {
                entry.WriteToDirectory(LocationToUnzipTo, new ExtractionOptions()
                {
                    ExtractFullPath = true,
                    Overwrite = true
                });
            }
        }
    }
}