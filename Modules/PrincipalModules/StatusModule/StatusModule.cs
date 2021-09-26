using EAT.Infrastruture.WPF.Regions;
using Prism.Modularity;
using Prism.Regions;
using StatusModule.Views;

namespace StatusModule
{
    public class StatusModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public StatusModule(IRegionManager regionManager) => _regionManager = regionManager;

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(MyRegions.StatusRegion, typeof(Statusbar));
        }
    }
}