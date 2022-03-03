using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Engine.Common;
using CodeBase.Engine.MonoLinks.Base;
using CodeBase.Engine.Services.AssetManagement;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Engine.Services
{
    public class GameFactory : IFactory
    {
        private readonly IAssets _assets;

        public GameFactory(IAssets assets) => 
            _assets = assets;
        
        public async void Create(SpawnInfo info, EcsWorld world)
        {
            var spawnPoint = info.Position.ToVector3();
            var rotation = info.Direction.ToQuaternion();
            var objectAddress = info.Id.ToString();
            
            var prefab = await _assets.Load<GameObject>(objectAddress);
            var instance = UnityEngine.Object.Instantiate(prefab, spawnPoint, rotation);

            if (instance.TryGetComponent<MonoEntity>(out var monoEntity))
            {
                var entity = world.NewEntity();
                entity.Get<Position>() = new Position { Value = info.Position };
                entity.Get<Rotation>() = new Rotation { Direction = info.Direction };
                monoEntity.Resolve(ref entity);
            }
        }
    }
}