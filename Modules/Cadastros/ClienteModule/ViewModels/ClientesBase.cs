using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using EAT.Infrastruture.WPF.Interface;
using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Commands;

namespace ClienteModule.ViewModels
{
    public class ClientesBase : ViewModelBase, ICommand
    {
        #region Property

        private Cliente _cliente;
        public Cliente Cliente
        {
            get => _cliente;
            set => SetProperty(ref _cliente, value);
        }
        private Morada _morada;
        public Morada Morada
        {
            get => _morada;
            set => SetProperty(ref _morada, value);
        }
        private ObservableCollection<Morada> _moradas;
        public ObservableCollection<Morada> Moradas
        {
            get => _moradas;
            set => SetProperty(ref _moradas, value);
        }
        private ObservableCollection<Cliente> _clientes;
        public ObservableCollection<Cliente> Clientes
        {
            get => _clientes;
            set => SetProperty(ref _clientes, value);
        }
        #endregion

        #region Commands
        public DelegateCommand<object> SelectClienteCommand { get; set; }
        public DelegateCommand RemoveCommand { get; set; }
        public DelegateCommand SubmitCommand { get; set; }
        public DelegateCommand ClearCommand { get; set; }
        public DelegateCommand ModifyCommand { get; set; }
        public DelegateCommand<object> SelectCommand { get; set; }
        #endregion

        public static void SeachOnDataGrid(ItemCollection itemCollection, string seachText)
        {
            itemCollection.Filter = o => (o as Cliente)?
             .Nome.StartsWith(seachText, StringComparison.CurrentCultureIgnoreCase) ?? false;
        }

        public void InvokeCommands()
        {
            ModifyCommand.RaiseCanExecuteChanged();
            SubmitCommand.RaiseCanExecuteChanged();
            RemoveCommand.RaiseCanExecuteChanged();
        }

        public bool CanRemove() => CanModidy();

        public bool CanModidy() =>
            Cliente.Id != 0 &&
            Cliente.MoradaId != 0 &&
            !string.IsNullOrEmpty(Cliente.Sobrenome) &&
            !string.IsNullOrEmpty(Cliente.Nome) &&
            !string.IsNullOrEmpty(Cliente.Telefone);

        public bool CanSubmit() =>
            Cliente.Id == 0 &&
            Cliente.MoradaId != 0 &&
            !string.IsNullOrEmpty(Cliente.Sobrenome) &&
            !string.IsNullOrEmpty(Cliente.Nome) &&
            !string.IsNullOrEmpty(Cliente.Telefone);

        public void MappingCliente(Cliente clienteSource)
        {
            SimpleMapper.Map(clienteSource,Cliente);
            Morada = Moradas.FirstOrDefault(a => a.Id == clienteSource.MoradaId);
        }

    }
}