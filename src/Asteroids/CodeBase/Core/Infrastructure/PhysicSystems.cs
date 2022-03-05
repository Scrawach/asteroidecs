using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Systems.PhysicsSystems;
using CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies;
using Leopotam.Ecs;

namespace CodeBase.Core
{
    public class PhysicSystems : ISystemBuilder
    {
        public EcsSystems Build(EcsWorld world) =>
            new EcsSystems(world, nameof(PhysicSystems))
                .Add(new TriggerSystemBetween<PlayerTag, AsteroidTag>(new DestroyTriggeredEntities()))
                .Add(new TriggerSystemBetween<AsteroidTag, BulletTag>(new PlayerDestroyTriggeredEntities()))
                .Add(new TriggerSystemBetween<AsteroidTag, AsteroidTag>(new SumAndInverseMovementDirection()))
                .OneFrame<OnTriggerEnter>();
    }
}