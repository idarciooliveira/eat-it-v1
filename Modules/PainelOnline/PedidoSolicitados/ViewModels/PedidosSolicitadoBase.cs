using System.Collections.ObjectModel;
using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Commands;

namespace PedidoSolicitados.ViewModels
{
    public class PedidosSolicitadoBase : ViewModelBase
    {
        public DelegateCommand<object> SelectCommand { get; set; }
        public DelegateCommand AceptCommand { get; set; }
        public DelegateCommand DenyCommand { get; set; }
        public DelegateCommand ReloadCommand { get; set; }

        public bool CanAceptOrDenyRequest() => Pedido.Id != 0;
        public void InvokeCommands()
        {
            AceptCommand.RaiseCanExecuteChanged();
            DenyCommand.RaiseCanExecuteChanged();
        }

        #region Property

        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        private ObservableCollection<Pedido> _pedidos;
        public ObservableCollection<Pedido> Pedidos
        {
            get => _pedidos;
            set => SetProperty(ref _pedidos, value);
        }
        private Pedido _pedido;
        public Pedido Pedido
        {
            get => _pedido;
            set => SetProperty(ref _pedido, value);
        }

        private int _pedidosSolicitados;
        public int PedidosSolicitados
        {
            get => _pedidosSolicitados;
            set => SetProperty(ref _pedidosSolicitados, value);
        }
        #endregion
    }
}