using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Components.Tags.Objects;
using CodeBase.Core.Gameplay.Systems.PhysicsSystems;
using CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies;
using CodeBase.Core.Infrastructure.Systems.Abstract;
using Leopotam.EcsLite;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class PhysicSystems : IConnectableSystem
    {
        public EcsSystems ConnectTo(EcsSystems systems) =>
            systems
                .DeleteHere<KilledByPlayerTag>()
                .DeleteHere<PhysicsAlreadyCalculatedTag>()
                .Add(new TriggerSystemBetween<BulletTag, AsteroidTag>(new CombineStrategies(new ApplyDamageStrategy(),
                    new ApplyKilledByPlayer())))
                .Add(new TriggerSystemBetween<BulletTag, AlienTag>(new CombineStrategies(new ApplyDamageStrategy(),
                    new ApplyKilledByPlayer())))
                .Add(new TriggerSystemBetween<AlienTag, AsteroidTag>(new ApplyDamageStrategy()))
                .Add(new TriggerSystemBetween<AlienTag, PlayerTag>(new DestroyTriggeredEntities()))
                .Add(new TriggerSystemBetween<AsteroidTag, AsteroidTag>(new SumAndInverseMovementDirection()))
                .Add(new TriggerSystemBetween<AsteroidTag, PlayerTag>(new ApplyDamageStrategy()))
                .DeleteHere<OnTriggerEnterRequest>();
    }
}