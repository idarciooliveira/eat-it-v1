using EAT.Infrastruture.WPF.Regions;
using Prism.Modularity;
using Prism.Regions;
using LoginModule.Views;

namespace LoginModule
{
    public class LoginModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public LoginModule(IRegionManager regionManager) => _regionManager = regionManager;

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(MyRegions.MainRegion, typeof(Login));
        }
    }
}