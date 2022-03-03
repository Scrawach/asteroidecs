using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Services;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.MovementSystems
{
    public class MoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Movement> _movables = default;
        private readonly ITime _time;

        public MoveSystem(ITime time) => 
            _time = time;

        public void Run()
        {
            foreach (var index in _movables)
            {
                ref var entity = ref _movables.GetEntity(index);
                ref var position = ref entity.Get<Position>();
                
                var direction = entity.Get<Movement>().Direction;
                var speed = entity.Get<MovementSpeed>().Value;
                
                var velocity = direction * speed;
                position.Value += velocity * _time.DeltaFrame;
            }
        }
    }
}