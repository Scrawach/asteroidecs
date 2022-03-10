namespace CodeBase.Core.Gameplay.Services
{
    public interface IUiFactory
    {
        void OpenGameplayHud();
        void CloseGameplayHud();
        void OpenGameOverWindow();
        void CloseGameOverWindow();
    }
}