using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Commands;

namespace LoginModule.ViewModels
{
    public class LoginBase : ViewModelBase
    {
        private Funcionario _funcionario;
        public Funcionario Funcionario
        {
            get => _funcionario; set => SetProperty(ref _funcionario, value);
        }

        public DelegateCommand EntrarCommand { get; set; }
        public DelegateCommand CancelarCommand { get; set; }

        public bool PodeEntrar() => !string.IsNullOrEmpty(Funcionario.SenhaDeUsuario) &&
                                    !string.IsNullOrEmpty(Funcionario.NomeDeUsuario);

    }
}