using System.Collections.ObjectModel;
using EAT.Infrastruture.WPF.Interface;
using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Commands;

namespace CategoriaModule.ViewModels
{
    public class CategoriaBase : ViewModelBase, IBaseMethod, ICommand
    {
        #region Properties

        private Categoria _categoria;
        private ObservableCollection<Categoria> _categorias;

        public Categoria Categoria
        {
            get => _categoria; set => SetProperty(ref _categoria, value);
        }
        public ObservableCollection<Categoria> Categorias
        {
            get => _categorias; set => SetProperty(ref _categorias, value);
        }

        #endregion

        public void InvokeCommands()
        {
            SubmitCommand.RaiseCanExecuteChanged();
            RemoveCommand.RaiseCanExecuteChanged();
            ModifyCommand.RaiseCanExecuteChanged();
        }

        public bool CanRemove() => !string.IsNullOrEmpty(Categoria.Descricao) && Categoria.Id != 0;
        public bool CanSubmit()=> !string.IsNullOrEmpty(Categoria.Descricao) && Categoria.Id == 0;
        public bool CanModify() => CanRemove();

        public DelegateCommand SubmitCommand { get; set; }
        public DelegateCommand RemoveCommand { get; set; }
        public DelegateCommand ClearCommand { get; set; }
        public DelegateCommand ModifyCommand { get; set; }
        public DelegateCommand<object> SelectCommand { get; set; }
    }
}