using CodeBase.Core.Gameplay.Components.Moves;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.MovementSystems
{
    public class UpdatePositionSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world
                .Filter<Position>()
                .Inc<Velocity>()
                .End();
            var positions = world.GetPool<Position>();
            var velocities = world.GetPool<Velocity>();
            foreach (var index in filter)
            {
                ref var position = ref positions.Get(index);
                ref var velocity = ref velocities.Get(index);
                position.Value += velocity.Value;
            }
        }
    }
}