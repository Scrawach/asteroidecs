using CodeBase.Core.Gameplay.Components.Events;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public interface IEnterTriggerStrategy
    {
        void OnEnter(EcsWorld world, OnTriggerEnter enter);
    }
}