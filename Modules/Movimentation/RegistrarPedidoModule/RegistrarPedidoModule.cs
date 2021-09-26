using EAT.Infrastruture.WPF.Regions;
using Prism.Modularity;
using Prism.Regions;
using RegistrarPedidoModule.Views;

namespace RegistrarPedidoModule
{
    public class RegistrarPedidoModule : IModule
    {
        private readonly IRegionManager _regionManager;
        
        public RegistrarPedidoModule(IRegionManager regionManager) => _regionManager = regionManager;

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(MyRegions.MainRegion, typeof(RegistrarPedido));
        }
    }
}