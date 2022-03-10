using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems
{
    public class GameCleanUpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<RestartButtonPressedTag> _filter = default;
        private readonly Game _game;
        private readonly EcsWorld _world;

        public GameCleanUpSystem(Game game, EcsWorld world)
        {
            _game = game;
            _world = world;
        }
        
        public void Run()
        {
            if (_filter.IsEmpty())
                return;
            
            _filter.GetEntity(0).Del<RestartButtonPressedTag>();
            
            EcsEntity[] entities = null;
            var count = _world.GetAllEntities(ref entities);

            for (var i = 0; i < count; i++) 
                entities[i].Get<DestroyTag>();
            
            _game.Restart();
        }
    }
}