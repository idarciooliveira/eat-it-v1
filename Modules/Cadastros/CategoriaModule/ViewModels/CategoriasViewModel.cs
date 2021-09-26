using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using EAT.DAL.Interfaces;
using EAT.Infrastruture.WPF.Interface;
using EAT.Models.Entities;
using Prism.Commands;

namespace CategoriaModule.ViewModels
{
    public class CategoriasViewModel : CategoriaBase, IMethod
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriasViewModel(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
            Titulo = "Categorias";
            _categoriaRepositorio = categoriaRepositorio;
            OnStartup();
            OnReload();
            LoadCommands();
            InvokeCommands();
        }

        public void OnStartup()
        {
            Categoria = new Categoria();
            Categoria.PropertyChanged += (s, a) => InvokeCommands();
            Categoria.Id = 0;
        }
        public void OnClear()
        {
            Categoria.Id = 0;
            OnStartup();
        }
        public void LoadCommands()
        {
            SubmitCommand = new DelegateCommand(OnSubmit, CanSubmit);
            ModifyCommand = new DelegateCommand(OnModify, CanModify);
            ClearCommand = new DelegateCommand(OnClear);
            RemoveCommand = new DelegateCommand(OnRemove, CanRemove);
            SelectCommand = new DelegateCommand<object>(OnSelect);
        }
        public void OnSubmit()
        {
            try
            {
                _categoriaRepositorio.Save(Categoria);
                OnReload();
                OnClear();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
        public void OnRemove()
        {
            try
            {
                if (!_categoriaRepositorio.CanRemove(Categoria.Id))
                {
                    _categoriaRepositorio.Remove(Categoria.Id);
                    OnReload();
                    OnClear();
                }
                else
                {
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
        public void OnModify()
        {
            try
            {
                _categoriaRepositorio.Update(Categoria);
                OnReload();
                OnClear();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
        public void OnSelect(object obj)
        {
            var categoria = obj as Categoria;
            if (categoria == null) return;
            Categoria.Id = categoria.Id;
            Categoria.Descricao = categoria.Descricao;
        }
        public void OnReload()
        {
            Categorias = new ObservableCollection<Categoria>(_categoriaRepositorio.GetAll());
        }

    }
}
