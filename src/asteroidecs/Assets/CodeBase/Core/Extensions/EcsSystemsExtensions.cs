using Leopotam.EcsLite;

namespace CodeBase.Core.Extensions
{
    public static class EcsSystemsExtensions
    {
        public static IEcsSystems DeleteHere<TComponent>(this IEcsSystems systems) where TComponent : struct =>
            systems.Add(new DeleteHereSystem<TComponent>());

        private class DeleteHereSystem<TComponent> : IEcsRunSystem
            where TComponent : struct
        {
            public void Run(IEcsSystems systems)
            {
                var world = systems.GetWorld();
                var filter = world.Filter<TComponent>().End();
                var pool = world.GetPool<TComponent>();
                foreach (var index in filter) pool.Del(index);
            }
        }
    }
}