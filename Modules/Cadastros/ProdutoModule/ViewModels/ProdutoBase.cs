using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using EAT.Infrastruture.WPF.Interface;
using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Commands;
using ProdutoModule.Models;

namespace ProdutoModule.ViewModels
{
    public class ProdutoBase : ViewModelBase, ICommand
    {
        #region Properties

        private Categoria _categoria;
        public Categoria Categoria
        {
            get => _categoria;
            set => SetProperty(ref _categoria, value);
        }

        private Produto _produto;
        public Produto Produto
        {
            get => _produto;
            set => SetProperty(ref _produto, value);
        }

        private ObservableCollection<Produto> _produtos;
        public ObservableCollection<Produto> Produtos
        {
            get => _produtos;
            set => SetProperty(ref _produtos, value);
        }

        private ObservableCollection<Categoria> _categorias;
        public ObservableCollection<Categoria> Categorias
        {
            get => _categorias;
            set => SetProperty(ref _categorias, value);
        }

        #endregion

        public bool CanSubmit() => !string.IsNullOrEmpty(Produto.Descricao)
                                   && Produto.Id == 0 && Produto.Preco != 0 && Produto.CategoriaId != 0;

        public bool CanModify() => !string.IsNullOrEmpty(Produto.Descricao)
                                   && Produto.Id != 0 && Produto.Preco != 0 && Produto.CategoriaId != 0;

        public static void SeachOnDataGrid(ItemCollection itemCollection, string seachText)
        {
            itemCollection.Filter = o => (o as Produto)?.Descricao.
                                         StartsWith(seachText, StringComparison.CurrentCultureIgnoreCase) ?? false;
        }
        public void ExtrairProduto(Produto produto)
        {
            Produto.Id = produto.Id;
            Produto.Descricao = produto.Descricao;
            Produto.Preco = produto.Preco;
            Produto.CategoriaId = produto.CategoriaId;
            Produto.Imagem = produto.Imagem;
            Categoria = Categorias.FirstOrDefault(a => a.Id == produto.CategoriaId);
        }

        public void InvokeCommands()
        {
            ModifyCommand.RaiseCanExecuteChanged();
            RemoveCommand.RaiseCanExecuteChanged();
            SubmitCommand.RaiseCanExecuteChanged();
        }

        public void OnAdicionarImagem() => Produto.Imagem = ByteExtension.LoadImagem();

        public DelegateCommand<int?> SelectCategoryCommand { get; set; }
        public DelegateCommand RemoveCommand { get; set; }
        public DelegateCommand SubmitCommand { get; set; }
        public DelegateCommand ClearCommand { get; set; }
        public DelegateCommand ModifyCommand { get; set; }
        public DelegateCommand<object> SelectCommand { get; set; }
        public DelegateCommand AddImageCommand { get; set; }
    }
}