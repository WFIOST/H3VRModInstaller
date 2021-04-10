using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace H3VRModInstaller.Views
{
    public class ModInfoView : UserControl
    {
        public ModInfoView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}