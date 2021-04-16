using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using H3VRModInstaller.Models;
using H3VRModInstaller.ViewModels;

namespace H3VRModInstaller.Views
{
    public class ModsListView : UserControl
    {
        public ModsListView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void SelectingItemsControl_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            (DataContext as ModsListViewModel).SelectedChanged(e.AddedItems[0] as ModItem);
        }
    }
}