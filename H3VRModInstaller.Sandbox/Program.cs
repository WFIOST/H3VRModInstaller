//Sandbox project, test and do whatever the fuck you want

using System;
using System.IO;
using H3VRModInstaller.Sandbox.Filesys.Config;

namespace H3VRModInstaller.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Setup();

            Configs.EditConfigFile();
        }

















































































        static void SetupConsole()
        {
            
        Console.ForegroundColor=ConsoleColor.DarkGreen;
        Console.Title = "H3VR Mod Installer Sandbox Environment";

        }


        static void PrintInfo()
        {
            var cwd = Directory.GetCurrentDirectory();
            Console.WriteLine($"Current Dir: {cwd}");

            Console.WriteLine($"Files in CWD: ");

            foreach (var file in Directory.GetFiles(cwd))
            {
                Console.WriteLine(file);
            }
            foreach (var path in Directory.GetDirectories(cwd))
            {
                Console.WriteLine(path);
            }

            
        }

        static void cont()
        {
            Console.Write("Press ENTER to Continue");
            Console.ReadLine();
        }

        static void Setup()
        {
            SetupConsole();
            PrintInfo();
            cont();
        }
    }
}
