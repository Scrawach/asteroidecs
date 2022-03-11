using Leopotam.EcsLite;
using UnityEngine;

namespace CodeBase.Engine.MonoLinks.Base
{
    public abstract class MonoLink<TEntity> : MonoLinkBase where TEntity : struct
    {
        [SerializeField] protected TEntity Value;

        public override void Resolve(EcsWorld world, int entity)
        {
            var pool = world.GetPool<TEntity>();
            pool.Add(entity);

            ref var component = ref pool.Get(entity);
            component = Value;
        }
    }
}