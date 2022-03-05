using CodeBase.Core.Gameplay.Components.Meta;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Services.Meta;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.MetaSystems
{
    public class AsteroidsDropScoreSystems : IEcsRunSystem
    {
        private readonly EcsFilter<BonusForDestruction, KilledByPlayer> _destroyingAsteroids = default;
        private readonly IWallet _wallet;

        public AsteroidsDropScoreSystems(IWallet wallet) => 
            _wallet = wallet;

        public void Run()
        {
            foreach (var index in _destroyingAsteroids)
            {
                var bonus = _destroyingAsteroids.Get1(index);
                _wallet.Add(bonus.Value);
            }
        }
    }
}