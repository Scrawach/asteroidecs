using CodeBase.Core.Extensions;
using Leopotam.EcsLite;
using UnityEngine;

namespace CodeBase.Engine.MonoLinks.Base
{
    public abstract class MonoLink<TEntity> : MonoLinkBase where TEntity : struct
    {
        [SerializeField] protected TEntity Value;

        public override void Resolve(EcsWorld world, int entity) =>
            world.AddComponent(entity, Value);
    }
}