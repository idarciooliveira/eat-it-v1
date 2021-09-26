using System.Windows.Controls;
using MenuModule.ViewModels;
using Prism.Regions;

namespace MenuModule.Views
{
    /// <summary>
    /// Interação lógica para MenuAdmin.xam
    /// </summary>
    public partial class MenuAdmin 
    {
        public MenuAdmin(IRegionManager regionManager)
        {
            InitializeComponent();
            DataContext = new MenuViewModel(regionManager);
        }
    }
}
