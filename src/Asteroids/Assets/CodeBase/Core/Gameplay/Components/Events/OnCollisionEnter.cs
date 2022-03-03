using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Components.Events
{
    public struct OnCollisionEnter
    {
        public EcsEntity Sender;
        public EcsEntity Collision;
    }
}