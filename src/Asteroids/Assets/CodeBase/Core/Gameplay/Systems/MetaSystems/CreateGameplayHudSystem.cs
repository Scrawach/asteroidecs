using CodeBase.Core.Gameplay.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Core.Gameplay.Systems.MetaSystems
{
    public class GameplayHudLifecycleSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly IUiFactory _uiFactory;

        public GameplayHudLifecycleSystem(IUiFactory uiFactory) => 
            _uiFactory = uiFactory;
        
        public void Init() => 
            _uiFactory.OpenGameplayHud();

        public void Destroy() => 
            _uiFactory.CloseGameplayHud();
    }
}