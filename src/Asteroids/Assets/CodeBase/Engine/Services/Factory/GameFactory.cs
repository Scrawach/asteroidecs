using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Engine.Common;
using CodeBase.Engine.MonoLinks.Base;
using CodeBase.Engine.Services.AssetManagement;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Engine.Services.Factory
{
    public class GameFactory : IFactory
    {
        private readonly IAssets _assets;

        public GameFactory(IAssets assets) => 
            _assets = assets;

        public async void Create(SpawnInfo info, EcsWorld world)
        {
            var (address, position, rotation) = Parse(info);
            var prefab = await _assets.Load<GameObject>(address);
            var instance = Object.Instantiate(prefab, position, rotation);

            if (instance.TryGetComponent<MonoEntity>(out var monoEntity)) 
                CreateEntity(info, world, monoEntity);
        }

        private (string address, Vector3 position, Quaternion rotation) Parse(SpawnInfo info) => 
            (info.Id.ToString(), info.Position.ToVector3(), info.Direction.ToQuaternion());

        private static void CreateEntity(SpawnInfo info, EcsWorld world, MonoLinkBase monoLink)
        {
            var entity = world.NewEntity();
            entity.Get<Position>() = new Position {Value = info.Position};
            entity.Get<Rotation>() = new Rotation {Direction = info.Direction};
            monoLink.Resolve(ref entity);
        }
    }
}