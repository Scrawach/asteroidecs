using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Systems.SpawnerSystems;
using Leopotam.Ecs;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class SpawnSystems : ISystemBuilder
    {
        private readonly IFactory _factory;
        private readonly IGameScreen _gameScreen;
        private readonly ITime _time;
        private readonly IRandom _random;

        public SpawnSystems(IFactory factory, IGameScreen gameScreen, ITime time, IRandom random)
        {
            _factory = factory;
            _gameScreen = gameScreen;
            _time = time;
            _random = random;
        }

        public EcsSystems Build(EcsWorld world) =>
            new EcsSystems(world, nameof(SpawnSystems))
                .Add(new SpawnPlayer())
                .Add(new SpawnAsteroids(_time, _gameScreen, _random))
                .Add(new SpawnBullet())
                .Add(new SpawnSystem(_factory));
    }
}