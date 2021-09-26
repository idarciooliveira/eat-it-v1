using Prism.Modularity;
using Prism.Regions;
using System;

namespace MenuOnline
{
    public class MenuOnlineModule : IModule
    {
        IRegionManager _regionManager;

        public MenuOnlineModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}