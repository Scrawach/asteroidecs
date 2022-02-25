using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Engine.MonoLinks.Base
{
    public abstract class MonoLink<TEntity> : MonoLinkBase where TEntity : struct
    {
        [SerializeField]
        private TEntity _value = default;
        
        public override void Resolve(ref EcsEntity entity) => 
            entity.Get<TEntity>() = _value;
    }
}