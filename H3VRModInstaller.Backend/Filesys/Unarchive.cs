using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SharpCompress.Common;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.Zip;
using SharpCompress.Archives.SevenZip;


namespace H3VRModInstaller.Filesys
{
    /// <summary>
    ///     Class which manages unzipping
    /// </summary>
    public class Archives
    {
        /// <summary>
        /// What type of archive the file is
        /// </summary>
        public enum ArchiveType
        {
            /// <summary>
            /// Regular old zip Archive
            /// </summary>
            Zip,
            /// <summary>
            /// .RAR Archive
            /// </summary>
            RAR,
            /// <summary>
            /// .7z Archive
            /// </summary>
            SevenZip
        }

        /// <summary>
        ///     This bool unzips the compressed mod and moves it into the correct location
        /// </summary>
        /// <param name="fileToUnzip">File to Unzip</param>
        /// <param name="unzipLocation">Unzip location</param>
        /// <param name="deleteArchiveAfterUnzip">Delete archive after unzip?</param>
        /// <param name="TypeOfArchive">What type of archive the file is, acceptable values are "Zip", "SevenZip", "RAR"</param>
        public static void UnArchive(string fileToUnzip, string unzipLocation, bool deleteArchiveAfterUnzip, ArchiveType TypeOfArchive)
        {
            switch (TypeOfArchive)
            {
                case ArchiveType.Zip:
                    UnZip(fileToUnzip, unzipLocation);
                    break;

                case ArchiveType.RAR:
                    UnRar(fileToUnzip, unzipLocation);
                    break;

                case ArchiveType.SevenZip:
                    UnSevenZip(fileToUnzip, unzipLocation);
                    break;
                
                default:
                break;
            }
        }



        /// <summary>
        /// Function for unarchiving .zip files
        /// </summary>
        /// <param name="FileToDecompress">Archive that is to be opened</param>
        /// <param name="LocationToDecompressTo">Directory that the archive would be extracted to</param>
        public static void UnZip(string FileToDecompress, string LocationToDecompressTo)
        {
            using (var archive = ZipArchive.Open(FileToDecompress))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                {
                    entry.WriteToDirectory(LocationToDecompressTo, new ExtractionOptions()
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                } 
            }
        }

        /// <summary>
        /// Function for unarchiving .7z files
        /// </summary>
        /// <param name="FileToDecompress">Archive that is to be opened</param>
        /// <param name="LocationToDecompressTo">Directory that the archive would be extracted to</param>
        public static void UnSevenZip(string FileToDecompress, string LocationToDecompressTo)
        {
            using (var archive = SevenZipArchive.Open(FileToDecompress))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                {
                    entry.WriteToDirectory(LocationToDecompressTo, new ExtractionOptions()
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                } 
            }
        }

        /// <summary>
        /// Function for unarchiving .rar files
        /// </summary>
        /// <param name="FileToDecompress">Archive that is to be opened</param>
        /// <param name="LocationToDecompressTo">Directory that the archive would be extracted to</param>
        public static void UnRar(string FileToDecompress, string LocationToDecompressTo)
        {
            using (var archive = RarArchive.Open(FileToDecompress))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                {
                    entry.WriteToDirectory(LocationToDecompressTo, new ExtractionOptions()
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                }
            }
        }
    }
}