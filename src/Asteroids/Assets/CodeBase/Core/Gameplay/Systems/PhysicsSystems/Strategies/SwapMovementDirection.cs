using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Moves;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public class SwapMovementDirection : IEnterTriggerStrategy
    {
        public void OnEnter(OnTriggerEnter enter)
        {
            ref var first = ref enter.Sender.Get<Movement>();
            ref var second = ref enter.Trigger.Get<Movement>();
            var temp = second.Direction;

            second.Direction = first.Direction;
            first.Direction = temp;
        }
    }
}