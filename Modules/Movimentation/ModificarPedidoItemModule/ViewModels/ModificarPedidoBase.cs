using System.Collections.ObjectModel;
using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Commands;

namespace ModificarPedidoItemModule.ViewModels
{
    public class ModificarPedidoBase : ViewModelBase
    {
        #region Propriedades

        private Pedido _pedido;
        public Pedido Pedido
        {
            get => _pedido;
            set => SetProperty(ref _pedido, value);
        }
        private Estado _estado;
        public Estado Estado
        {
            get => _estado;
            set => SetProperty(ref _estado, value);
        }

        private ObservableCollection<Estado> _estados;
        public ObservableCollection<Estado> Estados
        {
            get => _estados;
            set => SetProperty(ref _estados, value);
        }

        #endregion

        public DelegateCommand AlterarCommand { get; set; }
        public DelegateCommand VoltarCommand { get; set; }
        public DelegateCommand ImprimirCommand { get; set; }
        public DelegateCommand<object> SelectEstadoCommand { get; set; }
    }
}