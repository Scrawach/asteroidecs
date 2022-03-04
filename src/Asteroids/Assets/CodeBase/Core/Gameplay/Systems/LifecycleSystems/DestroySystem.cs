using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.LifecycleSystems
{
    public class DestroySystem : IEcsRunSystem
    {
        private readonly EcsFilter<DestroyTag, EngineBody> _objects = default;
        
        public void Run()
        {
            foreach (var index in _objects)
            {
                ref var entity = ref _objects.GetEntity(index);
                var body = _objects.Get2(index);
                body.Body.Destroy();
                entity.Destroy();
            }
        }
    }
}