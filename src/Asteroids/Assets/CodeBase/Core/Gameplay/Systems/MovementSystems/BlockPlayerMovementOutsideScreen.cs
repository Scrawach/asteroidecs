using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags.Objects;
using CodeBase.Core.Gameplay.Services;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.MovementSystems
{
    public class BlockPlayerMovementOutsideScreen : IEcsInitSystem, IEcsRunSystem
    {
        private readonly IGameScreen _screen;
        private float _borderX;
        private float _borderY;

        public BlockPlayerMovementOutsideScreen(IGameScreen screen) =>
            _screen = screen;

        public void Init(EcsSystems systems)
        {
            _borderX = _screen.Size.X / 2f;
            _borderY = _screen.Size.Y / 2f;
        }

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world
                .Filter<PlayerTag>()
                .Inc<Position>()
                .Inc<Movement>()
                .End();

            var positions = world.GetPool<Position>();
            var movements = world.GetPool<Movement>();

            foreach (var index in filter)
            {
                ref var position = ref positions.Get(index);
                ref var movement = ref movements.Get(index);

                if (position.Value.X > _borderX && movement.Direction.X > 0 ||
                    position.Value.X < -_borderX && movement.Direction.X < 0)
                    movement.Direction.X = 0;

                if (position.Value.Y > _borderY && movement.Direction.Y > 0 ||
                    position.Value.Y < -_borderY && movement.Direction.Y < 0)
                    movement.Direction.Y = 0;
            }
        }
    }
}