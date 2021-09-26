using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuModule.ViewModels
{
    public class AboutPlataformViewModel : AboutBase
    {
        private string _aboutPlataform;
        public string AboutPlataform
        {
            get => _aboutPlataform;
            set => SetProperty(ref _aboutPlataform, value);
        }
        public AboutPlataformViewModel()
        {
            Titulo = "Sobre a Plataforma EAT-IT";
            AboutPlataform = StartUpPlataformInfor();
        }
    }
}
