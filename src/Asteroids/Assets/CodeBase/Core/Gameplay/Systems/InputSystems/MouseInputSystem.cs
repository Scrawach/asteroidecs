using System;
using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.InputSystems
{
    public class MouseInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag> _players = default;
        private readonly IInput _input = default;
        private const float Rad2Deg = 57.3f;
        
        public void Run()
        {
            if (_players.IsEmpty())
                return;

            foreach (var index in _players)
            {
                ref var entity = ref _players.GetEntity(index);
                ref var rotation = ref entity.Get<Rotation>();
                ref var position = ref entity.Get<Position>();

                var desiredDirection = (_input.WorldMousePosition - position.Value).Normalize();
                var angle = (float)Math.Atan2(desiredDirection.Y, desiredDirection.X) * Rad2Deg;
                rotation.Angle = angle;
            }
        }
    }
}