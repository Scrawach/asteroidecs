using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public class PlayerDestroyTriggeredEntities : IEnterTriggerStrategy
    {
        public void OnEnter(EcsWorld world, OnTriggerEnter enter)
        {
            Apply<KilledByPlayer>(world, enter);
            Apply<DestroyTag>(world, enter);
        }

        private void Apply<TComponent>(EcsWorld world, OnTriggerEnter enter) where TComponent : struct
        {
            var dead = world.GetPool<TComponent>();
            dead.Add(enter.Sender);
            dead.Add(enter.Trigger);
        }
    }
}