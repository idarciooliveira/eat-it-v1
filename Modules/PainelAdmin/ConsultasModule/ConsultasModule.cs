using Prism.Modularity;
using Prism.Regions;
using ConsultasModule.Views;
using EAT.Infrastruture.WPF.Regions;

namespace ConsultasModule
{
    public class ConsultasModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ConsultasModule(IRegionManager regionManager) => _regionManager = regionManager;

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(MyRegions.MainRegion, typeof(ConsultarPedidosAdmin));
        }
    }
}