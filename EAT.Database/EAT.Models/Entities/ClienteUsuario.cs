namespace EAT.Models.Entities
{
    public class ClienteUsuario : Entity
    {

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

        public virtual Cliente Cliente { get; set; }
        public virtual TipoDeUsuario TipoDeUsuario { get; set; }

    }
}
