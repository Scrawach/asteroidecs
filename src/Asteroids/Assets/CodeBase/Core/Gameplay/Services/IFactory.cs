using CodeBase.Core.Gameplay.Components;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Services
{
    public interface IFactory
    {
        void Create(SpawnInfo info, EcsWorld world);
    }
}