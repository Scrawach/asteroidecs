using CodeBase.Core.Gameplay.Components;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Services
{
    public interface IFactory
    {
        void Create(SpawnInfo info, EcsWorld world);
    }
}