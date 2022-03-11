using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Moves;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public class SumAndInverseMovementDirection : IEnterTriggerStrategy
    {
        public void OnEnter(EcsWorld world, OnTriggerEnter enter)
        {
            var movements = world.GetPool<Movement>();
            ref var senderMovement = ref movements.Get(enter.Sender);
            ref var triggerMovement = ref movements.Get(enter.Trigger);

            senderMovement.Direction = (senderMovement.Direction + triggerMovement.Direction).Normalize();
            triggerMovement.Direction = senderMovement.Direction * -1f;
        }
    }
}