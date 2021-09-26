using Prism.Modularity;
using Prism.Regions;
using FuncionarioModule.Views;
using EAT.Infrastruture.WPF.Regions;

namespace FuncionarioModule
{
    public class FuncionarioModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public FuncionarioModule(IRegionManager regionManager) => _regionManager = regionManager;

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(MyRegions.MainRegion, typeof(Funcionarios));
        }
    }
}