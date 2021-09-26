using System.Collections.ObjectModel;
using System.Linq;
using EAT.DAL.Interfaces;
using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Commands;
using Prism.Regions;

namespace ConsularPedidosModule.ViewModels
{
    public class ConsultarPedidosViewModel : ConsultarPedidosBase
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IItemRepositorio _itemRepositorio;
        private readonly IRegionManager _regionManager;

        public ConsultarPedidosViewModel(IPedidoRepositorio pedidoRepositorio,
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
            Items = new ObservableCollection<Item>(_itemRepositorio.GetItemsWithProdutos());
            Items = new ObservableCollection<Item>(Items.Where(a => a.PedidoId.Equals(pedido.Id)));
        }
        public void Inicialize()
        {
            Pedidos = new ObservableCollection<Pedido>(_pedidoRepositorio.GetRequestWithEstado()
                .Where(a=>a.EstadoId == EstadoDoPedido.PedidoAberto && a.EstadoId == EstadoDoPedido.PedidoAberto));
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

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            Inicialize();
        }

    }
}
