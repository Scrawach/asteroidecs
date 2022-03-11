using Leopotam.EcsLite;

namespace CodeBase.Core.Extensions
{
    public static class EcsWorldExtensions
    {
        public static void NewEntityWith<TComponent>(this EcsWorld world) where TComponent : struct
        {
            var entity = world.NewEntity();
            var pool = world.GetPool<TComponent>();
            pool.Add(entity);
        }

        public static void NewEntityWith<TComponent>(this EcsWorld world, TComponent value) where TComponent : struct
        {
            var entity = world.NewEntity();
            world.AddComponent(entity, value);
        }

        public static void AddComponent<TComponent>(this EcsWorld world, int id, TComponent component)
            where TComponent : struct
        {
            var pool = world.GetPool<TComponent>();
            pool.Add(id);
            ref var reference = ref pool.Get(id);
            reference = component;
        }
    }
}