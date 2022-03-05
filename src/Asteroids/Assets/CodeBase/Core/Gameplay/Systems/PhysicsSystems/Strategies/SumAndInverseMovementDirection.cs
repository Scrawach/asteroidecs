using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Moves;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public class SumAndInverseMovementDirection : IEnterTriggerStrategy
    {
        public void OnEnter(OnTriggerEnter enter)
        {
            ref var first = ref enter.Sender.Get<Movement>();
            ref var second = ref enter.Trigger.Get<Movement>();

            first.Direction = (first.Direction + second.Direction).Normalize();
            second.Direction = first.Direction * -1f;
        }
    }
}