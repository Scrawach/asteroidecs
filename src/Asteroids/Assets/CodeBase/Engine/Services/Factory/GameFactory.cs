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

        public GameFactory(IAssets assets) => _assets = assets;

        public async void Create(SpawnInfo info, EcsWorld world)
        {
            var (address, position, rotation) = Parse(info);
            var prefab = await _assets.Load<GameObject>(address);
            var instance = Object.Instantiate(prefab, position, rotation);

            if (instance.TryGetComponent<MonoEntity>(out var monoEntity))
                CreateEntity(info, world, monoEntity);
        }

        private (string address, Vector3 position, Quaternion rotation) Parse(SpawnInfo info) => (info.Id.ToString(),
            info.Position.ToVector3(), info.Direction.ToQuaternion());

        private static void CreateEntity(SpawnInfo info, EcsWorld world, MonoLinkBase monoLink)
        {
            var entity = world.NewEntity();
            var positions = world.GetPool<Position>();
            var rotations = world.GetPool<Rotation>();

            rotations.Add(entity);
            positions.Add(entity);

            ref var position = ref positions.Get(entity);
            ref var rotation = ref rotations.Get(entity);

            position.Value = info.Position;
            rotation.Direction = info.Direction;

            monoLink.Resolve(world, entity);
        }
    }
}