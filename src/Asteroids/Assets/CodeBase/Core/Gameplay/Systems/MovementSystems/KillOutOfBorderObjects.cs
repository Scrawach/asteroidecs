using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.MovementSystems
{
    public class KillOutOfBorderObjects : IEcsRunSystem
    {
        private readonly EcsFilter<Position> _objects = default;
        private readonly IGameScreen _screen;

        public KillOutOfBorderObjects(IGameScreen screen) => 
            _screen = screen;
        
        public void Run()
        {
            foreach (var index in _objects)
            {
                ref var entity = ref _objects.GetEntity(index);
                var position = _objects.Get1(index);

                if (_screen.IsOutOfBorder(position.Value)) 
                    entity.Get<DestroyTag>() = new DestroyTag();
            }
        }
    }
}