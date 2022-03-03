using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.ShootSystems
{
    public class PlayerShoot : IEcsRunSystem
    {
        private readonly EcsFilter<FireButtonPressedTag> _shootFilter = default;
        private readonly EcsFilter<PlayerTag, Position, Rotation> _players = default;
        
        public void Run()
        {
            if (_shootFilter.IsEmpty())
                return;

            foreach (var index in _players)
            {
                ref var entity = ref _players.GetEntity(index);
                var position = _players.Get2(index);
                var rotation = _players.Get3(index);
                
                entity.Get<ShootPoint>() = new ShootPoint
                {
                    Bullet = ObjectId.PlayerBullet,
                    Position = position.Value,
                    Direction = rotation.Direction
                };
            }
        }
    }
}