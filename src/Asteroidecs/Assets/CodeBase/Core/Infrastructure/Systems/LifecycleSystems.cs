using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Systems.LifecycleSystems;
using CodeBase.Core.Infrastructure.Systems.Abstract;
using Leopotam.EcsLite;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class LifecycleSystems : IConnectableSystem
    {
        private readonly IGameScreen _gameScreen;
        private readonly ITime _time;

        public LifecycleSystems(ITime time, IGameScreen gameScreen)
        {
            _time = time;
            _gameScreen = gameScreen;
        }

        public EcsSystems ConnectTo(EcsSystems systems) =>
            systems
                .Add(new LifecycleSystem(_time))
                .Add(new KillOutOfBorderObjects(_gameScreen))
                .Add(new PlayerDiedSystem())
                .Add(new TakeDamageSystem())
                .Add(new DeathSystem());
    }
}