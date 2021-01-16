//Sandbox project, test and do whatever the fuck you want

using System;
using System.IO;
using H3VRModInstaller.Sandbox.Filesys.Config;

namespace H3VRModInstaller.Sandbox
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Setup();

            Configs.EditConfigFile();
        }


        private static void SetupConsole()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Title = "H3VR Mod Installer Sandbox Environment";
        }


        private static void PrintInfo()
        {
            var cwd = Directory.GetCurrentDirectory();
            Console.WriteLine($"Current Dir: {cwd}");

            Console.WriteLine("Files in CWD: ");

            foreach (var file in Directory.GetFiles(cwd)) Console.WriteLine(file);
            foreach (var path in Directory.GetDirectories(cwd)) Console.WriteLine(path);
        }

        private static void cont()
        {
            Console.Write("Press ENTER to Continue");
            Console.ReadLine();
        }

        private static void Setup()
        {
            SetupConsole();
            PrintInfo();
            cont();
        }
    }
}