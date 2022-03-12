using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public class ApplyKilledByPlayer : IEnterTriggerStrategy
    {
        public void OnEnter(EcsWorld world, int sender, int trigger)
        {
            world.AddComponent(sender, new KilledByPlayer());
            world.AddComponent(trigger, new KilledByPlayer());
        }
    }
}