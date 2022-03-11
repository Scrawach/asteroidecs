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
                .Inc<EngineBody>()
                .End();

            var bodies = world.GetPool<EngineBody>();

            foreach (var index in filter)
            {
                ref var body = ref bodies.Get(index);
                body.Body.Destroy();
                world.DelEntity(index);
            }
        }
    }
}