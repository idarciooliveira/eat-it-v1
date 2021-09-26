using System.Collections.Generic;

namespace EAT.Models.Entities
{
    public sealed class Produto : Entity
    {
        public Produto() => Item = new HashSet<Item>();
        

        private string _descricao;
        public string Descricao
        {
            get => _descricao;
            set => SetProperty(ref _descricao, value);
        }
        private decimal _preco;
        public decimal Preco
        {
            get => _preco;
            set => SetProperty(ref _preco, value);
        }

        private int _categoriaId;
        public int CategoriaId
        {
            get => _categoriaId;
            set => SetProperty(ref _categoriaId, value);
        }

        private byte[] _imagem;
        public byte[] Imagem
        {
            get => _imagem;
            set => SetProperty(ref _imagem, value);
        }
        public Categoria Categoria { get; set; }
        public ICollection<Item> Item { get; set; }
    }
}
