using CodeBase.Core.Gameplay.Components.Lifecycle;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services.Time;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.LifecycleSystems
{
    public class LifecycleSystem : IEcsRunSystem
    {
        private readonly ITime _time;

        public LifecycleSystem(ITime time) =>
            _time = time;

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<Lifetime>().End();

            var lifetimes = world.GetPool<Lifetime>();
            var dead = world.GetPool<DestroyTag>();

            foreach (var index in filter)
            {
                ref var life = ref lifetimes.Get(index);
                life.Time -= _time.DeltaFrame;

                if (life.Time <= 0) dead.Add(index);
            }
        }
    }
}