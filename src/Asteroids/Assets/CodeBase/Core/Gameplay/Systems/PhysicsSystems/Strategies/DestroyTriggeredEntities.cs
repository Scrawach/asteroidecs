using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public class DestroyTriggeredEntities : IEnterTriggerStrategy
    {
        public void OnEnter(EcsWorld world, OnTriggerEnter enter)
        {
            var dead = world.GetPool<DestroyTag>();
            dead.Add(enter.Sender);
            dead.Add(enter.Trigger);
        }
    }
}