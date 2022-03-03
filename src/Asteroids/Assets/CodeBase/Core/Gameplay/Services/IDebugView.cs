using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Services
{
    public interface IDebug
    {
        void Register(EcsWorld world);
        void Register(EcsSystems systems);
    }
}