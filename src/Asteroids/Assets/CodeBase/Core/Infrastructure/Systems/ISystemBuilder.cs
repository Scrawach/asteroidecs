using Leopotam.Ecs;

namespace CodeBase.Core.Infrastructure.Systems
{
    public interface ISystemBuilder
    {
        EcsSystems Build(EcsWorld world);
    }
}