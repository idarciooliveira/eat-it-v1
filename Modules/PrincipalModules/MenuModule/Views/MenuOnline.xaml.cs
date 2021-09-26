using MenuModule.ViewModels;
using Prism.Regions;

namespace MenuModule.Views
{
    /// <summary>
    /// Interação lógica para MenuOnline.xam
    /// </summary>
    public partial class MenuOnline 
    {
        public MenuOnline(IRegionManager regionManager)
        {
            InitializeComponent();
            DataContext = new MenuViewModel(regionManager);
        }
    }
}
