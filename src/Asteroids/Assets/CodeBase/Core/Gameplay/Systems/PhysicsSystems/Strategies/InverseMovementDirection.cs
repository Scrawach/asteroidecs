using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Moves;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public class InverseMovementDirection : IEnterTriggerStrategy
    {
        public void OnEnter(EcsWorld world, OnTriggerEnter enter)
        {
            //Inverse(ref enter.Sender.Get<Movement>());
            //Inverse(ref enter.Trigger.Get<Movement>());
        }

        private void Inverse(ref Movement movement) => movement.Direction *= -1f;
    }
}