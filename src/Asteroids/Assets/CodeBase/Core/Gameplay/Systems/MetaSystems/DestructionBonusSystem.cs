using CodeBase.Core.Gameplay.Components.Meta;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services.Meta;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.MetaSystems
{
    public class DestructionBonusSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BonusForDestruction, KilledByPlayer> _destroyingAsteroids = default;
        private readonly IWallet _wallet;

        public DestructionBonusSystem(IWallet wallet) => 
            _wallet = wallet;

        public void Run()
        {
            var bonus = 0;
            
            foreach (var index in _destroyingAsteroids) 
                bonus += _destroyingAsteroids.Get1(index).Value;

            if (bonus > 0)
                _wallet.Add(bonus);
        }
    }
}