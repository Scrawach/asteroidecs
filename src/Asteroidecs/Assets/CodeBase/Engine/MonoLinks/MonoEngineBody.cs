using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Engine.Common;
using CodeBase.Engine.MonoLinks.Base;
using Leopotam.EcsLite;

namespace CodeBase.Engine.MonoLinks
{
    public class MonoEngineBody : MonoLinkBase
    {
        private EcsPackedEntityWithWorld _entityWithWorld;

        public override void Resolve(EcsWorld world, int entity) =>
            _entityWithWorld = world.PackEntityWithWorld(entity);

        private void Update() =>
            UpdateTransform();

        private void UpdateTransform()
        {
            if (_entityWithWorld.Unpack(out var world, out var entity))
            {
                var movementPool = world.GetPool<Position>();
                var rotationPool = world.GetPool<Rotation>();

                if (movementPool.Has(entity))
                    transform.position = movementPool.Get(entity).Value.ToVector3();

                if (rotationPool.Has(entity))
                    transform.rotation = rotationPool.Get(entity).Direction.ToQuaternion();
            }
        }
    }
}