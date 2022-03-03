using CodeBase.Core.Gameplay.Services;
using Leopotam.Ecs;

namespace CodeBase.Engine.Services
{
    public class UnityDebug : IDebug
    {
        public void Register(EcsWorld world)
        {
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (world);
#endif
        }

        public void Register(EcsSystems systems)
        {
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (systems);
#endif
        }
    }
}