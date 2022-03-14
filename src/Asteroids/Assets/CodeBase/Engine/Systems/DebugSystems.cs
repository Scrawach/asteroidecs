using CodeBase.Core.Infrastructure.Systems.Abstract;
using Leopotam.EcsLite;
using Leopotam.EcsLite.UnityEditor;

namespace CodeBase.Engine.Systems
{
    public class DebugSystems : IConnectableSystem
    {
        public EcsSystems ConnectTo(EcsSystems systems) =>
            systems.Add(new EcsWorldDebugSystem());
    }
}