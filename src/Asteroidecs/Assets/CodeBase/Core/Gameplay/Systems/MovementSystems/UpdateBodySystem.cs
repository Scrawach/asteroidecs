using CodeBase.Core.Gameplay.Components.Moves;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.MovementSystems
{
    public class UpdateBodySystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world
                .Filter<EngineBody>()
                .Inc<Position>()
                .Inc<Rotation>()
                .End();

            var positions = world.GetPool<Position>();
            var rotations = world.GetPool<Rotation>();
            var bodies = world.GetPool<EngineBody>();

            foreach (var index in filter)
            {
                ref var body = ref bodies.Get(index);
                ref var position = ref positions.Get(index);
                ref var rotation = ref rotations.Get(index);

                body.Body.Move(position.Value);
                body.Body.Rotate(rotation.Direction);
            }
        }
    }
}