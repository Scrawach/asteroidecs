using System;
using System.Threading.Tasks;
using CodeBase.Core.Common;
using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Engine.Common;
using CodeBase.Engine.Components;
using CodeBase.Engine.MonoLinks.Base;
using CodeBase.Engine.Services.AssetManagement;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.AddressableAssets;

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
            return await Create(address, position, rotation, world);
        }

        public async Task<int> Create(AssetReferenceGameObject reference, Vector3 position, Quaternion rotation, EcsWorld world) =>
            await Create(reference.AssetGUID, position, rotation, world);

        private (string address, Vector3 position, Quaternion rotation) Parse(SpawnInfo info) =>
            (info.Id.ToString(), info.Position.ToVector3(), info.Direction.ToQuaternion());

        private async Task<int> Create(string address, Vector3 position, Quaternion rotation, EcsWorld world)
        {
            var direction = rotation * Vector3.right;
            var instance = await CreateGameObject(address, position, rotation);
            if (instance.TryGetComponent<SpawnAfterDestroy>(out var spawn))
                spawn.Construct(this, world);
            if (instance.TryGetComponent<MonoEntity>(out var mono))
                return CreateEntity(position.ToVector2Data(), direction.ToVector2Data(), world, mono);
            throw new Exception("Object don't contain mono entity component!");
        }

        private async Task<GameObject> CreateGameObject(string address, Vector3 position, Quaternion rotation)
        {
            var gameObject = await _assets.InstantiateAsync(address, position, rotation);
            return gameObject;
        }

        private static int CreateEntity(Vector2Data position, Vector2Data direction, EcsWorld world, MonoLinkBase monoLink)
        {
            var entity = world.NewEntity();
            world.AddComponent(entity, new Position {Value = position});
            world.AddComponent(entity, new Rotation {Direction = direction});
            monoLink.Resolve(world, entity);
            return entity;
        }
    }
}