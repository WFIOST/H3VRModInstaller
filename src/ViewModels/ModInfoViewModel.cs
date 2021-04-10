using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Avalonia.Threading;
using H3VRModInstaller.Avalonia;
using H3VRModInstaller.Models;
using ReactiveUI;

namespace H3VRModInstaller.ViewModels
{
    public class ModInfoViewModel : ViewModelBase
    {
        public ModInfoViewModel()
        {
            SelectedMod = new ModItem(){ Name = "Test"};
            
            SendToWebsiteCommand = ReactiveCommand.Create(SendToWebsite);
            InstallCommand = ReactiveCommand.Create(Install);
            UpdateCommand = ReactiveCommand.Create(Update);
        }

        private ModItem _selectedMod;

        public ModItem SelectedMod
        {
            get => _selectedMod;
            set => this.RaiseAndSetIfChanged(ref _selectedMod, value);
        }
        
        public ReactiveCommand<Unit, Unit> SendToWebsiteCommand { get; }
        public ReactiveCommand<Unit, Unit> InstallCommand { get; }
        public ReactiveCommand<Unit, Unit> UpdateCommand { get; }

        public void SelectChanged(ModItem selecetd)
        {
            SelectedMod = selecetd;
        }

        public void SendToWebsite()
        {
            throw new System.NotImplementedException();
        }
        
        private void Update()
        {
            throw new System.NotImplementedException();
        }

        private void Install()
        {
            throw new System.NotImplementedException();
        }
    }
}