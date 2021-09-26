using Prism.Modularity;
using Prism.Regions;
using ClienteModule.Views;
using EAT.Infrastruture.WPF.Regions;

namespace ClienteModule
{
    public class ClienteModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ClienteModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(MyRegions.MainRegion, typeof(Clientes));
        }
    }
}