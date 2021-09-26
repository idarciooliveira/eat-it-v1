using System;
using Prism.Mvvm;
using Prism.Regions;

namespace EAT.Infrastruture.WPF.Models
{
    public class ViewModelBase : BindableBase, IConfirmNavigationRequest
    {
        private string _textoDePesquisa;
        public string TextoDePesquisa
        {
            get => _textoDePesquisa;
            set => SetProperty(ref _textoDePesquisa, value);
        }
        private string _titulo;
        public string Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }
        public virtual void OnNavigatedTo(NavigationContext navigationContext) { }
        public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;
        public virtual void OnNavigatedFrom(NavigationContext navigationContext) { }
        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
            => continuationCallback.Invoke(true);

    }
}
