using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Services.Time;
using CodeBase.Core.Gameplay.Systems.SpawnerSystems;
using CodeBase.Core.Gameplay.Systems.SpawnerSystems.Interval;
using CodeBase.Core.Infrastructure.Systems.Abstract;
using Leopotam.EcsLite;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class SpawnSystems : IConnectableSystem
    {
        private readonly IFactory _factory;
        private readonly ISpawnPositionPolicy _onScreenPerimeter;
        private readonly ITime _time;

        public SpawnSystems(IFactory factory, IGameScreen gameScreen, ITime time, IRandom random)
        {
            _factory = factory;
            _time = time;
            _onScreenPerimeter = new RandomPointOnGameScreenPerimeter(gameScreen, random);
        }

        public EcsSystems ConnectTo(EcsSystems systems) =>
            systems
                .Add(new SpawnPlayer())
                .Add(new IntervalSpawn(_time, 3f, new SpawnAliens(_onScreenPerimeter)))
                .Add(new IntervalSpawn(_time, 0.5f, new SpawnAsteroids(_onScreenPerimeter)))
                .Add(new SpawnBullet())
                .Add(new SpawnSystem(_factory));
    }
}