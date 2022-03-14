using CodeBase.Core.Infrastructure.Systems.Abstract;
using Leopotam.EcsLite;

namespace CodeBase.Engine.Systems
{
    public class DebugSystems : IConnectableSystem
    {
        public EcsSystems ConnectTo(EcsSystems systems) =>
            systems.Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
    }
}