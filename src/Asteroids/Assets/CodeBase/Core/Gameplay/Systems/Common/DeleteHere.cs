using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.Common
{
    public class DeleteHere<TComponent> : IEcsRunSystem
        where TComponent : struct
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<TComponent>().End();
            foreach (var index in filter)
                world.DelEntity(index);
        }
    }
}