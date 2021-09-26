namespace EAT.Infrastruture.WPF.Interface
{
    public interface IBaseMethod
    {
        void InvokeCommands();
        bool CanRemove();
        bool CanSubmit();
        bool CanModify();
    }
}