using CodeBase.Core.Gameplay.Components.Events;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public interface IEnterTriggerStrategy
    {
        void OnEnter(OnTriggerEnter enter);
    }
}