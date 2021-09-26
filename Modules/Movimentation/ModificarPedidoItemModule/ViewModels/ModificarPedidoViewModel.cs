using System;
using System.Collections.ObjectModel;
using System.Linq;
using EAT.DAL.Interfaces;
using EAT.Infrastruture.WPF.Extensions;
using EAT.Infrastruture.WPF.Models;
using EAT.Infrastruture.WPF.Regions;
using EAT.Models.Entities;
using Prism.Commands;
using Prism.Regions;

namespace ModificarPedidoItemModule.ViewModels
{
    public class ModificarPedidoViewModel : ModificarPedidoBase
    {
        private readonly IEstadoRepositorio _estadoRepositorio;
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IRegionManager _regionManager;

        public ModificarPedidoViewModel(IEstadoRepositorio estadoRepositorio,
            IPedidoRepositorio pedidoRepositorio, IRegionManager regionManager)
        {
            _estadoRepositorio = estadoRepositorio;
            _pedidoRepositorio = pedidoRepositorio;
            _regionManager = regionManager;
            Inicialize();
            LoadCommands();
        }

        public void OnAlterarPedido()
        {
            if (Pedido.EstadoId == EstadoDoPedido.PedidoVendido)
            {
                var parametros = new NavigationParameters { { nameof(Pedido), Pedido } };
                RegionsExtensions.Navegar(_regionManager,MyRegions.MainRegion,ViewName.PagamentoDireto,parametros);
            }
            _pedidoRepositorio.Update(Pedido);
        }

        public void OnSelectEstado(object obj)
        {
            var estado = obj as Estado;
            if (estado == null) return;
            Pedido.EstadoId = estado.Id;
            SimpleMapper.Map(estado,Estado);
        }

        public void OnImprimirPedido() => throw new NotImplementedException("Ultimo a ser implementado Relatorio");

        public void OnVoltarPedido() => 
            RegionsExtensions.Navegar(_regionManager,MyRegions.MainRegion,ViewName.ConsultarPedidos);

        public void LoadCommands()
        {
            SelectEstadoCommand = new DelegateCommand<object>(OnSelectEstado);
            AlterarCommand = new DelegateCommand(OnAlterarPedido);
            ImprimirCommand = new DelegateCommand(OnImprimirPedido);
            VoltarCommand = new DelegateCommand(OnVoltarPedido);
        }
        public void Inicialize()
        {
            Estado = null;
            Estados = new ObservableCollection<Estado>(_estadoRepositorio.GetAll());
            Pedido = new Pedido();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            var pedido = navigationContext.Parameters[nameof(Pedido)];
            if(pedido == null)return;
            SimpleMapper.Map(pedido,Pedido);
            Estado = Estados.FirstOrDefault(a => a.Id == Pedido.EstadoId);
        }
    }
}
