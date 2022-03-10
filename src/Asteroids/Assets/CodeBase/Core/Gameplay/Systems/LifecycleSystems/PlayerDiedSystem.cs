using CodeBase.Core.Gameplay.Components.Meta;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.LifecycleSystems
{
    public class PlayerDiedSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = default;
        private readonly EcsFilter<PlayerTag, DestroyTag> _playerDeath = default;
        
        public void Run()
        {
            if (_playerDeath.IsEmpty())
                return;
            var newEntity = _world.NewEntity();
            newEntity.Get<GameOverEvent>();
        }
    }
}