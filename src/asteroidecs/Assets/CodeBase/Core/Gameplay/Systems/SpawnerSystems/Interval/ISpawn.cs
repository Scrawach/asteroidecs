using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.SpawnerSystems.Interval
{
    public interface ISpawnStrategy
    {
        void Spawn(EcsWorld world);
    }
}