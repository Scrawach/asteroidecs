using CodeBase.Core.Gameplay.Components;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.SpawnerSystems
{
    public class SpawnBullet : IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld = default;
        private readonly EcsFilter<ShootPoint> _shootPoints = default;

        public void Run()
        {
            foreach (var index in _shootPoints)
            {
                var point = _shootPoints.Get1(index);
                var spawnBullet = _ecsWorld.NewEntity();
                spawnBullet.Get<SpawnInfo>() = new SpawnInfo(point.Bullet, point.Position, point.Direction);
            }
        }
    }
}