using System.Collections.ObjectModel;
using EAT.Infrastruture.WPF.Extensions;
using EAT.Infrastruture.WPF.Models;
using EAT.Infrastruture.WPF.Regions;
using EAT.Models.Entities;
using Prism.Commands;
using Prism.Regions;

namespace ConsularPedidosModule.ViewModels
{
    public class ConsultarPedidosBase : ViewModelBase
    {
        #region Variables/Object

        private ObservableCollection<Pedido> _pedidos;
        public ObservableCollection<Pedido> Pedidos
        {
            get => _pedidos;
            set => SetProperty(ref _pedidos, value);
        }

        private ObservableCollection<Item> _items;

        public ObservableCollection<Item> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        private Pedido _pedido;
        public Pedido Pedido
        {
            get => _pedido;
            set => SetProperty(ref _pedido, value);
        }

        #endregion

        #region Commands
        public DelegateCommand<object> SelectPedidoCommand { get; set; }
        public DelegateCommand<object> ModifyPedidoCommand { get; set; }
        public DelegateCommand<object> ModifyItemCommand { get; set; }
        #endregion

        public void InvokeCommands()
        {
            ModifyItemCommand.RaiseCanExecuteChanged();
            ModifyPedidoCommand.RaiseCanExecuteChanged();
        }

        public void VerifyPedidoForNavigation(string viewName, object obj, IRegionManager region)
        {
            var pedido = obj as Pedido;
            if (pedido == null) return;
            Pedido = pedido;
            if (Pedido.EstadoId == EstadoDoPedido.PedidoCancelado || Pedido.EstadoId == EstadoDoPedido.PedidoVendido) return;
            var parametros = new NavigationParameters { { nameof(Pedido), Pedido } };
            RegionsExtensions.Navegar(region, MyRegions.MainRegion, viewName, parametros);
        }
    }
}