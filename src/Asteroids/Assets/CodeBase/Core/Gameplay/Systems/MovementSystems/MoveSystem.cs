using CodeBase.Core.Gameplay.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Core.Gameplay.Systems.MovementSystems
{
    public class MoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Movement> _movables = default;
        
        public void Run()
        {
            foreach (var index in _movables)
            {
                ref var entity = ref _movables.GetEntity(index);
                ref var position = ref entity.Get<Position>();
                var movement = entity.Get<Movement>();
                position.Value += movement.Direction * movement.Speed * Time.deltaTime;
            }
        }
    }
}