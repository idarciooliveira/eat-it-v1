using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using EAT.DAL.Interfaces;
using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;

namespace ConsultarClienteModule.ViewModels
{
    public class ClientesRegistradosViewModel : ViewModelBase
    {
        private Cliente _cliente;
        public Cliente Cliente
        {
            get => _cliente;
            set => SetProperty(ref _cliente, value);
        }
        private ObservableCollection<Cliente> _clientes;
        public ObservableCollection<Cliente> Clientes
        {
            get => _clientes;
            set => SetProperty(ref _clientes, value);
        }

        private readonly IClienteRepositorio _clienteRepositorio;

        public ClientesRegistradosViewModel(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            Inicialize();
        }

        public void Inicialize()
        {
            Clientes = new ObservableCollection<Cliente>(_clienteRepositorio.GetClienteWithMorada());
        }

        public static void SeachOnDataGrid(ItemCollection itemCollection, string seachText)
        {
            itemCollection.Filter = o => (o as Cliente)?
                                         .Nome.StartsWith(seachText, StringComparison.CurrentCultureIgnoreCase) ?? false;
        }
    }
}
