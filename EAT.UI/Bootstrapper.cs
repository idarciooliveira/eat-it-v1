using Microsoft.Practices.Unity;
using Prism.Unity;
using EAT.UI.Views;
using System.Windows;
using CategoriaModule.Views;
using ClienteModule.Views;
using ConsularPedidosModule.Views;
using ConsultarClienteModule.Views;
using ConsultarPedidosOnline;
using ConsultasModule.Views;
using EAT.DAL.Interfaces;
using EAT.DAL.Repository;
using EAT.Models.Entities;
using FuncionarioModule.Views;
using LoginModule.Views;
using MenuModule.Views;
using ModificarPedidoItemModule.Views;
using PedidoSolicitados;
using PedidoSolicitados.Views;
using Prism.Modularity;
using ProdutoModule.Views;
using RegistrarPedidoModule.Views;
using StatusModule.Views;

namespace EAT.UI
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell() => Container.Resolve<MainWindow>();

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        } 

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            var catalogo = (ModuleCatalog)ModuleCatalog;
            catalogo.AddModule(typeof(MenuModule.MenuModule), InitializationMode.OnDemand);
            catalogo.AddModule(typeof(StatusModule.StatusModule), InitializationMode.OnDemand);
            catalogo.AddModule(typeof(LoginModule.LoginModule), InitializationMode.WhenAvailable);

            catalogo.AddModule(typeof(CategoriaModule.CategoriaModule), InitializationMode.OnDemand);
            catalogo.AddModule(typeof(ClienteModule.ClienteModule), InitializationMode.OnDemand);
            catalogo.AddModule(typeof(ProdutoModule.ProdutoModule), InitializationMode.OnDemand);
            catalogo.AddModule(typeof(FuncionarioModule.FuncionarioModule), InitializationMode.OnDemand);

            catalogo.AddModule(typeof(RegistrarPedidoModule.RegistrarPedidoModule), InitializationMode.OnDemand);
            catalogo.AddModule(typeof(ConsularPedidosModule.ConsularPedidosModule), InitializationMode.OnDemand);
            catalogo.AddModule(typeof(ModificarPedidoItemModule.ModificarPedidoItemModule), InitializationMode.OnDemand);
            catalogo.AddModule(typeof(ConsultarClienteModule.ConsultarClienteModule), InitializationMode.OnDemand);
            catalogo.AddModule(typeof(PedidoSolicitadosModule), InitializationMode.OnDemand);
            catalogo.AddModule(typeof(ConsultarPedidosOnlineModule), InitializationMode.OnDemand);
            catalogo.AddModule(typeof(ConsultasModule.ConsultasModule), InitializationMode.OnDemand);

            base.ConfigureModuleCatalog();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType(typeof(object), typeof(Funcionarios), nameof(Funcionarios));
            Container.RegisterType(typeof(object), typeof(Produtos), nameof(Produtos));
            Container.RegisterType(typeof(object), typeof(Menu), nameof(Menu));
            Container.RegisterType(typeof(object), typeof(Categorias), nameof(Categorias));
            Container.RegisterType(typeof(object), typeof(Clientes), nameof(Clientes));
            Container.RegisterType(typeof(object), typeof(RegistrarPedido), nameof(RegistrarPedido));
            Container.RegisterType(typeof(object), typeof(ModificarPedido), nameof(ModificarPedido));
            Container.RegisterType(typeof(object), typeof(ModificarItem), nameof(ModificarItem));
            Container.RegisterType(typeof(object), typeof(ClientesRegistrados), nameof(ClientesRegistrados));
            Container.RegisterType(typeof(object), typeof(MenuAdmin), nameof(MenuAdmin));
            Container.RegisterType(typeof(object), typeof(MenuOnline), nameof(MenuOnline));
            Container.RegisterType(typeof(object), typeof(Login), nameof(Login));
            Container.RegisterType(typeof(object), typeof(Statusbar), nameof(Statusbar));
            Container.RegisterType(typeof(object), typeof(PagamentoDireto), nameof(PagamentoDireto));
            Container.RegisterType(typeof(object), typeof(ConsultarPedidosAdmin), nameof(ConsultarPedidosAdmin));
            Container.RegisterType(typeof(object), typeof(AboutPlataform), nameof(AboutPlataform));
            Container.RegisterType(typeof(object), typeof(AboutDevelopers), nameof(AboutDevelopers));
            Container.RegisterType(typeof(object), typeof(ConsultarPedidos), nameof(ConsultarPedidos));
            Container.RegisterType(typeof(object), typeof(ConsultarPedidosOnline.Views.ConsultarPedidosOnline), nameof(ConsultarPedidosOnline.Views.ConsultarPedidosOnline));
            Container.RegisterType(typeof(object), typeof(PedidosSolicitados), nameof(PedidosSolicitados));

        }

        protected override IUnityContainer CreateContainer()
        {
            var container = base.CreateContainer();
            container.RegisterType<IMoradaRepositorio, MoradaRepositorio>();
            container.RegisterType<ICategoriaRepositorio, CategoriaRepositorio>();
            container.RegisterType<IRepositorio<TipoDeUsuario>, Repositorio<TipoDeUsuario>>();
            container.RegisterType<IProdutoRepositorio, ProdutoRepositorio>();
            container.RegisterType<IClienteRepositorio, ClienteRepositorio>();
            container.RegisterType<IFuncionarioRepositorio, FuncionarioRepositorio>();
            container.RegisterType<IPedidoRepositorio, PedidoRepositorio>();
            container.RegisterType<IItemRepositorio, ItemRepositorio>();
            container.RegisterType<IEstadoRepositorio, EstadoRepositorio>();
            return container;
        }

    }
}
