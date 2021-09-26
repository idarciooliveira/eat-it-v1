namespace EAT.Models.Entities
{
    public sealed class Funcionario : Entity
    {

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

        private string _nomeDeUsuario;
        public string NomeDeUsuario
        {
            get => _nomeDeUsuario;
            set => SetProperty(ref _nomeDeUsuario, value);
        }

        private string _senhaDeUsuario;
        public string SenhaDeUsuario
        {
            get => _senhaDeUsuario;
            set => SetProperty(ref _senhaDeUsuario, value);
        }

        private int _tipoDeUsuarioid;
        public int TipoDeUsuarioId
        {
            get => _tipoDeUsuarioid;
            set => SetProperty(ref _tipoDeUsuarioid, value);
        }

        private string _nomeCompleto;
        public string NomeCompleto
        {
            get => ObterNomeCompleto();
            set => SetProperty(ref _nomeCompleto, value);
        }

        private string ObterNomeCompleto() => $"{Nome} {Sobrenome}";
        public TipoDeUsuario TipoDeUsuario { get; set; }
    }
}
