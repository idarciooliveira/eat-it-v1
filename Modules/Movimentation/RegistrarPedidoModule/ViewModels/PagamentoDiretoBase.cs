using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Commands;

namespace RegistrarPedidoModule.ViewModels
{
    public class PagamentoDiretoBase : ViewModelBase
    {
        private Pedido _pedido;
        public Pedido Pedido
        {
            get => _pedido;
            set => SetProperty(ref _pedido, value);
        }
        private decimal _troco;
        public decimal Troco
        {
            get => _troco;
            set => SetProperty(ref _troco, value);
        }
        public DelegateCommand PayCommand { get; set; }
        public DelegateCommand CancelPaymentCommand { get; set; }

        public bool CanPay() => Pedido.ValorEntregue != 0;

        public void InvokeCommand()
        {
            PayCommand.RaiseCanExecuteChanged();
        }
    }
}