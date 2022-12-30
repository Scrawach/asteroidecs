using CodeBase.Core.Gameplay.Components.Lifecycle;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.LifecycleSystems
{
    public class TakeDamageSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<DamageRequest>().Inc<Health>().End();
            var requests = world.GetPool<DamageRequest>();
            var healths = world.GetPool<Health>();

            foreach (var index in filter)
            {
                ref var request = ref requests.Get(index);
                ref var health = ref healths.Get(index);
                health.Value -= request.Value;
                requests.Del(index);
            }
        }
    }
}