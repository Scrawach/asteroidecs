using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Services.Time;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.MovementSystems
{
    public class LinearMovementSystem : IEcsRunSystem
    {
        private readonly ITime _time;

        public LinearMovementSystem(ITime time) =>
            _time = time;

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world
                .Filter<Position>()
                .Inc<Movement>()
                .Inc<MovementSpeed>()
                .Exc<Acceleration>()
                .End();

            var movements = world.GetPool<Movement>();
            var speeds = world.GetPool<MovementSpeed>();
            var velocities = world.GetPool<Velocity>();

            foreach (var index in filter)
            {
                ref var movement = ref movements.Get(index);
                ref var speed = ref speeds.Get(index);
                ref var velocity = ref velocities.Get(index);

                var step = speed.Value * _time.DeltaFrame;
                velocity.Value = movement.Direction * step;
            }
        }
    }
}