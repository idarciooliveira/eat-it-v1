using Prism.Modularity;
using Prism.Regions;
using PedidoSolicitados.Views;
using EAT.Infrastruture.WPF.Regions;

namespace PedidoSolicitados
{
    public class PedidoSolicitadosModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public PedidoSolicitadosModule(IRegionManager regionManager) => _regionManager = regionManager;

        public void Initialize() { }
    }
}