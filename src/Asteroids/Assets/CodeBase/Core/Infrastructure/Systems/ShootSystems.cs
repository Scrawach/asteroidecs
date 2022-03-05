using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Systems.ShootSystems;
using Leopotam.Ecs;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class ShootSystems : ISystemBuilder
    {
        public EcsSystems Build(EcsWorld world) =>
            new EcsSystems(world, nameof(ShootSystems))
                .OneFrame<ShootPoint>()
                .Add(new PlayerShoot());
    }
}