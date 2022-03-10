using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.InputSystems
{
    public class KeyboardInputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = default;
        private readonly EcsFilter<PlayerTag> _players = default;
        private readonly IInput _input;

        public KeyboardInputSystem(IInput input) => 
            _input = input;

        public void Run()
        {
            if (_input.IsFireButtonPressed())
            {
                var entity = _world.NewEntity();
                entity.Get<FireButtonPressedTag>();
            }
            
            foreach (var index in _players)
            {
                ref var entity = ref _players.GetEntity(index);
                ref var movement = ref entity.Get<Movement>();
                movement.Direction = _input.MovementDirection.Normalize();
            }
        }
    }
}