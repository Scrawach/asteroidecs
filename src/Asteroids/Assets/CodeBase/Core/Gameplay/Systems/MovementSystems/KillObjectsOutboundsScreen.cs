using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.MovementSystems
{
    public class KillObjectsOutboundsScreen : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<Position> _objects = default;
        private readonly IGameScreen _screen;
        private float _borderX;
        private float _borderY;

        public KillObjectsOutboundsScreen(IGameScreen screen) => 
            _screen = screen;

        public void Init()
        {
            _borderX = _screen.Size.X;
            _borderY = _screen.Size.Y;
        }

        public void Run()
        {
            foreach (var index in _objects)
            {
                ref var entity = ref _objects.GetEntity(index);
                var position = _objects.Get1(index);

                if (IsOutBounds(position))
                {
                    entity.Get<DestroyTag>() = new DestroyTag();
                }
            }
        }

        private bool IsOutBounds(Position position) =>
            position.Value.X > _borderX ||
            position.Value.X < -_borderX ||
            position.Value.Y > _borderY ||
            position.Value.Y < -_borderY;
    }
}