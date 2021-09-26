using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using EAT.Infrastruture.WPF.Interface;
using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Commands;

namespace FuncionarioModule.ViewModels
{
    public class FuncionarioBase : ViewModelBase, IBaseMethod, ICommand
    {
        #region Property

        private string _funcionariosRegistrados;
        public string FuncionariosRegistrados
        {
            get => $"Funcionarios Registrados: {_funcionariosRegistrados}";
            set => SetProperty(ref _funcionariosRegistrados, value);
        }
        private Funcionario _funcionario;
        public Funcionario Funcionario
        {
            get => _funcionario;
            set => SetProperty(ref _funcionario, value);
        }
        private ObservableCollection<Funcionario> _funcionarios;
        public ObservableCollection<Funcionario> Funcionarios
        {
            get => _funcionarios;
            set => SetProperty(ref _funcionarios, value);
        }
        private TipoDeUsuario _tipoDeUsuario;
        public TipoDeUsuario TipoDeUsuario
        {
            get => _tipoDeUsuario;
            set => SetProperty(ref _tipoDeUsuario, value);
        }
        private ObservableCollection<TipoDeUsuario> _tipoDeUsuarios;
        public ObservableCollection<TipoDeUsuario> TipoDeUsuarios
        {
            get => _tipoDeUsuarios;
            set => SetProperty(ref _tipoDeUsuarios, value);
        }

        #endregion

        public void MappingFuncionario(Funcionario sourceFuncionario)
        {
            SimpleMapper.Map(sourceFuncionario, Funcionario);
            TipoDeUsuario = TipoDeUsuarios.FirstOrDefault(a => a.Id == sourceFuncionario.TipoDeUsuarioId);
        }

        public void InvokeCommands()
        {
            SubmitCommand.RaiseCanExecuteChanged();
            RemoveCommand.RaiseCanExecuteChanged();
            ModifyCommand.RaiseCanExecuteChanged();
        }

        public bool CanRemove() => Funcionario.Id != 0 &&
                                   !string.IsNullOrEmpty(Funcionario.Nome) &&
                                   !string.IsNullOrEmpty(Funcionario.Sobrenome)
                                   && !string.IsNullOrEmpty(Funcionario.Telefone) && Funcionario.TipoDeUsuarioId != 0 &&
                                   !string.IsNullOrEmpty(Funcionario.SenhaDeUsuario) &&
                                   !string.IsNullOrEmpty(Funcionario.NomeDeUsuario);

        public bool CanSubmit() => Funcionario.Id == 0 &&
                                   !string.IsNullOrEmpty(Funcionario.Nome) &&
                                   !string.IsNullOrEmpty(Funcionario.Sobrenome)
                                   && !string.IsNullOrEmpty(Funcionario.Telefone) && Funcionario.TipoDeUsuarioId != 0 &&
                                   !string.IsNullOrEmpty(Funcionario.SenhaDeUsuario) &&
                                   !string.IsNullOrEmpty(Funcionario.NomeDeUsuario);

        public bool CanModify() => CanRemove();

        public static void SeachOnDataGrid(ItemCollection itemCollection, string seachText)
        {
            itemCollection.Filter = o => (o as Funcionario)?.NomeCompleto.
                       StartsWith(seachText, StringComparison.CurrentCultureIgnoreCase) ?? false;
        }

        #region Commands

        public DelegateCommand SubmitCommand { get; set; }
        public DelegateCommand RemoveCommand { get; set; }
        public DelegateCommand ClearCommand { get; set; }
        public DelegateCommand ModifyCommand { get; set; }
        public DelegateCommand<object> SelectCommand { get; set; }

        #endregion
    }
}