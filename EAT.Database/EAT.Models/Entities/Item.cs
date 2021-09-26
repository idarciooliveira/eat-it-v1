namespace EAT.Models.Entities
{
    public class Item : Entity
    {
       
        private int _quantidade;
        public int Quantidade
        {
            get => _quantidade;
            set => SetProperty(ref _quantidade, value);
        }
        private decimal _valor;
        public decimal Valor
        {
            get => _valor;
            set => SetProperty(ref _valor, value);
        }
        private int _pedidoid;
        public int PedidoId
        {
            get => _pedidoid;
            set => SetProperty(ref _pedidoid, value);
        }
        private int _produtoid;
        public int ProdutoId
        {
            get => _produtoid;
            set => SetProperty(ref _produtoid, value);
        }
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
