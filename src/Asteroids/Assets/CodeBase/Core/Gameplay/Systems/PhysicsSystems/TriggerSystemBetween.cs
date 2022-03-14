using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems
{
    public class TriggerSystemBetween<TSender, TTarget> : IEcsRunSystem
        where TSender : struct
        where TTarget : struct
    {
        private readonly IEnterTriggerStrategy _strategy;

        public TriggerSystemBetween(IEnterTriggerStrategy strategy) =>
            _strategy = strategy;

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<OnTriggerEnter>().End();

            var events = world.GetPool<OnTriggerEnter>();
            foreach (var index in filter)
            {
                ref var enter = ref events.Get(index);

                if (UnpackEvent(enter, world, out var sender, out var trigger))
                    if (IsCollideBetween<TSender, TTarget>(world, sender, trigger) ||
                        IsCollideBetween<TTarget, TSender>(world, sender, trigger))
                        _strategy.OnEnter(world, sender, trigger);
            }
        }

        private static bool UnpackEvent(OnTriggerEnter enter, EcsWorld world, out int sender, out int trigger)
        {
            var isUnpackSender = enter.Sender.Unpack(world, out sender);
            var isUnpackTrigger = enter.Trigger.Unpack(world, out trigger);
            return isUnpackSender && isUnpackTrigger;
        }

        private bool IsCollideBetween<TEnterSender, TEnterTrigger>(EcsWorld world, int sender, int trigger)
            where TEnterSender : struct where TEnterTrigger : struct
        {
            var senders = world.GetPool<TEnterSender>();
            var triggers = world.GetPool<TEnterTrigger>();

            return senders.Has(sender) &&
                   triggers.Has(trigger);
        }
    }
}