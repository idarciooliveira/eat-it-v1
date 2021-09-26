using System;
using System.Collections.ObjectModel;
using System.Linq;
using EAT.DAL.Interfaces;
using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Commands;
using Prism.Regions;

namespace PedidoSolicitados.ViewModels
{
    public class PedidosSolicitadosViewModel : PedidosSolicitadoBase
    {
        private readonly IItemRepositorio _itemRepositorio;
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidosSolicitadosViewModel(IItemRepositorio itemRepositorio,
            IPedidoRepositorio pedidoRepositorio)
        {
            _itemRepositorio = itemRepositorio;
            _pedidoRepositorio = pedidoRepositorio;
            LoadCommands();
            Inicialize();
            OnReload();
        }

        private void OnChangeRequestToDenyOrAcept()
        {
            Pedido.Cliente = null;
            Pedido.Morada = null;
            Pedido.Estado = null;
            _pedidoRepositorio.Update(Pedido);
            OnReload();
            Inicialize();
        }

        public void OnAceptRequest()
        {
            Pedido.EstadoId = EstadoDoPedido.PedidoAberto;
            OnChangeRequestToDenyOrAcept();
        }

        public void OnDenyRequest()
        {
            Pedido.EstadoId = EstadoDoPedido.PedidoRecusado;
            OnChangeRequestToDenyOrAcept();
        }

        private void OnSelect(object obj)
        {
            var pedido = obj as Pedido;
            if(pedido == null)return;
            SimpleMapper.Map(pedido,Pedido);
            Items = new ObservableCollection<Item>(_itemRepositorio.GetItemsWithProdutos()
                .Where(a=>a.PedidoId == Pedido.Id));
        }

        private void Inicialize()
        {
            TextoDePesquisa = string.Empty;
            Pedido = new Pedido();
            Pedido.PropertyChanged += (s, e) => InvokeCommands();
            Pedido.Id = 0;
        }

        private void LoadCommands()
        {
            SelectCommand = new DelegateCommand<object>(OnSelect);
            AceptCommand = new DelegateCommand(OnAceptRequest,CanAceptOrDenyRequest);
            DenyCommand = new DelegateCommand(OnDenyRequest,CanAceptOrDenyRequest);
            ReloadCommand = new DelegateCommand(OnReload);
        }

        private void OnReload()
        {
            Pedidos = new ObservableCollection<Pedido>(
                _pedidoRepositorio.GetRequestWithEstadoClienteAndMorada()
                .Where(a=>a.EstadoId == EstadoDoPedido.Novo).OrderBy(a=>a.DataDoPedido.Second));
            PedidosSolicitados = Pedidos.Count;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
           OnReload();
           Inicialize();
          
        }
    }
}
