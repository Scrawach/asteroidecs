using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.MovementSystems
{
    public class BlockPlayerMovementOutsideScreen : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, Position> _players = default;
        private readonly IGameScreen _screen;

        public BlockPlayerMovementOutsideScreen(IGameScreen screen) => 
            _screen = screen;

        public void Run()
        {
            foreach (var index in _players)
            {
                ref var position = ref _players.Get2(index);
                ref var entity = ref _players.GetEntity(index);
                ref var movement = ref entity.Get<Movement>();
                
                var borderX = _screen.Size.X / 2;
                var borderY = _screen.Size.Y / 2;
                
                if ((position.Value.X > borderX && movement.Direction.X > 0) || 
                    (position.Value.X < -borderX && movement.Direction.X < 0))
                    movement.Direction.X = 0;

                if ((position.Value.Y > borderY && movement.Direction.Y > 0) || 
                    (position.Value.Y < -borderY && movement.Direction.Y < 0))
                    movement.Direction.Y = 0;
            }
        }
    }
}