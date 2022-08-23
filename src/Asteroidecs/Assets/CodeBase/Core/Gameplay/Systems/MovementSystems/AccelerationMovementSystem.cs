using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Services.Time;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.MovementSystems
{
    public class AccelerationMovementSystem : IEcsRunSystem
    {
        private readonly ITime _time;

        public AccelerationMovementSystem(ITime time) =>
            _time = time;

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world
                .Filter<Position>()
                .Inc<Movement>()
                .Inc<MovementSpeed>()
                .Inc<Acceleration>()
                .End();

            var movements = world.GetPool<Movement>();
            var speeds = world.GetPool<MovementSpeed>();
            var accelerations = world.GetPool<Acceleration>();
            var velocities = world.GetPool<Velocity>();

            foreach (var index in filter)
            {
                ref var movement = ref movements.Get(index);
                ref var speed = ref speeds.Get(index);
                ref var velocity = ref velocities.Get(index);
                ref var acceleration = ref accelerations.Get(index);

                var step = speed.Value * _time.DeltaFrame;
                var desiredVelocity = movement.Direction * step;
                var reachedVelocity = (desiredVelocity - velocity.Value) * acceleration.Modifier;
                velocity.Value += reachedVelocity * _time.DeltaFrame;
            }
        }
    }
}