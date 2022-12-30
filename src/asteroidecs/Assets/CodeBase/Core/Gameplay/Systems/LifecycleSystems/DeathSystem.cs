using CodeBase.Core.Gameplay.Components.Lifecycle;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.LifecycleSystems
{
    public class DeathSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<Health>().End();
            var healths = world.GetPool<Health>();
            var destroys = world.GetPool<DestroyTag>();
            foreach (var index in filter)
            {
                ref var health = ref healths.Get(index);

                if (health.Value > 0)
                    continue;

                destroys.Add(index);
                healths.Del(index);
            }
        }
    }
}