using System.Threading.Tasks;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Services
{
    public interface IUiFactory
    {
        Task OpenGameplayHud();
        Task OpenGameOverWindow(EcsWorld world);
        void CloseGameplayHud();
        void CloseGameOverWindow();
    }
}