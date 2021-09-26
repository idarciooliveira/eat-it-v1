using EAT.Infrastruture.WPF.Models;
using EAT.Models.Entities;
using Prism.Regions;

namespace StatusModule.ViewModels
{
    public class StatusbarViewModel : ViewModelBase
    {
        private Funcionario _funcionario;
        public Funcionario Funcionario
        {
            get => _funcionario; set => SetProperty(ref _funcionario, value);
        }
        private string _previlegio;
        public string Previlegio
        {
            get => _previlegio; set => SetProperty(ref _previlegio, value);
        }

        public StatusbarViewModel() => Funcionario = new Funcionario();

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            var funcionario = navigationContext.Parameters[nameof(Funcionario)] as Funcionario;
            if (funcionario == null) return;
            SimpleMapper.Map(funcionario,Funcionario);
            Previlegio = Funcionario.TipoDeUsuario.Funcao;
        }
    }
}
