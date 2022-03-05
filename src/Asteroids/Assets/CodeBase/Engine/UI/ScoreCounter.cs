using CodeBase.Core.Gameplay.Services.Meta;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Engine.UI
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] 
        private Text _label;

        private IWallet _wallet;
        
        public void Construct(IWallet wallet) => 
            _wallet = wallet;

        private void OnEnable() => 
            _wallet.Changed += OnScoreChanged;

        private void OnDisable() => 
            _wallet.Changed -= OnScoreChanged;

        private void OnScoreChanged() => 
            _label.text = $"{_wallet.Score.ToString()}";
    }
}