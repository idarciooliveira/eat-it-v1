using System.Collections.Generic;

namespace EAT.Models.Entities
{
    public sealed class Morada : Entity
    {
        public Morada()
        {
            Cliente = new HashSet<Cliente>();
            Pedido = new HashSet<Pedido>();
        }
        private string _bloco;
        public string Bloco
        {
            get => _bloco;
            set => SetProperty(ref _bloco, value);
        }
        private int _edificio;
        public int Edificio
        {
            get => _edificio;
            set => SetProperty(ref _edificio, value);
        }
        private int _numeroDaPorta;
        public int NumeroDaPorta
        {
            get => _numeroDaPorta;
            set => SetProperty(ref _numeroDaPorta, value);
        }

        private string _moradaCompleta;
        public string MoradaCompleta
        {
            get => ObterMoradaCompleta();
            set => SetProperty(ref _moradaCompleta, value);
        }
        private string ObterMoradaCompleta()=> $"Edificio {Bloco}{Edificio} Porta {Bloco} {NumeroDaPorta}";
        public ICollection<Cliente> Cliente { get; set; }
        public ICollection<Pedido> Pedido { get; set; }
    }
}
