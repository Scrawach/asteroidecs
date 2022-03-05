using System;

namespace CodeBase.Core.Gameplay.Services.Meta
{
    public class WalletService : IWallet
    {
        public event Action Changed;
        
        public int Score { get; private set; }
        
        public void Add(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(WalletService));
            Score += value;
            Changed?.Invoke();
        }

        public void Reset() => 
            Score = 0;
    }
}