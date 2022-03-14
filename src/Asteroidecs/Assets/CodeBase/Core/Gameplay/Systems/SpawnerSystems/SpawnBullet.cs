using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.SpawnerSystems
{
    public class SpawnBullet : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<ShootPoint>().End();

            var shootPoints = world.GetPool<ShootPoint>();
            foreach (var index in filter)
            {
                ref var point = ref shootPoints.Get(index);
                world.NewEntityWith(new SpawnInfo(point.Bullet, point.Position, point.Direction));
            }
        }
    }
}