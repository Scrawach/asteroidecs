using System;
using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems
{
    public class GameRestartSystem : IEcsRunSystem
    {
        private readonly Action _onRestart;

        public GameRestartSystem(Action onRestart) => 
            _onRestart = onRestart;

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            
            if (!IsRestartButtonPressed(world)) 
                return;
            
            DestroyEntities(world);
            _onRestart();
        }

        private static bool IsRestartButtonPressed(EcsWorld world)
        {
            var filter = world.Filter<RestartRequest>().End();
            var hasRequest = filter.GetEntitiesCount() > 0;
            foreach (var index in filter) 
                world.DelEntity(index);
            return hasRequest;
        }

        private static void DestroyEntities(EcsWorld world)
        {
            var entities = new int[0];
            var dead = world.GetPool<DestroyTag>();
            world.GetAllEntities(ref entities);
            foreach (var entity in entities) 
                dead.Add(entity);
        }
    }
}