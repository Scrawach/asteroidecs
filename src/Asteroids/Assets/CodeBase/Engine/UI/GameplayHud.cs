using CodeBase.Core;
using UnityEngine;

namespace CodeBase.Engine.UI
{
    public class GameplayHud : MonoBehaviour
    {
        [SerializeField] 
        private ScoreCounter _scoreCounter;
        
        public void Construct(Game game) => 
            _scoreCounter.Construct(game.Wallet);
    }
}