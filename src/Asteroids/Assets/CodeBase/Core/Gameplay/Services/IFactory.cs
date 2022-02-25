using CodeBase.Core.Common;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Services
{
    public interface IFactory
    {
        void Create(ObjectId objectId, Vector2Data at, EcsWorld world);
    }
}