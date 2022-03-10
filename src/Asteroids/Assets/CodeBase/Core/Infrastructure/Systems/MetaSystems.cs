using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Services.Meta;
using CodeBase.Core.Gameplay.Systems.MetaSystems;
using Leopotam.Ecs;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class MetaSystems : ISystemBuilder
    {
        private readonly IWallet _wallet;
        private readonly IUiFactory _uiFactory;

        public MetaSystems(IWallet wallet, IUiFactory uiFactory)
        {
            _wallet = wallet;
            _uiFactory = uiFactory;
        }

        public EcsSystems Build(EcsWorld world) =>
            new EcsSystems(world, nameof(MetaSystems))
                .Add(new GameplayHudLifecycleSystem(_uiFactory))
                .Add(new DestructionBonusSystem(_wallet))
                .Add(new GameOverSystem(_uiFactory));
    }
}