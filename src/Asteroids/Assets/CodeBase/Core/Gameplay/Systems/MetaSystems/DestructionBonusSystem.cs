using CodeBase.Core.Gameplay.Components.Meta;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services.Meta;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.MetaSystems
{
    public class DestructionBonusSystem : IEcsRunSystem
    {
        private readonly IWallet _wallet;

        public DestructionBonusSystem(IWallet wallet) =>
            _wallet = wallet;

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world
                .Filter<BonusForDestruction>()
                .Inc<KilledByPlayer>()
                .End();

            var resultBonus = 0;
            var bonuses = world.GetPool<BonusForDestruction>();

            foreach (var index in filter)
                resultBonus += bonuses.Get(index).Value;

            if (resultBonus > 0)
                _wallet.Add(resultBonus);
        }
    }
}