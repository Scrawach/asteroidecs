using CodeBase.Core.Gameplay.Components.Moves;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.MovementSystems
{
    public class UpdateBodySystem : IEcsRunSystem
    {
        private readonly EcsFilter<Position, Rotation, EngineBody> _bodies = default;
        
        public void Run()
        {
            foreach (var index in _bodies)
            {
                var position = _bodies.Get1(index);
                var rotation = _bodies.Get2(index);
                var body = _bodies.Get3(index);
                
                body.Body.Move(position.Value);
                body.Body.Rotate(rotation.Direction);
            }
        }
    }
}