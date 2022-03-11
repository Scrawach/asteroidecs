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
                if (IsCollideBetween<TSender, TTarget>(world, enter) ||
                    IsCollideBetween<TTarget, TSender>(world, enter))
                    _strategy.OnEnter(world, enter);
            }
        }

        private bool IsCollideBetween<TEnterSender, TEnterTrigger>(EcsWorld world, OnTriggerEnter enter)
            where TEnterSender : struct where TEnterTrigger : struct
        {
            var senders = world.GetPool<TEnterSender>();
            var triggers = world.GetPool<TEnterTrigger>();

            return senders.Has(enter.Sender) &&
                   triggers.Has(enter.Trigger);
        }
    }
}