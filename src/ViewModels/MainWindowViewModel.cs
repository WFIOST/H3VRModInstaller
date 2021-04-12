
using H3VRModInstaller.Avalonia;
using H3VRModInstaller.Models;
using H3VRModInstaller.Services;

namespace H3VRModInstaller.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public ModItem Selected { get; }
        public ModsListViewModel DownloadableModList { get; }
        public ModsListViewModel InstalledModList { get; }
        public ModInfoViewModel ModInfo { get; set; }
        public MainWindowViewModel(Database db)
        {
            ModInfo = new ModInfoViewModel();
            DownloadableModList = new ModsListViewModel(db.GetDownloadableItems(), ModInfo.SelectChanged);
            InstalledModList = new ModsListViewModel(db.GetInstalledMods(), ModInfo.SelectChanged);
        }
    }
}