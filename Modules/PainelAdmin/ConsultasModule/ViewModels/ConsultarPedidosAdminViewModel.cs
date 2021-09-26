 using System;
 using System.Collections.ObjectModel;
 using System.Linq;
 using EAT.DAL.Interfaces;
 using EAT.Infrastruture.WPF.Models;
 using EAT.Models.Entities;
 using Prism.Commands;
 using Prism.Regions;

namespace ConsultasModule.ViewModels
{
    public class ConsultarPedidosAdminViewModel : ConsultarPedidosBase
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IItemRepositorio _itemRepositorio;

        public ConsultarPedidosAdminViewModel(IPedidoRepositorio pedidoRepositorio,
            IItemRepositorio itemRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _itemRepositorio = itemRepositorio;
            OnReload();
            Inicialize();
            UpdateCommand = new DelegateCommand(OnReload);
            SelectCommand = new DelegateCommand<object>(OnSelect);
            PrintCommand = new DelegateCommand(OnPrint);
        }


        public void Inicialize()
        {
            TextoDePesquisa = string.Empty;
            Pedido = new Pedido();
        }

        public void OnPrint()
        {
            
        }

        public void OnSelect(object obj)
        {
            var pedido = obj as Pedido;
            if(pedido== null)return;
            Items = new ObservableCollection<Item>(_itemRepositorio.GetItemsWithProdutos().Where(a=>a.PedidoId == pedido.Id));
        }

        public void OnReload()
        {
            Pedidos = new ObservableCollection<Pedido>(_pedidoRepositorio.GetRequestWithEstadoAndCliente());
            Abertos = Pedidos.Count(a => a.EstadoId == EstadoDoPedido.PedidoAberto);
            Cancelados = Pedidos.Count(a => a.EstadoId == EstadoDoPedido.PedidoCancelado);
            Vendidos = Pedidos.Count(a => a.EstadoId == EstadoDoPedido.PedidoVendido);
            Novos = Pedidos.Count(a => a.EstadoId == EstadoDoPedido.Novo);
            TodosPedidos = Pedidos.Count;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            Inicialize();
            OnReload();
        }
    }
}
