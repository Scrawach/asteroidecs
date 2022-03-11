using CodeBase.Core.Gameplay.Components;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.SpawnerSystems
{
    public class RemoveShootPoints : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<ShootPoint>().End();
            foreach (var index in filter)
                world.DelEntity(index);
        }
    }
}