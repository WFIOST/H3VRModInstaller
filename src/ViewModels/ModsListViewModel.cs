using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using H3VRModInstaller.Avalonia;
using H3VRModInstaller.Models;

namespace H3VRModInstaller.ViewModels
{
    public class ModsListViewModel : ViewModelBase
    {
        public ModsListViewModel(IEnumerable<ModItem> items, Action<ModItem> callback)
        {
            Items = new ObservableCollection<ModItem>(items);
            _selectedCallback = callback;
        }

        private Action<ModItem> _selectedCallback;

        public ObservableCollection<ModItem> Items { get; }

        public void SelectedChanged(ModItem mod)
        {
            _selectedCallback(mod);
        }
    }
}