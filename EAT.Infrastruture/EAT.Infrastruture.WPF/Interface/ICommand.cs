using Prism.Commands;

namespace EAT.Infrastruture.WPF.Interface
{
    public interface ICommand
    {
        DelegateCommand SubmitCommand { set; get; }
        DelegateCommand RemoveCommand { set; get; }
        DelegateCommand ClearCommand { set; get; }
        DelegateCommand ModifyCommand { set; get; }
        DelegateCommand<object> SelectCommand { set; get; }
    }
}
