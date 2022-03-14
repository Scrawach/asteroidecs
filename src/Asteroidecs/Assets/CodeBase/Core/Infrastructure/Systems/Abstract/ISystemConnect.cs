using Leopotam.EcsLite;

namespace CodeBase.Core.Infrastructure.Systems.Abstract
{
    public interface IConnectableSystem
    {
        EcsSystems ConnectTo(EcsSystems systems);
    }
}