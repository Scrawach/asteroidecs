using CodeBase.Core.Gameplay.Services.Meta;
using CodeBase.Core.Gameplay.Systems.LifecycleSystems;
using CodeBase.Core.Gameplay.Systems.MetaSystems;
using Leopotam.Ecs;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class MetaSystems : ISystemBuilder
    {
        private readonly IWallet _wallet;

        public MetaSystems(IWallet wallet) => 
            _wallet = wallet;

        public EcsSystems Build(EcsWorld world) =>
            new EcsSystems(world, nameof(MetaSystems))
                .Add(new DestructionBonusSystem(_wallet))
                .Add(new GameOverSystem());
    }
}