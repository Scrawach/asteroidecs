using Leopotam.EcsLite;

namespace CodeBase.Core.Infrastructure.Systems.Abstract
{
    public interface ISystemConnect
    {
        EcsSystems ConnectTo(EcsSystems systems);
    }
}