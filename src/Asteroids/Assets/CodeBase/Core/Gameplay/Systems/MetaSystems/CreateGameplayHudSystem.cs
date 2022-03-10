using CodeBase.Core.Gameplay.Services;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.MetaSystems
{
    public class CreateGameplayHudSystem : IEcsInitSystem
    {
        private readonly IUiFactory _uiFactory;

        public CreateGameplayHudSystem(IUiFactory uiFactory) => 
            _uiFactory = uiFactory;
        
        public void Init() => 
            _uiFactory.CreateHud();
    }
}