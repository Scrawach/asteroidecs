using CodeBase.Core.Gameplay.Services;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.MetaSystems
{
    public class GameplayHudLifecycleSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly IUiFactory _uiFactory;

        public GameplayHudLifecycleSystem(IUiFactory uiFactory) =>
            _uiFactory = uiFactory;

        public void Destroy(IEcsSystems systems) =>
            _uiFactory.CloseGameplayHud();

        public void Init(IEcsSystems systems) =>
            _uiFactory.OpenGameplayHud();
    }
}