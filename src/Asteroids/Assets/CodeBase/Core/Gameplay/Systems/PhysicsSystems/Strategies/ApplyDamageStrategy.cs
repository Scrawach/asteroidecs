using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components.Lifecycle;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public class ApplyDamageStrategy : IEnterTriggerStrategy
    {
        public void OnEnter(EcsWorld world, int sender, int trigger)
        {
            var damages = world.GetPool<Damage>();
            world.AddComponent(sender, new DamageRequest { Value = damages.Get(trigger).Value });
            world.AddComponent(trigger, new DamageRequest { Value = damages.Get(sender).Value });
        }
    }
}