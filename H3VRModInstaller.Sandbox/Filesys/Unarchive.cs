using System.Linq;
using SharpCompress.Archives;
using SharpCompress.Archives.GZip;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;

namespace H3VRModInstaller.Sandbox.Archives
{
    public class Decompression
    {
        public static void UnZip(string FileToDecompress, string LocationToDecompressTo)
        {
            using (var archive = ZipArchive.Open(FileToDecompress))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    entry.WriteToDirectory(LocationToDecompressTo, new ExtractionOptions
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
            }
        }

        public static void UnSevenZip(string FileToDecompress, string LocationToDecompressTo)
        {
            using (var archive = SevenZipArchive.Open(FileToDecompress))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    entry.WriteToDirectory(LocationToDecompressTo, new ExtractionOptions
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
            }
        }

        public static void UnRar(string FileToDecompress, string LocationToDecompressTo)
        {
            using (var archive = RarArchive.Open(FileToDecompress))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    entry.WriteToDirectory(LocationToDecompressTo, new ExtractionOptions
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
            }
        }

        public static void UnGZip(string FileToDecompress, string LocationToDecompressTo)
        {
            using (var archive = GZipArchive.Open(FileToDecompress))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    entry.WriteToDirectory(LocationToDecompressTo, new ExtractionOptions
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
            }
        }
    }
}