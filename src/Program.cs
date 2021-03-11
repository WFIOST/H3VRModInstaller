using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ModInstaller.Common;

namespace ModInstaller.Avalonia
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args) 
        { //Not using lambdas so we can fit code in the Main
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
            
            Console.WriteLine(ModInstallerCommon.Dictionaries.ModFileRegistry["pccg"].Name);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
    }
}