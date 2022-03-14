using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies
{
    public class CombineStrategies : IEnterTriggerStrategy
    {
        private readonly IEnterTriggerStrategy[] _strategies;

        public CombineStrategies(params IEnterTriggerStrategy[] strategies) =>
            _strategies = strategies;

        public void OnEnter(EcsWorld world, int sender, int trigger)
        {
            foreach (var strategy in _strategies)
                strategy.OnEnter(world, sender, trigger);
        }
    }
}