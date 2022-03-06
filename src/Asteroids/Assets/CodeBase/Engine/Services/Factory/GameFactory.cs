using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Services.Meta;
using CodeBase.Engine.Common;
using CodeBase.Engine.MonoLinks.Base;
using CodeBase.Engine.Services.AssetManagement;
using CodeBase.Engine.UI;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Engine.Services.Factory
{
    public class GameFactory : IFactory
    {
        private readonly IAssets _assets;
        private readonly IWallet _wallet;

        public GameFactory(IAssets assets, IWallet wallet)
        {
            _assets = assets;
            _wallet = wallet;
        }

        public async void Create(SpawnInfo info, EcsWorld world)
        {
            var (address, position, rotation) = Parse(info);
            var prefab = await _assets.Load<GameObject>(address);
            var instance = Object.Instantiate(prefab, position, rotation);

            if (instance.TryGetComponent<MonoEntity>(out var monoEntity)) 
                CreateEntity(info, world, monoEntity);
        }

        public async void CreateHud()
        {
            const string address = "GameplayHud";
            var prefab = await _assets.Load<GameObject>(address);
            var instance = Object.Instantiate(prefab);
            instance.GetComponent<GameplayHud>().Construct(_wallet);
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