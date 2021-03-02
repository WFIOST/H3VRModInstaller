using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace H3VRModInstaller.Avalonia
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            CanResize = false;

            ClientSize = new Size(968, 579);
            
            
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

           
        }
    }
}