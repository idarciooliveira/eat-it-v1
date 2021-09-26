using EAT.Infrastruture.WPF.Extensions;
using EAT.Infrastruture.WPF.Models;
using EAT.Infrastruture.WPF.Regions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace MenuModule.ViewModels
{
    public class MenuViewModel : BindableBase
    {
        public DelegateCommand<string> NavigateCommand { get; set; }
        public DelegateCommand CloseCommand { get; set; }
        private readonly IRegionManager _regionManager;

        public MenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(viewName =>
            {
                _regionManager.RequestNavigate(MyRegions.MainRegion,viewName);
            });
            CloseCommand = new DelegateCommand(OnClose);
        }

        public void OnClose()
        {
            RegionsExtensions.RemoverViews(_regionManager);
            RegionsExtensions.Navegar(_regionManager, MyRegions.MainRegion, ViewName.Login);
        }

    }
}
