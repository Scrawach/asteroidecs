using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.MovementSystems
{
    public class SetForwardMovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world
                .Filter<ForwardMovementTag>()
                .Inc<Rotation>()
                .Inc<Movement>()
                .End();

            var rotations = world.GetPool<Rotation>();
            var movements = world.GetPool<Movement>();
            var forwards = world.GetPool<ForwardMovementTag>();

            foreach (var index in filter)
            {
                ref var rotation = ref rotations.Get(index);
                ref var movement = ref movements.Get(index);
                movement.Direction = rotation.Direction;
                forwards.Del(index);
            }
        }
    }
}