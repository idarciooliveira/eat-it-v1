using EAT.Infrastruture.WPF.Regions;
using Prism.Modularity;
using Prism.Regions;
using ProdutoModule.Views;

namespace ProdutoModule
{
    public class ProdutoModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ProdutoModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(MyRegions.MainRegion, typeof(Produtos));
        }
    }
}