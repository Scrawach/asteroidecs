using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public class DestroyTriggeredEntities : IEnterTriggerStrategy
    {
        public void OnEnter(OnTriggerEnter enter)
        {
            enter.Sender.Get<DestroyTag>();
            enter.Trigger.Get<DestroyTag>();
        }
    }
}