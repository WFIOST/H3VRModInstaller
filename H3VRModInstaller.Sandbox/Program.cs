//Sandbox project, test and do whatever the fuck you want

using System;
using System.IO;
using H3VRModInstaller.Sandbox.Archives;

namespace H3VRModInstaller.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Current Dir: {0}", Directory.GetCurrentDirectory());
            Decompression.UnRar(Directory.GetCurrentDirectory() + "/test.rar");
        }
    }
}