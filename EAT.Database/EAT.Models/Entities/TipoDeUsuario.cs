using System.Collections.Generic;

namespace EAT.Models.Entities
{
    public sealed class TipoDeUsuario : Entity
    {
        public TipoDeUsuario() => Funcionario = new HashSet<Funcionario>();

        private string _funcao;
        public string Funcao
        {
            get => _funcao;
            set => SetProperty(ref _funcao, value);
        }
        public ICollection<Funcionario> Funcionario { get; set; }
    }
}
