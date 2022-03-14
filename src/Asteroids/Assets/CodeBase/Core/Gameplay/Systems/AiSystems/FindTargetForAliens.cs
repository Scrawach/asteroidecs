using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components.Ai;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.AiSystems
{
    public class FindTargetForAliens : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<AlienTag>().Exc<FollowTarget>().End();
            var players = world.Filter<PlayerTag>().Inc<Position>().End();

            if (players.GetEntitiesCount() < 1)
                return;

            foreach (var index in filter)
            {
                world.AddComponent(index, new FollowTarget
                {
                    Target = world.PackEntity(players.GetRawEntities()[0])
                });
            }
        }
    }
}