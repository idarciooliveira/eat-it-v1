using System;
using System.ComponentModel;
using System.Windows;
using EAT.DAL.Interfaces;
using EAT.Infrastruture.WPF.Extensions;
using EAT.Infrastruture.WPF.Models;
using EAT.Infrastruture.WPF.Regions;
using EAT.Models.Entities;
using Prism.Commands;
using Prism.Regions;

namespace RegistrarPedidoModule.ViewModels
{
    public class PagamentoDiretoViewModel : PagamentoDiretoBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PagamentoDiretoViewModel(IRegionManager regionManager,
            IPedidoRepositorio pedidoRepositorio)
        {
            _regionManager = regionManager;
            _pedidoRepositorio = pedidoRepositorio;
            Titulo = "Formulário de Pagamento";
            Pedido = new Pedido();
            Pedido.PropertyChanged += (s,e) => InvokeCommand();
            Troco = 0;
            LoadCommand();
        }

        public void OnPaying()
        {
            Troco = Pedido.ValorEntregue - Pedido.SubTotal;
            Pedido.DataDaVenda = DateTime.Now;
            _pedidoRepositorio.Update(Pedido);
            MessageBox.Show("PAGAMENTO FEITO");
            RegionsExtensions.Navegar(_regionManager, MyRegions.MainRegion, ViewName.ConsultarPedidos);
        }
        public void OnCancelPayment() => RegionsExtensions.Navegar(_regionManager, MyRegions.MainRegion, ViewName.ConsultarPedidos);

        public void LoadCommand()
        {
            PayCommand =new DelegateCommand(OnPaying,CanPay);
            CancelPaymentCommand = new DelegateCommand(OnCancelPayment);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            var pedido = navigationContext.Parameters[nameof(Pedido)];
            if(pedido == null)return;
            SimpleMapper.Map(pedido,Pedido);
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Pedido = new Pedido();
            Troco = 0;
        }
    }
}
