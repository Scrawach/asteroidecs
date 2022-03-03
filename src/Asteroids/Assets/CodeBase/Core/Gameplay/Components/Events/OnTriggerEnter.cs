using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Components.Events
{
    public struct OnTriggerEnter
    {
        public EcsEntity Sender;
        public EcsEntity Trigger;
    }
}