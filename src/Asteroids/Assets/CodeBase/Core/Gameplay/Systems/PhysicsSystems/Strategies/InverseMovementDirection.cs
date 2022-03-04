using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Moves;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public class InverseMovementDirection : IEnterTriggerStrategy
    {
        public void OnEnter(OnTriggerEnter enter)
        {
            Inverse(ref enter.Sender.Get<Movement>());
            Inverse(ref enter.Trigger.Get<Movement>());
        }

        private void Inverse(ref Movement movement) => 
            movement.Direction *= -1f;
    }
}