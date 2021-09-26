using Prism.Modularity;
using Prism.Regions;
using MenuModule.Views;
using EAT.Infrastruture.WPF.Regions;

namespace MenuModule
{
    public class MenuModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public MenuModule(IRegionManager regionManager) => _regionManager = regionManager;

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(MyRegions.MenuRegion, typeof(MenuAdmin));
        }
    }
}