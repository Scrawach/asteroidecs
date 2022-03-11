using System;
using CodeBase.Core.Gameplay.Components.Lifecycle;
using CodeBase.Engine.MonoLinks.Base;
using Leopotam.EcsLite;

namespace CodeBase.Engine.MonoLinks
{
    public class MonoDestroyable : MonoLink<Destroyable>, IDestroyable
    {
        public event Action Destroyed;
        
        public override void Resolve(EcsWorld world, int entity)
        {
            Value = new Destroyable { Link = this };
            base.Resolve(world, entity);
        }

        public void Destroy()
        {
            Destroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}