using Prism.Modularity;
using Prism.Regions;
using ModificarPedidoItemModule.Views;
using ModificarPedido = ModificarPedidoItemModule.Views.ModificarPedido;
using EAT.Infrastruture.WPF.Regions;

namespace ModificarPedidoItemModule
{
    public class ModificarPedidoItemModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModificarPedidoItemModule(IRegionManager regionManager) => _regionManager = regionManager;

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(MyRegions.LeftRegion, typeof(ModificarPedido));
            _regionManager.RegisterViewWithRegion(MyRegions.RightRegion, typeof(ModificarItem));
        }
    }
}