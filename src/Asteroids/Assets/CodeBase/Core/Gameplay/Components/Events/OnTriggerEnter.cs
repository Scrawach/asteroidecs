using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Components.Events
{
    public struct OnTriggerEnter
    {
        public EcsPackedEntity Sender;
        public EcsPackedEntity Trigger;
    }
}