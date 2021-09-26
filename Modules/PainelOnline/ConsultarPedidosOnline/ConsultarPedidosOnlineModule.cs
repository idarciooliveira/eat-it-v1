using Prism.Modularity;
using Prism.Regions;

namespace ConsultarPedidosOnline
{
    public class ConsultarPedidosOnlineModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ConsultarPedidosOnlineModule(IRegionManager regionManager) => _regionManager = regionManager;

        public void Initialize() { }
    }
}