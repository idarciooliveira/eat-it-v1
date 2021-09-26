using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using EAT.Models.Entities;
using Prism.Commands;
using Prism.Regions;
using EAT.DAL.Interfaces;
using EAT.Infrastruture.WPF.Extensions;
using EAT.Infrastruture.WPF.Models;
using EAT.Infrastruture.WPF.Regions;

namespace RegistrarPedidoModule.ViewModels
{
    public class RegistrarPedidoViewModel : RegistrarPedidoBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public RegistrarPedidoViewModel(IClienteRepositorio clienteRepositorio,
            IProdutoRepositorio produtoRepositorio, IPedidoRepositorio pedidoRepositorio, 
            IRegionManager regionManager)
        {
            Titulo = "Registrar Pedidos";
            _clienteRepositorio = clienteRepositorio;
            _produtoRepositorio = produtoRepositorio;
            _pedidoRepositorio = pedidoRepositorio;
            _regionManager = regionManager;
            Inicialize();
            Reload();
            LoadCommands();
            InvokeCommands();
        }
        public void OnClear()
        {
            Item.Id = 0;
            Inicialize();
        }
        public void Inicialize()
        {
            Produto = null;
            Pedido = new Pedido { NumeroDaMesa = 0 };
            Item = new Item { Quantidade = 1 };
            Item.PropertyChanged += (e, s) => InvokeCommands();
            Pedido.PropertyChanged += (e, s) => CheckTableStatus();
            Clientes = new ObservableCollection<Cliente>(_clienteRepositorio.GetAll());
            Items = new ObservableCollection<Item>();
            Total = new decimal();
        }

        private void CheckTableStatus()
        {
            if (_pedidoRepositorio.EmptyTable(Pedido.NumeroDaMesa.Value))
                throw new ArgumentException("Mesa Ocupada");
        }

        public void OnSelect(object obj)
        {
            var cliente = obj as Cliente;
            if (cliente != null) Pedido.ClienteId = cliente.Id;
            var produto = obj as Produto;
            if (produto != null) ExtrairProduto(produto);
        }

        public void Reload() => 
            Produtos = new ObservableCollection<Produto>(_produtoRepositorio.GetAll());

        public void LoadCommands()
        {
            DirectPaymentCommand = new DelegateCommand(DirectPayment);
            SubmitPedidoCommand = new DelegateCommand(OnSubmitPedido, CanSubmit);
            AddItemCommand = new DelegateCommand(OnAddItem, CanAddItem);
            RemoveItemCommand = new DelegateCommand<object>(OnRemoveItem);
            SelectCommand = new DelegateCommand<object>(OnSelect);
            CancelarPedidoCommand = new DelegateCommand(Inicialize);
        }

        public void DirectPayment()
        {
            PreparingPedido();
            var paramentros = new NavigationParameters {{nameof(Pedido), Pedido}};
            RegionsExtensions.Navegar(_regionManager,MyRegions.MainRegion,ViewName.PagamentoDireto,paramentros);
        }

        public void OnSubmitPedido()
        {
            try
            {
                PreparingPedido();
                _pedidoRepositorio.Save(Pedido);
                Reload();
                OnClear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void OnAddItem()
        {
            if (Items.Any(a => a.ProdutoId == Item.ProdutoId)) return;
            Items.Add(Item);
            SumTotal();
            ReloadItem();
            Reload();
        }

        public void OnRemoveItem(object obj)
        {
            var item = obj as Item;
            if (item == null) return;
            SubTrairTotal(item);
            Items.Remove(Items.FirstOrDefault(a => a.Id == item.Id));
        }

        public void OnAnularPedido()
        {
            Reload();
            Inicialize();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            Inicialize();
            Reload();
        }
    }
}
