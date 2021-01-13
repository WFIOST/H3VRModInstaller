//Sandbox project, test and do whatever the fuck you want

using System;
using H3VRModInstaller.Sandbox.JSON;

namespace H3VRModInstaller.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var modfiles = OnlineDatabase.GetMods();
            for (int i = 0; i < modfiles.Length; i++)
            {
                Console.WriteLine("Raw Names: {0}", modfiles[i].RawName);
            }
            
            Console.ReadLine();
        }
    }
}