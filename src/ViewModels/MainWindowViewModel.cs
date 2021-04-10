
using H3VRModInstaller.Avalonia;
using H3VRModInstaller.Models;
using H3VRModInstaller.Services;

namespace H3VRModInstaller.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private ModItem _selected;
        public MainWindowViewModel(Database db)
        {
            ModInfo = new ModInfoViewModel();
            List = new ModsListViewModel(db.GetItems(), ModInfo.SelectChanged);
        }

        public ModsListViewModel List { get; }
        public ModInfoViewModel ModInfo { get; set; }
    }
}