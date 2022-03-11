using CodeBase.Core.Gameplay.Components.Events;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public class SwapMovementDirection : IEnterTriggerStrategy
    {
        public void OnEnter(EcsWorld world, OnTriggerEnter enter)
        {
            //ref var first = ref enter.Sender.Get<Movement>();
            //ref var second = ref enter.Trigger.Get<Movement>();
            //var temp = second.Direction;

            //second.Direction = first.Direction;
            //first.Direction = temp;
        }
    }
}