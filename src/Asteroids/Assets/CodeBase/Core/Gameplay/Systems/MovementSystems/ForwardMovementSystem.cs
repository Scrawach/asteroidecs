using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.MovementSystems
{
    public class ForwardMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ForwardMovementTag, Rotation> _bullets = default;
        
        public void Run()
        {
            foreach (var index in _bullets)
            {
                ref var entity = ref _bullets.GetEntity(index);
                var rotation = _bullets.Get2(index);
                entity.Get<Movement>() = new Movement {Direction = rotation.Direction};
                entity.Del<ForwardMovementTag>();
            }
        }
    }
}