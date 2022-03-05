using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public class PlayerDestroyTriggeredEntities : IEnterTriggerStrategy
    {
        public void OnEnter(OnTriggerEnter enter)
        {
            Apply<KilledByPlayer>(enter);
            Apply<DestroyTag>(enter);
        }

        private void Apply<TComponent>(OnTriggerEnter enter) where TComponent : struct
        {
            enter.Sender.Get<TComponent>();
            enter.Trigger.Get<TComponent>();
        }
    }
}