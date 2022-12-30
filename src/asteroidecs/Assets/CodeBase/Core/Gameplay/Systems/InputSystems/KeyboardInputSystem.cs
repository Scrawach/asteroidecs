using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags.Objects;
using CodeBase.Core.Gameplay.Services;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.InputSystems
{
    public class KeyboardInputSystem : IEcsRunSystem
    {
        private readonly IInput _input;

        public KeyboardInputSystem(IInput input) =>
            _input = input;

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<PlayerTag>().End();

            if (_input.IsFireButtonPressed())
                world.NewEntityWith<FireButtonPressedEvent>();

            if (_input.IsLaserButtonPressed())
                world.NewEntityWith<LaserButtonPressedEvent>();

            var players = world.GetPool<Movement>();

            foreach (var index in filter)
            {
                ref var movement = ref players.Get(index);
                movement.Direction = _input.MovementDirection.Normalize();
            }
        }
    }
}