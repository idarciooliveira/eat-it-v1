using Prism.Mvvm;

namespace EAT.UI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "EAT-IT v4 Application";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}
