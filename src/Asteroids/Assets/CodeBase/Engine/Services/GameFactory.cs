using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Engine.MonoLinks.Base;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Engine.Services
{
    public class GameFactory : MonoBehaviour, IFactory
    {
        public GameObject Template;

        public void Create(ObjectId objectId, Vector2Data at, EcsWorld world)
        {
            var spawnPosition = new Vector3(at.X, at.Y, 0f);
            var result = Instantiate(Template, spawnPosition, Quaternion.identity);
            
            if (result.TryGetComponent<MonoEntity>(out var monoEntity))
            {
                var entity = world.NewEntity();
                monoEntity.Resolve(ref entity);
            }
        }
    }
}