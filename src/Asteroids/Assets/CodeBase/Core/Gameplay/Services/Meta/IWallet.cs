using System;

namespace CodeBase.Core.Gameplay.Services.Meta
{
    public interface IWallet
    {
        event Action Changed; 
        int Score { get; }
        void Add(int value);
        void Reset();
    }
}