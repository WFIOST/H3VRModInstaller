using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ModInstaller
{
    public class MainWindow2 : Window
    {
        public MainWindow2()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}