using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public class PlayerDestroyTriggeredEntities : IEnterTriggerStrategy
    {
        public void OnEnter(EcsWorld world, int sender, int trigger)
        {
            Apply<KilledByPlayer>(world, sender, trigger);
            Apply<DestroyTag>(world, sender, trigger);
        }

        private void Apply<TComponent>(EcsWorld world, int sender, int trigger) where TComponent : struct
        {
            var dead = world.GetPool<TComponent>();
            dead.Add(sender);
            dead.Add(trigger);
        }
    }
}