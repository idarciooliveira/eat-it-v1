using System.Windows;
using EAT.DAL.Interfaces;
using EAT.Infrastruture.WPF.Extensions;
using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Commands;
using Prism.Regions;
using EAT.Infrastruture.WPF.Regions;

namespace LoginModule.ViewModels
{
    public class LoginViewModel : LoginBase
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IRegionManager _regionManager;

        public LoginViewModel(IFuncionarioRepositorio funcionarioRepositorio,
            IRegionManager regionManager)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
            _regionManager = regionManager;
            Titulo = "Login do Sistema";
            Funcionario = new Funcionario();
            Funcionario.PropertyChanged += (sender, args) => EntrarCommand.RaiseCanExecuteChanged();
            EntrarCommand = new DelegateCommand(OnEntrar, PodeEntrar);
            CancelarCommand = new DelegateCommand(OnCancelar);
        }

        private static void OnCancelar() => Application.Current.MainWindow.Close();

        private void OnEntrar()
        {
            var funcionario = _funcionarioRepositorio.CheckFuncionarioLogin(Funcionario);
            if (funcionario == null)
                MessageBox.Show(Message.LoginError);
            else
                OnEntrarNoSistema(funcionario);
        }
        private void OnEntrarNoSistema(Funcionario funcionario)
        {        
            RegionsExtensions.RemoverViews(_regionManager);
            var parametros = new NavigationParameters
            {
                {nameof(Funcionario), funcionario}
            };
            if (funcionario.TipoDeUsuarioId == Previlegio.VendedorOffline)
            {
                RegionsExtensions.Navegar(_regionManager, MyRegions.MenuRegion, ViewName.Menu);
                RegionsExtensions.Navegar(_regionManager, MyRegions.StatusRegion,
                    ViewName.Statusbar, parametros);
                return;
            }
            if (funcionario.TipoDeUsuarioId == Previlegio.VendedorOnline)
            {
                RegionsExtensions.Navegar(_regionManager, MyRegions.MenuRegion, ViewName.MenuOnline);
                RegionsExtensions.Navegar(_regionManager, MyRegions.StatusRegion,
                    ViewName.Statusbar, parametros);
                return;
            }

            RegionsExtensions.Navegar(_regionManager, MyRegions.StatusRegion,
                ViewName.Statusbar, parametros);
            RegionsExtensions.Navegar(_regionManager, MyRegions.MenuRegion, ViewName.MenuAdmin);
        }
    }
}
