using CodeBase.Engine.MonoLinks.Base;
using Leopotam.EcsLite;

namespace CodeBase.Engine.MonoLinks.Physics
{
    public abstract class PhysicsLinkBase : MonoLinkBase
    {
        protected EcsWorld World { get; private set; }
        protected int Entity { get; private set; }

        public override void Resolve(EcsWorld world, int entity)
        {
            World = world;
            Entity = entity;
        }
    }
}