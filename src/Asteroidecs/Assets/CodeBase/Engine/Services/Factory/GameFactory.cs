using System;
using System.Threading.Tasks;
using CodeBase.Core.Data;
using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Engine.Common;
using CodeBase.Engine.MonoLinks.Base;
using CodeBase.Engine.Services.AssetManagement;
using Leopotam.EcsLite;
using UnityEngine;

namespace CodeBase.Engine.Services.Factory
{
    public class GameFactory : IFactory
    {
        private readonly IAssets _assets;

        public GameFactory(IAssets assets) =>
            _assets = assets;

        public async Task<int> Create(SpawnInfo info, EcsWorld world)
        {
            var (address, position, rotation) = Parse(info);
            var instance = await CreateGameObject(address, position, rotation);

            if (instance.TryGetComponent<MonoEntity>(out var monoEntity))
                return CreateEntity(info, world, monoEntity);
            throw new Exception("Object don't contain mono entity component!");
        }

        private (string address, Vector3 position, Quaternion rotation) Parse(SpawnInfo info) =>
            (info.Id.ToString(), info.Position.ToVector3(), info.Direction.ToQuaternion());

        private async Task<GameObject> CreateGameObject(string address, Vector3 position, Quaternion rotation) =>
            await _assets.InstantiateAsync(address, position, rotation);

        private static int CreateEntity(SpawnInfo info, EcsWorld world, MonoLinkBase monoLink)
        {
            var entity = world.NewEntity();
            world.AddComponent(entity, new Position {Value = info.Position});
            world.AddComponent(entity, new Rotation {Direction = info.Direction});
            monoLink.Resolve(world, entity);
            return entity;
        }
    }
}