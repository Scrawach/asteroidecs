using CodeBase.Core.Common;
using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags.Objects;
using CodeBase.Core.Gameplay.Services;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.InputSystems
{
    public class PlayerRotationSystem : IEcsRunSystem
    {
        private readonly IInput _input;

        public PlayerRotationSystem(IInput input) =>
            _input = input;

        public void Run(IEcsSystems systems)
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

                const float lerpSmooth = 0.25f;
                var desiredRotation = (_input.WorldMousePosition - position.Value).Normalize();
                var nextRotation = Vector2Data.Lerp(rotation.Direction, desiredRotation, lerpSmooth);

                rotation.Direction = nextRotation.Normalize();
            }
        }
    }
}