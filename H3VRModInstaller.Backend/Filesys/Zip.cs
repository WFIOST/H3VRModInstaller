using System.IO;
using System;
using System.IO.Compression;

namespace H3VRModInstaller.Backend.Filesys
{
    public class Zip
    {

        public bool unzip(string fileToUnzip, string unzipLocation, bool deleteArchiveAfterUnzip)
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