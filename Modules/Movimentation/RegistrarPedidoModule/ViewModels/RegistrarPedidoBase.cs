using System;
using System.Collections.ObjectModel;
using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Commands;

namespace RegistrarPedidoModule.ViewModels
{
    public class RegistrarPedidoBase : ViewModelBase
    {
        #region Varivables

        private Produto _produto;
        public Produto Produto
        {
            get => _produto;
            set => SetProperty(ref _produto, value);
        }
        private decimal _total;
        public decimal Total
        {
            get => _total;
            set => SetProperty(ref _total, value);
        }

        private Item _item;
        public Item Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
        }
        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }
        private ObservableCollection<Produto> _produtos;
        public ObservableCollection<Produto> Produtos
        {
            get => _produtos;
            set => SetProperty(ref _produtos, value);
        }
        private ObservableCollection<Cliente> _clientes;
        public ObservableCollection<Cliente> Clientes
        {
            get => _clientes;
            set => SetProperty(ref _clientes, value);
        }
        private Cliente _cliente;
        public Cliente Cliente
        {
            get => _cliente;
            set => SetProperty(ref _cliente, value);
        }
        private Pedido _pedido;
        public Pedido Pedido
        {
            get => _pedido;
            set => SetProperty(ref _pedido, value);
        }

        #endregion

        #region Commands

        public DelegateCommand DirectPaymentCommand { get; set; }
        public DelegateCommand<object> RemoveItemCommand { get; set; }
        public DelegateCommand AddItemCommand { get; set; }
        public DelegateCommand SubmitPedidoCommand { get; set; }
        public DelegateCommand<object> SelectCommand { get; set; }
        public DelegateCommand CancelarPedidoCommand { get; set; }
        #endregion

        public bool CanSubmit() => true;
        public bool CanRemoveItem() => true;
        public bool CanAddItem() => Item.ProdutoId != 0;

        public void InvokeCommands()
        {
            AddItemCommand.RaiseCanExecuteChanged();
            RemoveItemCommand.RaiseCanExecuteChanged();
            SubmitPedidoCommand.RaiseCanExecuteChanged();
        }

        public void ExtrairProduto(Produto produto)
        {
            Item.Valor = produto.Preco;
            Item.ProdutoId = produto.Id;
            Item.Produto = produto;
        }

        public void SumTotal() => Total += Item.Quantidade * Item.Valor;
        public void SubTrairTotal(Item item) => Total -= item.Quantidade * item.Valor;

        public void ReloadItem()
        {
            Item.Id = 0;
            Item = new Item { Quantidade = 1 };
            Item.PropertyChanged += (e, s) => InvokeCommands();
        }
        
        public void PreparingPedido()
        {
            foreach (var item in Items)
                item.Produto = null;
            Pedido.Item = Items;
            Pedido.DataDoPedido = DateTime.Now;
            Pedido.SubTotal = Total;
            Pedido.EstadoId = EstadoDoPedido.PedidoAberto;
            
        }

    }
}