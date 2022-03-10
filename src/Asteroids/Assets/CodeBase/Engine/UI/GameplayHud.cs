using CodeBase.Core.Gameplay.Services.Meta;
using UnityEngine;

namespace CodeBase.Engine.UI
{
    public class GameplayHud : MonoBehaviour
    {
        [SerializeField] 
        private ScoreCounter _scoreCounter;
        
        public void Construct(IWallet wallet) => 
            _scoreCounter.Subscribe(wallet);

        private void OnDestroy() => 
            _scoreCounter.UnSubscribe();
    }
}