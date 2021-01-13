using System;
using System.Linq;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;

namespace H3VRModInstaller.Sandbox.Archives
{
    public class Decompression
    {
        public static void UnRar(string FileToDecompress, string LocationToDecompressTo = "")
        {
            if (String.IsNullOrEmpty(LocationToDecompressTo))
                LocationToDecompressTo = FileToDecompress;
            var loc = LocationToDecompressTo.Split(".rar");
            
            Console.WriteLine(loc[0]);
            Console.ReadKey();
            
            using (var archive = RarArchive.Open(FileToDecompress))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                {
                    entry.WriteToDirectory(loc[0], new ExtractionOptions()
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                }
            }
        }
    }
}