using CodeBase.Core.Common;
using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.SpawnerSystems.Interval
{
    public class SpawnAsteroids : ISpawnStrategy
    {
        private readonly ISpawnPositionPolicy _spawnPositionPolicy;

        public SpawnAsteroids(ISpawnPositionPolicy spawnPositionPolicy) =>
            _spawnPositionPolicy = spawnPositionPolicy;

        public void Spawn(EcsWorld world)
        {
            var spawnPoint = _spawnPositionPolicy.SpawnPosition(world);

            if (IsPlayerExist(world, out var player))
                return;

            var positions = world.GetPool<Position>();
            var firstPlayer = player.GetRawEntities()[0];

            world.NewEntityWith
            (
                new SpawnInfo
                (
                    ObjectId.Asteroid,
                    spawnPoint,
                    (positions.Get(firstPlayer).Value - spawnPoint).Normalize()
                )
            );
        }

        private static bool IsPlayerExist(EcsWorld world, out EcsFilter player)
        {
            player = world.Filter<PlayerTag>().End();
            return player.GetEntitiesCount() < 1;
        }
    }
}