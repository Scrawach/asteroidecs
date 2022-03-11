using CodeBase.Core.Common;
using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.ShootSystems
{
    public class PlayerLaserShoot : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var pressed = world.Filter<LaserButtonPressedEvent>().End();

            if (pressed.GetEntitiesCount() < 1)
                return;

            var players = world
                .Filter<PlayerTag>()
                .Inc<Position>()
                .Inc<Rotation>()
                .End();

            var positions = world.GetPool<Position>();
            var rotations = world.GetPool<Rotation>();

            foreach (var index in players)
            {
                ref var position = ref positions.Get(index);
                ref var rotation = ref rotations.Get(index);
                
                world.NewEntityWith(new ShootPoint
                {
                    Bullet = ObjectId.PlayerLaser,
                    Position = position.Value,
                    Direction = rotation.Direction
                });
            }
        }
    }
}