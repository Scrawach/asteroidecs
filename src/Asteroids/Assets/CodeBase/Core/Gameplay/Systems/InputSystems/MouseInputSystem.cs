using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.InputSystems
{
    public class MouseInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag> _players = default;
        private readonly IInput _input = default;

        public MouseInputSystem(IInput input) => 
            _input = input;

        public void Run()
        {
            if (_players.IsEmpty())
                return;

            foreach (var index in _players)
            {
                ref var entity = ref _players.GetEntity(index);
                ref var rotation = ref entity.Get<Rotation>();
                ref var position = ref entity.Get<Position>();
                rotation.Direction = (_input.WorldMousePosition - position.Value).Normalize();
            }
        }
    }
}