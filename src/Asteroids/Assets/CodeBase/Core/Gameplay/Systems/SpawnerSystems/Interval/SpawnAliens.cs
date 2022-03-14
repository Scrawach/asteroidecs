using CodeBase.Core.Common;
using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.SpawnerSystems.Interval
{
    public class SpawnAliens : ISpawnStrategy
    {
        private readonly ISpawnPositionPolicy _spawnPositionPolicy;

        public SpawnAliens(ISpawnPositionPolicy spawnPositionPolicy) =>
            _spawnPositionPolicy = spawnPositionPolicy;
        
        public void Spawn(EcsWorld world)
        {
            var filter = world.Filter<PlayerTag>().End();
            if (filter.GetEntitiesCount() < 1) return;
            world.NewEntityWith(new SpawnInfo(ObjectId.Alien, _spawnPositionPolicy.SpawnPosition(world), new Vector2Data(0, 0)));
        }
    }
}