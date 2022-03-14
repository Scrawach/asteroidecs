using CodeBase.Core.Common;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.SpawnerSystems.Interval
{
    public interface ISpawnPositionPolicy
    {
        Vector2Data SpawnPosition(EcsWorld world);
    }
}