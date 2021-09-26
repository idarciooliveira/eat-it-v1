namespace EAT.Infrastruture.WPF.Interface
{
    public interface IMethod
    {
        void OnStartup();
        void OnReload();
        void OnRemove();
        void OnClear();
        void OnModify();
        void OnSubmit();
        void OnSelect(object obj);
        void LoadCommands();
    }
}
