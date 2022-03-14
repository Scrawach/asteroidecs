using CodeBase.Core.Gameplay.Services.Meta;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.MetaSystems
{
    public class EraseWalletOnStartSystem : IEcsInitSystem
    {
        private readonly IWallet _wallet;

        public EraseWalletOnStartSystem(IWallet wallet) =>
            _wallet = wallet;

        public void Init(EcsSystems systems) =>
            _wallet.Reset();
    }
}