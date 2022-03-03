using CodeBase.Engine.MonoLinks.Base;
using Leopotam.Ecs;

namespace CodeBase.Engine.MonoLinks.Physics
{
    public abstract class PhysicsLinkBase : MonoLinkBase
    {
        protected EcsEntity Entity { get; private set; }

        public override void Resolve(ref EcsEntity entity) => 
            Entity = entity;
    }
}