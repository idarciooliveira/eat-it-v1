using System.Collections.Generic;

namespace EAT.Models.Entities
{
    public sealed class Estado : Entity
    {
        public Estado() => Pedido = new HashSet<Pedido>();
        
        private string _nome;
        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }
        public ICollection<Pedido> Pedido { get; set; }
    }
}
