using System;

namespace CodeBase.Core.Gameplay.Services.Meta
{
    public interface IWallet
    {
        int Score { get; }
        event Action Changed;
        void Add(int value);
        void Reset();
    }
}