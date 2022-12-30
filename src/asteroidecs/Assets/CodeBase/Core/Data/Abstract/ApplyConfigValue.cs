using CodeBase.Core.Common;
using Leopotam.EcsLite;

namespace CodeBase.Core.Data.Abstract
{
    public abstract class ApplyConfigValue<TConfigComponent> : IApplyConfigValue
        where TConfigComponent : struct
    {
        private readonly IObjectConfigs _configs;

        protected ApplyConfigValue(IObjectConfigs configs) =>
            _configs = configs;

        public bool TryApply(int entity, EcsWorld world, ObjectId objectId)
        {
            var config = _configs.Get(objectId);
            if (OnHasValue(config) == false)
                return false;

            ref var componentReference = ref Get<TConfigComponent>(entity, world);
            OnApply(ref componentReference, config);
            return true;
        }

        protected abstract bool OnHasValue(ObjectConfig config);

        protected abstract void OnApply(ref TConfigComponent component, ObjectConfig config);

        private static ref TFindComponent Get<TFindComponent>(int entity, EcsWorld world) where TFindComponent : struct
        {
            var pool = world.GetPool<TFindComponent>();
            return ref pool.Get(entity);
        }
    }
}