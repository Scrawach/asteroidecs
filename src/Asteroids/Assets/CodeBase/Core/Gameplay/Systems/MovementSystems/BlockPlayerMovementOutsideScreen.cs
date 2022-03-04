using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.MovementSystems
{
    public class BlockPlayerMovementOutsideScreen : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, Position> _players = default;
        private readonly IGameScreen _screen;
        private float _borderX;
        private float _borderY;

        public BlockPlayerMovementOutsideScreen(IGameScreen screen) => 
            _screen = screen;

        public void Init()
        {
            _borderX = _screen.Size.X / 2f;
            _borderY = _screen.Size.Y / 2f;
        }

        public void Run()
        {
            foreach (var index in _players)
            {
                ref var entity = ref _players.GetEntity(index);
                ref var position = ref _players.Get2(index);
                ref var movement = ref entity.Get<Movement>();

                if ((position.Value.X > _borderX && movement.Direction.X > 0) || 
                    (position.Value.X < -_borderX && movement.Direction.X < 0))
                    movement.Direction.X = 0;

                if ((position.Value.Y > _borderY && movement.Direction.Y > 0) || 
                    (position.Value.Y < -_borderY && movement.Direction.Y < 0))
                    movement.Direction.Y = 0;
            }
        }
    }
}