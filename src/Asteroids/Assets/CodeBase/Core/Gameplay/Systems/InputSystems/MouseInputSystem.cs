using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.InputSystems
{
    public class MouseInputSystem : IEcsRunSystem
    {
        private readonly IInput _input;

        public MouseInputSystem(IInput input) =>
            _input = input;

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world
                .Filter<PlayerTag>()
                .Inc<Rotation>()
                .Inc<Position>()
                .End();

            var positions = world.GetPool<Position>();
            var rotations = world.GetPool<Rotation>();

            foreach (var index in filter)
            {
                ref var position = ref positions.Get(index);
                ref var rotation = ref rotations.Get(index);
                rotation.Direction = (_input.WorldMousePosition - position.Value).Normalize();
            }
        }
    }
}