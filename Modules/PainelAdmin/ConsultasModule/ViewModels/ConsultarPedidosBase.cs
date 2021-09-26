using System.Collections.ObjectModel;
using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Commands;

namespace ConsultasModule.ViewModels
{
    public class ConsultarPedidosBase : ViewModelBase
    {
        #region Property
        private int _todosPedidos;
        public int TodosPedidos
        {
            get => _todosPedidos;
            set => SetProperty(ref _todosPedidos, value);
        }

        private int _abertos;
        public int Abertos
        {
            get => _abertos;
            set => SetProperty(ref _abertos, value);
        }
        private int _cancelados;
        public int Cancelados
        {
            get => _cancelados;
            set => SetProperty(ref _cancelados, value);
        }
        private int _vedidos;
        public int Vendidos
        {
            get => _vedidos;
            set => SetProperty(ref _vedidos, value);
        }
        private int _novos;
        public int Novos
        {
            get => _novos;
            set => SetProperty(ref _novos, value);
        }

        private Pedido _pedido;
        public Pedido Pedido
        {
            get => _pedido;
            set => SetProperty(ref _pedido, value);
        }
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

        #endregion

        #region Commands

        public DelegateCommand UpdateCommand { get; set; }
        public DelegateCommand PrintCommand { get; set; }
        public DelegateCommand SeachCommand { get; set; }
        public DelegateCommand<object> SelectCommand { get; set; }

        #endregion
    }
}