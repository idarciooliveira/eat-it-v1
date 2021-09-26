using System;
using System.Collections.ObjectModel;
using EAT.DAL.Interfaces;
using EAT.Infrastruture.WPF.Interface;
using EAT.Models.Entities;
using Prism.Commands;
using Prism.Regions;

namespace FuncionarioModule.ViewModels
{
    public class FuncionariosViewModel : FuncionarioBase, IMethod
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IRepositorio<TipoDeUsuario> _tipoRepositorio;

        public FuncionariosViewModel(IFuncionarioRepositorio funcionarioRepositorio, 
            IRepositorio<TipoDeUsuario> tipoRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
            _tipoRepositorio = tipoRepositorio;
            OnStartup();
            OnReload();
            LoadCommands();
            InvokeCommands();
        }

        public void Inicialize()
        {
            OnStartup();
            OnReload();
            LoadCommands();
            InvokeCommands();
        }

        public void OnStartup()
        {
            TextoDePesquisa = string.Empty;
            TipoDeUsuario = null;
            Funcionario = new Funcionario();
            Funcionario.PropertyChanged += (e, s) => InvokeCommands();
            Funcionario.Id = 0;
        }

        public void OnClear()
        {
            Funcionario.Id = 0;
            OnStartup();
        }

        public void OnReload()
        {
            Funcionarios = new ObservableCollection<Funcionario>(_funcionarioRepositorio.GetFuncionariosWithUserType());
            TipoDeUsuarios = new ObservableCollection<TipoDeUsuario>(_tipoRepositorio.GetAll());
            FuncionariosRegistrados = Funcionarios.Count.ToString();
        }

        public void OnRemove()
        {
            try
            {
                _funcionarioRepositorio.Remove(Funcionario.Id);
                OnClear();
                OnReload();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void OnModify()
        {
            try
            {
                _funcionarioRepositorio.Update(Funcionario);
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
                _funcionarioRepositorio.Save(Funcionario);
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
            var funcionario = obj as Funcionario;
            if (funcionario != null) MappingFuncionario(funcionario);
            var tipodeusuario = obj as TipoDeUsuario;
            if(tipodeusuario == null)return;
            Funcionario.TipoDeUsuarioId = tipodeusuario.Id;
        }

        public void LoadCommands()
        {
            ClearCommand= new DelegateCommand(OnClear);
            SubmitCommand = new DelegateCommand(OnSubmit,CanSubmit);
            RemoveCommand = new DelegateCommand(OnRemove,CanRemove);
            SelectCommand = new DelegateCommand<object>(OnSelect);
            ModifyCommand = new DelegateCommand(OnModify,CanModify);
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext) => Inicialize();
    }
}
