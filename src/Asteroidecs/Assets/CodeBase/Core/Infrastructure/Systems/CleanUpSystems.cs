using CodeBase.Core.Gameplay.Systems.LifecycleSystems;
using CodeBase.Core.Infrastructure.Systems.Abstract;
using Leopotam.EcsLite;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class CleanUpSystems : IConnectableSystem
    {
        public EcsSystems ConnectTo(EcsSystems systems) =>
            systems.Add(new DestroySystem());
    }
}