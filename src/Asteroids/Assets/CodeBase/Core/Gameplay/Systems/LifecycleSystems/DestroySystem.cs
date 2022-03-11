using CodeBase.Core.Gameplay.Components.Lifecycle;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.LifecycleSystems
{
    public class DestroySystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world
                .Filter<DestroyTag>()
                .Inc<Destroyable>()
                .End();

            var bodies = world.GetPool<Destroyable>();

            foreach (var index in filter)
            {
                ref var body = ref bodies.Get(index);
                body.Link.Destroy();
                world.DelEntity(index);
            }
        }
    }
}