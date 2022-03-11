using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Services;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.MovementSystems
{
    public class MoveSystem : IEcsRunSystem
    {
        private readonly ITime _time;

        public MoveSystem(ITime time) =>
            _time = time;

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world
                .Filter<Position>()
                .Inc<Movement>()
                .Inc<MovementSpeed>()
                .End();

            var positions = world.GetPool<Position>();
            var movements = world.GetPool<Movement>();
            var speeds = world.GetPool<MovementSpeed>();

            foreach (var index in filter)
            {
                ref var position = ref positions.Get(index);
                ref var movement = ref movements.Get(index);
                ref var speed = ref speeds.Get(index);

                var step = speed.Value * _time.DeltaFrame;
                var velocity = movement.Direction * step;
                position.Value += velocity;
            }
        }
    }
}