using System;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;

namespace H3VRModInstaller.Sandbox.Archives
{
    public class Archives
    {
        public static bool UnRar(string FileToUnzip, string LocationToUnzipTo)
        {
            using (Stream stream = File.OpenRead(FileToUnzip))
            using (var reader = ReaderFactory.Open(stream))
            {
                    while (reader.MoveToNextEntry())
                    {
                        if (!reader.Entry.IsDirectory)
                            {
                                Console.WriteLine(reader.Entry.Key);
                                reader.WriteEntryToDirectory(LocationToUnzipTo, new ExtractionOptions()
                                {
                                ExtractFullPath = true,
                                Overwrite = true
                                });
                            }
                    }
            }
        } 
    }
}