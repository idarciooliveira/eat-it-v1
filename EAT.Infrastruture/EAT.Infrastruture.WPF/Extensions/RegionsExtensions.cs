using Prism.Regions;

namespace EAT.Infrastruture.WPF.Extensions
{
    public static class RegionsExtensions
    {
        public static void RemoverViews(IRegionManager regionManager)
        {
            var regios = regionManager.Regions;
            foreach (var region in regios)
            {
                var views = region.Views;
                foreach (var view in views)
                {
                    region.Remove(view);
                }
            }
        }
        public static void Navegar(IRegionManager regionManager,
            string regionName, string viewname)
        {
            regionManager.RequestNavigate(regionName, viewname);
        }

        public static void Navegar(IRegionManager regionManager, string regionName,
            string viewname, NavigationParameters parameters)
        {
            regionManager.RequestNavigate(regionName, viewname, parameters);
        }
    }
}
