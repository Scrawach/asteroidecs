using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Systems.LifecycleSystems;
using CodeBase.Core.Gameplay.Systems.MovementSystems;
using Leopotam.Ecs;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class LifecycleSystems : ISystemBuilder
    {
        private readonly ITime _time;
        private readonly IGameScreen _gameScreen;

        public LifecycleSystems(ITime time, IGameScreen gameScreen)
        {
            _time = time;
            _gameScreen = gameScreen;
        }
        
        public EcsSystems Build(EcsWorld world) =>
            new EcsSystems(world, nameof(LifecycleSystems))
                .Add(new LifecycleSystem(_time))
                .Add(new KillOutOfBorderObjects(_gameScreen))
                .Add(new DestroySystem())
                .OneFrame<DestroyTag>();
    }
}