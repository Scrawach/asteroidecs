using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems
{
    public class TriggerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<OnTriggerEnter> _triggers = default;
        
        public void Run()
        {
            foreach (var index in _triggers)
            {
                ref var entity = ref _triggers.GetEntity(index);
                var trigger = entity.Get<OnTriggerEnter>();

                if (trigger.Sender.Has<PlayerTag>())
                {
                    /* TODO: player trigger with something */
                }
            }
        }
    }
}