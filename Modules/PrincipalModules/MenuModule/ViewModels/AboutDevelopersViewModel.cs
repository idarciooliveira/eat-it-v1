namespace MenuModule.ViewModels
{
    public class AboutDevelopersViewModel : AboutBase
    {
        private string _developersInfor;
        public string DevelopersInfor
        {
            get => _developersInfor;
            set => SetProperty(ref _developersInfor, value);
        }
        public AboutDevelopersViewModel()
        {
            Titulo = "Sobre os Desenvolvedores da Plataforma EAT-IT";
            DevelopersInfor = StartUpDevelopersInfor();
        }
    }
}
