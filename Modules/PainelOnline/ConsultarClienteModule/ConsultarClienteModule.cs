using Prism.Modularity;
using Prism.Regions;
using ConsultarClienteModule.Views;
using EAT.Infrastruture.WPF.Regions;

namespace ConsultarClienteModule
{
    public class ConsultarClienteModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ConsultarClienteModule(IRegionManager regionManager) => _regionManager = regionManager;

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(MyRegions.LeftRegion, typeof(ClientesRegistrados));
            _regionManager.RegisterViewWithRegion(MyRegions.RightRegion, typeof(PedidosDoCliente));

        }
    }
}