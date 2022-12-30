using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components.Meta;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Components.Tags.Objects;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.LifecycleSystems
{
    public class PlayerDiedSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world
                .Filter<PlayerTag>()
                .Inc<DestroyTag>()
                .End();

            if (filter.GetEntitiesCount() > 0)
                world.NewEntityWith<GameOverEvent>();
        }
    }
}