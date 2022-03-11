using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Systems.SpawnerSystems;
using CodeBase.Core.Infrastructure.Systems.Abstract;
using Leopotam.EcsLite;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class SpawnSystems : IConnectableSystem
    {
        private readonly IFactory _factory;
        private readonly IGameScreen _gameScreen;
        private readonly IRandom _random;
        private readonly ITime _time;

        public SpawnSystems(IFactory factory, IGameScreen gameScreen, ITime time, IRandom random)
        {
            _factory = factory;
            _gameScreen = gameScreen;
            _time = time;
            _random = random;
        }

        public EcsSystems ConnectTo(EcsSystems systems) =>
            systems
                .Add(new SpawnPlayer())
                .Add(new SpawnAsteroids(_time, _gameScreen, _random))
                .Add(new SpawnBullet())
                .Add(new SpawnSystem(_factory));
    }
}