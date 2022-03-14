using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public class DestroyTriggeredEntities : IEnterTriggerStrategy
    {
        public void OnEnter(EcsWorld world, int sender, int trigger)
        {
            var dead = world.GetPool<DestroyTag>();
            dead.Add(sender);
            dead.Add(trigger);
        }
    }
}