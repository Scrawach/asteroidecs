using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components.Ai;
using CodeBase.Core.Gameplay.Components.Moves;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.AiSystems
{
    public class FollowTargetSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<FollowTarget>().Inc<Movement>().End();
            var targets = world.GetPool<FollowTarget>();
            var positions = world.GetPool<Position>();
            var movements = world.GetPool<Movement>();
            foreach (var index in filter)
            {
                ref var target = ref targets.Get(index);
                
                if (target.Target.Unpack(world, out var entity))
                {
                    ref var targetPosition = ref positions.Get(entity);
                    ref var followerPosition = ref positions.Get(index);
                    ref var movement = ref movements.Get(index);

                    var direction = targetPosition.Value - followerPosition.Value;
                    movement.Direction = direction.Normalize();
                }
            }
        }
    }
}