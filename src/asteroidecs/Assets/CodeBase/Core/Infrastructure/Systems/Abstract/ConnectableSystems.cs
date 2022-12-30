using Leopotam.EcsLite;

namespace CodeBase.Core.Infrastructure.Systems.Abstract
{
    public class ConnectableSystems : IConnectableSystem
    {
        private readonly IConnectableSystem[] _connectableSystems;

        public ConnectableSystems(params IConnectableSystem[] connectableSystems) =>
            _connectableSystems = connectableSystems;

        public IEcsSystems ConnectTo(IEcsSystems systems)
        {
            foreach (var system in _connectableSystems) 
                system.ConnectTo(systems);
            return systems;
        }
    }
}