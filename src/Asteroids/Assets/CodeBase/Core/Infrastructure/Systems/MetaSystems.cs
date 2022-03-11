using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Services.Meta;
using CodeBase.Core.Gameplay.Systems.MetaSystems;
using CodeBase.Core.Infrastructure.Systems.Abstract;
using Leopotam.EcsLite;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class MetaSystems : IConnectableSystem
    {
        private readonly IUiFactory _uiFactory;
        private readonly IWallet _wallet;

        public MetaSystems(IWallet wallet, IUiFactory uiFactory)
        {
            _wallet = wallet;
            _uiFactory = uiFactory;
        }

        public EcsSystems ConnectTo(EcsSystems systems) =>
            systems
                .Add(new EraseWalletOnStartSystem(_wallet))
                .Add(new GameplayHudLifecycleSystem(_uiFactory))
                .Add(new DestructionBonusSystem(_wallet))
                .Add(new GameOverSystem(_uiFactory));
    }
}