using System;
using CodeBase.Engine.MonoLinks.Base;
using CodeBase.Engine.Services.AssetManagement.Pool;
using Leopotam.EcsLite;

namespace CodeBase.Engine.MonoLinks
{
    public class MonoDestroyable : MonoLinkBase, IPoolObject
    {
        private Pool _pool;
        private EcsPackedEntityWithWorld _entityWithWorld;

        public event Action Destroyed;

        public void Register(Pool pool) =>
            _pool = pool;

        public override void Resolve(EcsWorld world, int entity) =>
            _entityWithWorld = world.PackEntityWithWorld(entity);

        private void Update()
        {
            if (EntityDied()) 
                Destroy();
        }

        private bool EntityDied() =>
            _entityWithWorld.Unpack(out var world, out var entity) == false;

        private void Destroy()
        {
            Destroyed?.Invoke();
            _pool.Push(gameObject);
        }
    }
}