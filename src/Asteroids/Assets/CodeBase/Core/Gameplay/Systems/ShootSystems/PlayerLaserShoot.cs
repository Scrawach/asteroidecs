using CodeBase.Core.Common;
using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Components.Weapon;
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

            var filter = world
                .Filter<PlayerTag>()
                .Inc<Position>()
                .Inc<Rotation>()
                .Exc<LaserReload>()
                .End();
            
            var positions = world.GetPool<Position>();
            var rotations = world.GetPool<Rotation>();

            foreach (var index in filter)
            {
                ref var position = ref positions.Get(index);
                ref var rotation = ref rotations.Get(index);
                
                world.NewEntityWith(new ShootPoint
                {
                    Bullet = ObjectId.PlayerLaser,
                    Position = position.Value,
                    Direction = rotation.Direction
                });
                
                world.AddComponent(index, new LaserReload
                {
                    Cooldown = 2f
                });
            }
        }
    }
}