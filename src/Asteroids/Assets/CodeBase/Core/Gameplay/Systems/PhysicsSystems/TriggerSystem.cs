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
                var enter = entity.Get<OnTriggerEnter>();

                if (IsCollideBetween<AsteroidTag, BulletTag>(enter) ||
                    IsCollideBetween<PlayerTag, AsteroidTag>(enter)) 
                    DestroyBoth(enter);
            }
        }

        private bool IsCollideBetween<TSender, TTrigger>(OnTriggerEnter enter)
            where TSender : struct where TTrigger : struct =>
            enter.Sender.Has<TSender>() && 
            enter.Trigger.Has<TTrigger>();

        private void DestroyBoth(OnTriggerEnter enter)
        {
            Destroy(enter.Sender);
            Destroy(enter.Trigger);
        }

        private void Destroy(EcsEntity entity) => 
            entity.Get<DestroyTag>() = new DestroyTag();
    }
}