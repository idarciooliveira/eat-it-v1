using System;
using System.Collections.Generic;

namespace EAT.Models.Entities
{
    public sealed class Pedido : Entity
    {
        public Pedido() => Item = new HashSet<Item>();

        private int? _clienteid;
        private int _estadoid;
        private int? _numeroDaMesa;
        private DateTime _dataDoPedido;
        private decimal _subTotal;
        private DateTime? _dataDaVenda;

        public decimal SubTotal
        {
            get => _subTotal;
            set => SetProperty(ref _subTotal, value);
        }
        public DateTime? DataDaVenda
        {
            get => _dataDaVenda;
            set => SetProperty(ref _dataDaVenda, value);
        }
        public DateTime DataDoPedido
        {
            get => _dataDoPedido;
            set => SetProperty(ref _dataDoPedido, value);
        }
        public int? NumeroDaMesa
        {
            get => _numeroDaMesa;
            set => SetProperty(ref _numeroDaMesa, value);
        }
        public int? ClienteId
        {
            get => _clienteid;
            set => SetProperty(ref _clienteid, value);
        }
        public int EstadoId
        {
            get => _estadoid;
            set => SetProperty(ref _estadoid, value);
        }

        //Parte Web
        private decimal _valorEntregue;
        public decimal ValorEntregue
        {
            get => _valorEntregue;
            set => SetProperty(ref _valorEntregue, value);
        }

        public Cliente Cliente { get; set; }
        public Estado Estado { get; set; }
        public ICollection<Item> Item { get; set; }
        public Morada Morada { get; set; }
    }
}
