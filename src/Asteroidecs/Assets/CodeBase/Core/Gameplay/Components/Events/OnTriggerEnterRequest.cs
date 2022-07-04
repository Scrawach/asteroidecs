using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Components.Events
{
    public struct OnTriggerEnterRequest
    {
        public EcsPackedEntity Sender;
        public EcsPackedEntity Trigger;
    }
}