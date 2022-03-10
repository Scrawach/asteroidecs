using CodeBase.Core.Gameplay.Services.Meta;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.MetaSystems
{
    public class EraseWalletOnStartSystem : IEcsInitSystem
    {
        private readonly IWallet _wallet;

        public EraseWalletOnStartSystem(IWallet wallet) => 
            _wallet = wallet;
        
        public void Init() => 
            _wallet.Reset();
    }
}