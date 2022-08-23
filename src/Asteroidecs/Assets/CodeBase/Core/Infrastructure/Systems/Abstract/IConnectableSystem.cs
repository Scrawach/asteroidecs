using Leopotam.EcsLite;

namespace CodeBase.Core.Infrastructure.Systems.Abstract
{
    public interface IConnectableSystem
    {
        IEcsSystems ConnectTo(IEcsSystems systems);
    }
}