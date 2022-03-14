using CodeBase.Core.Common;
using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.SpawnerSystems
{
    public class SpawnAliens : IEcsRunSystem
    {
        private readonly ITime _time;
        private float _elapsedTime;
        private float _respawnTime = 1f;

        public SpawnAliens(ITime time) =>
            _time = time;
        
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<PlayerTag>().End();

            if (filter.GetEntitiesCount() < 1)
                return;
            
            _elapsedTime += _time.DeltaFrame;
            if (_respawnTime <= _elapsedTime)
            {
                SpawnAlien(world);
                _elapsedTime -= _respawnTime;
            }
        }

        private void SpawnAlien(EcsWorld world) =>
            world.NewEntityWith(new SpawnInfo(ObjectId.Alien, new Vector2Data(0, 0), new Vector2Data(0, 0)));
    }
}