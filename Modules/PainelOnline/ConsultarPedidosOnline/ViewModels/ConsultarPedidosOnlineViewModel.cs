using System.Collections.ObjectModel;
using System.Linq;
using EAT.DAL.Interfaces;
using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Commands;
using Prism.Regions;

namespace ConsultarPedidosOnline.ViewModels
{
    public class ConsultarPedidosOnlineViewModel : ConsultarPedidosOnlineBase
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IItemRepositorio _itemRepositorio;
        private readonly IRegionManager _regionManager;

        public ConsultarPedidosOnlineViewModel(IPedidoRepositorio pedidoRepositorio,
            IItemRepositorio itemRepositorio, IRegionManager regionManager)
        {
            Titulo = "Consultar Pedidos";
            _pedidoRepositorio = pedidoRepositorio;
            _itemRepositorio = itemRepositorio;
            _regionManager = regionManager;
            LoadCommands();
            Inicialize();
        }
        public void LoadCommands()
        {
            SelectPedidoCommand = new DelegateCommand<object>(OnSelectPedido);
            ModifyPedidoCommand = new DelegateCommand<object>(OnModifyPedido);
            ModifyItemCommand = new DelegateCommand<object>(OnModifyItem);
        }

        public void OnSelectPedido(object obj)
        {
            var pedido = obj as Pedido;
            if (pedido == null) return;
            Pedido = pedido;
            Items = new ObservableCollection<Item>(_itemRepositorio.GetItemsWithProdutos()
                .Where(a => a.PedidoId.Equals(pedido.Id)));
        }

        public void Inicialize()
        {
            Pedidos = new ObservableCollection<Pedido>(_pedidoRepositorio.GetRequestWithEstadoClienteAndMorada()
                .Where(a => a.EstadoId == EstadoDoPedido.PedidoAberto && a.NumeroDaMesa == null));
            Items = new ObservableCollection<Item>();
            Pedido = new Pedido { Id = 0 };
        }
        public void OnModifyPedido(object obj)
        {
            VerifyPedidoForNavigation(ViewName.ModificarPedido, obj, _regionManager);
        }

        public void OnModifyItem(object obj)
        {
            //VerifyPedidoForNavigation(ViewName.ConsultarPedidos, obj, _regionManager);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext) => Inicialize();
    }
}
