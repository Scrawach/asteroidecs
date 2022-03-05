using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Services
{
    public interface IDebug
    {
        IDebug Register(EcsWorld world);
        IDebug Register(EcsSystems systems);
    }
}