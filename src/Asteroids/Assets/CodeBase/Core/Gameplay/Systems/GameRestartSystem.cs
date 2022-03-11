using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems
{
    public class GameRestartSystem : IEcsRunSystem
    {
        private readonly Game _game;
        private readonly EcsWorld _world;

        public GameRestartSystem(Game game) =>
            _game = game;

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<RestartButtonPressedTag>().End();

            if (filter.GetEntitiesCount() < 1)
                return;

            foreach (var index in filter)
                world.DelEntity(index);

            var entities = new int[0];
            world.GetAllEntities(ref entities);
            var dead = world.GetPool<DestroyTag>();

            foreach (var entity in entities)
                dead.Add(entity);
            
            _game.Restart();
        }
    }
}