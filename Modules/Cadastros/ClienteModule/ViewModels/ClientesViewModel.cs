using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using EAT.DAL.Interfaces;
using EAT.Infrastruture.WPF.Interface;
using EAT.Models.Entities;
using Prism.Commands;
using Prism.Regions;

namespace ClienteModule.ViewModels
{
    public class ClientesViewModel : ClientesBase, IMethod
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClientesViewModel(IClienteRepositorio clienteRepositorio,
            IMoradaRepositorio moradaRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            Moradas = new ObservableCollection<Morada>(moradaRepositorio.GetAll());
            OnStartup();
            OnReload();
            LoadCommands();
            InvokeCommands();
        }

        public void OnStartup()
        {
            Morada = null;
            Cliente = new Cliente();
            Cliente.PropertyChanged += (e, s) => InvokeCommands();
            Cliente.Id = 0;
        }

        public void OnReload()
        {
            Clientes = new ObservableCollection<Cliente>(_clienteRepositorio.GetClienteWithMorada());
        }

        public void OnClear()
        {
            Cliente.Id = 0;
            OnStartup();
        }

        public void OnModify()
        {
            try
            {
                _clienteRepositorio.Update(Cliente);
                OnClear();
                OnReload();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void OnRemove()
        {
            try
            {
                _clienteRepositorio.Remove(Cliente.Id);
                OnClear();
                OnReload();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void OnSubmit()
        {
            try
            {
                _clienteRepositorio.Save(Cliente);
                OnClear();
                OnReload();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void OnSelect(object obj)
        {
            var cliente = obj as Cliente;
            if(cliente != null)MappingCliente(cliente);
            var morada = obj as Morada;
            if (morada == null) return;
            Cliente.MoradaId = morada.Id;
        }

        public void LoadCommands()
        {
            SelectCommand = new DelegateCommand<object>(OnSelect);
            SubmitCommand = new DelegateCommand(OnSubmit,CanSubmit);
            RemoveCommand = new DelegateCommand(OnRemove,CanRemove);
            ClearCommand = new DelegateCommand(OnClear);
            ModifyCommand=new DelegateCommand(OnModify,CanModidy);
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            OnStartup();
            OnReload();
        }
    }
}
