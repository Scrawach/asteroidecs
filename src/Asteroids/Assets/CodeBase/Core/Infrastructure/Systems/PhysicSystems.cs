using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Systems.PhysicsSystems;
using CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies;
using CodeBase.Core.Infrastructure.Systems.Abstract;
using Leopotam.EcsLite;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class PhysicSystems : ISystemConnect
    {
        public EcsSystems ConnectTo(EcsSystems systems) =>
            systems
                .Add(new TriggerSystemBetween<PlayerTag, AsteroidTag>(new DestroyTriggeredEntities()))
                .Add(new TriggerSystemBetween<AsteroidTag, BulletTag>(new PlayerDestroyTriggeredEntities()))
                .Add(new TriggerSystemBetween<AsteroidTag, AsteroidTag>(new SumAndInverseMovementDirection()))
                .DeleteHere<OnTriggerEnter>();
    }
}