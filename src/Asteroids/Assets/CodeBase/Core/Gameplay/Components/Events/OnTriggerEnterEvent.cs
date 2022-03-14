using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Components.Events
{
    public struct OnTriggerEnterEvent
    {
        public EcsPackedEntity Sender;
        public EcsPackedEntity Trigger;
    }
}