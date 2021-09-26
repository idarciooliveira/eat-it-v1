using System.Collections.Generic;
using Prism.Mvvm;

namespace EAT.Models.Entities
{
    public class Entity  : BindableBase, IIdentity
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
    }
    public sealed class Categoria : Entity
    {
        public Categoria() => Produto = new HashSet<Produto>();

        private string _descricao;
        public string Descricao
        {
            get => _descricao;
            set => SetProperty(ref _descricao, value);
        }
        public ICollection<Produto> Produto { get; set; }
    }
}
