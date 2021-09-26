using System.Collections.Generic;

namespace EAT.Models.Entities
{
    public sealed class Cliente : Entity
    {
        public Cliente()
        {
            Pedido = new HashSet<Pedido>();
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        private string _sobrenome;
        public string Sobrenome
        {
            get => _sobrenome;
            set => SetProperty(ref _sobrenome, value);
        }

        private string _telefone;
        public string Telefone
        {
            get => _telefone;
            set
            {
                if (_telefone != value)
                {
                    MyValidation.ValidateTelefone(value);
                    SetProperty(ref _telefone, value);
                }
            } 
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        private int _moradaid;
        public int MoradaId
        {
            get => _moradaid;
            set => SetProperty(ref _moradaid, value);
        }

        private string _nomeCompleto;
        public string NomeCompleto
        {
            get => ObterNomeCompleto();
            set => SetProperty(ref _nomeCompleto, value);
        }

        private string ObterNomeCompleto() => $"{Nome} {Sobrenome}";
        public Morada Morada { get; set; }
        public ClienteUsuario ClienteUsuario { get; set; }
        public ICollection<Pedido> Pedido { get; set; }
    }
}
