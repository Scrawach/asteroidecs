using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Engine.MonoLinks.Base;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Engine.Services
{
    public class GameFactory : IFactory
    {
        private readonly IAssets _assets;

        public GameFactory(IAssets assets) => 
            _assets = assets;

        public async void Create(ObjectId objectId, Vector2Data at, EcsWorld world)
        {
            var spawnPosition = new Vector3(at.X, at.Y, 0f);
            var address = objectId.ToString();
            var result = await _assets.Instantiate(address, at: spawnPosition);

            if (result.TryGetComponent<MonoEntity>(out var monoEntity))
            {
                var entity = world.NewEntity();
                entity.Get<Position>() = new Position { Value = at };
                monoEntity.Resolve(ref entity);
            }
        }
    }
}