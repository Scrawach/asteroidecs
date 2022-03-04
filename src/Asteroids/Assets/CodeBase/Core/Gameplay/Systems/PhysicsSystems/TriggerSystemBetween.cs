using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems
{
    public class TriggerSystemBetween<TSender, TTarget> : IEcsRunSystem
        where TSender : struct 
        where TTarget : struct
    {
        private readonly EcsFilter<OnTriggerEnter> _triggers = default;
        private readonly IEnterTriggerStrategy _strategy;

        public TriggerSystemBetween(IEnterTriggerStrategy strategy) => 
            _strategy = strategy;

        public void Run()
        {
            foreach (var index in _triggers)
            {
                var enter = _triggers.Get1(index);
                
                if (IsCollideBetween<TSender, TTarget>(enter) || 
                    IsCollideBetween<TTarget, TSender>(enter))
                    _strategy.OnEnter(enter);
            }
        }

        private bool IsCollideBetween<TEnterSender, TEnterTrigger>(OnTriggerEnter enter)
            where TEnterSender : struct where TEnterTrigger : struct =>
            enter.Sender.Has<TEnterSender>() && 
            enter.Trigger.Has<TEnterTrigger>();
    }
}