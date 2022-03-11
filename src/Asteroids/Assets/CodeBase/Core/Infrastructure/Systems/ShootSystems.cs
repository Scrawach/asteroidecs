using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Systems.ShootSystems;
using CodeBase.Core.Infrastructure.Systems.Abstract;
using Leopotam.EcsLite;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class ShootSystems : IConnectableSystem
    {
        public EcsSystems ConnectTo(EcsSystems systems) =>
            systems
                .DeleteHere<ShootPoint>()
                .Add(new PlayerBulletShoot())
                .Add(new PlayerLaserShoot());
    }
}