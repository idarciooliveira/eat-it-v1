using CategoriaModule.Views;
using EAT.Infrastruture.WPF.Regions;
using Prism.Modularity;
using Prism.Regions;

namespace CategoriaModule
{
    public class CategoriaModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public CategoriaModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(MyRegions.MainRegion, typeof(Categorias));
        }
    }
}