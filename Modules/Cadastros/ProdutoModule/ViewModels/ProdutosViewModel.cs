using System;
using System.Collections.ObjectModel;
using System.Windows;
using EAT.DAL.Interfaces;
using EAT.Infrastruture.WPF.Interface;
using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Commands;
using Prism.Regions;

namespace ProdutoModule.ViewModels
{
    public class ProdutosViewModel : ProdutoBase, IMethod
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public ProdutosViewModel(IProdutoRepositorio produtoRepositorio,
            ICategoriaRepositorio categoriaRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
            OnStartup();
            OnReload();
            LoadCommands();
            InvokeCommands();
        }
        public void OnClear()
        {
            Produto.Id = 0;
            OnStartup();
        }

        public void OnStartup()
        {
            TextoDePesquisa = string.Empty;
            Produto = new Produto();
            Categoria = null;
            Produto.Id = 0;
            Produto.PropertyChanged += (s, e) => InvokeCommands();
        }
        public void OnReload()
        {
            Categorias = new ObservableCollection<Categoria>(_categoriaRepositorio.GetAll());
            Produtos = new ObservableCollection<Produto>(_produtoRepositorio.GetProdutoWithCategory());
        }
        public void LoadCommands()
        {
            ModifyCommand = new DelegateCommand(OnModify, CanModify);
            RemoveCommand = new DelegateCommand(OnRemove, CanModify);
            SelectCommand = new DelegateCommand<object>(OnSelect);
            SubmitCommand = new DelegateCommand(OnSubmit, CanSubmit);
            ClearCommand = new DelegateCommand(OnClear);
            AddImageCommand = new DelegateCommand(OnAdicionarImagem);
            SelectCategoryCommand = new DelegateCommand<int?>(OnSelectCategory);
        }
        public void OnSubmit()
        {
            try
            {
                _produtoRepositorio.Save(Produto);
                MessageBox.Show(Message.Registed);
                OnReload();
                OnClear();
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
                _produtoRepositorio.Remove(Produto.Id);
                MessageBox.Show(Message.Removed);
                OnReload();
                OnClear();
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
                _produtoRepositorio.Update(Produto);
                MessageBox.Show(Message.Updated);
                OnReload();
                OnClear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void OnSelect(object obj)
        {
            var produto = obj as Produto;
            if (produto == null) return;
            ExtrairProduto(produto);
        }

        public void OnSelectCategory(int? categoriaId)
        {
            if (categoriaId == null || categoriaId == 0) return;
            Produto.CategoriaId = categoriaId.Value;
            Produto.PropertyChanged += (s, e) => InvokeCommands();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            OnStartup();
            OnReload();
        }
    }
}
