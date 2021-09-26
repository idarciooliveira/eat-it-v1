using Prism.Modularity;
using Prism.Regions;
using ConsularPedidosModule.Views;
using EAT.Infrastruture.WPF.Regions;

namespace ConsularPedidosModule
{
    public class ConsularPedidosModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ConsularPedidosModule(IRegionManager regionManager) => _regionManager = regionManager;

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(MyRegions.MainRegion, typeof(ConsultarPedidos));
        }
    }
}