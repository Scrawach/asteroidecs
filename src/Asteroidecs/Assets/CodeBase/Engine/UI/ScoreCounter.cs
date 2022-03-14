using CodeBase.Core.Gameplay.Services.Meta;
using TMPro;
using UnityEngine;

namespace CodeBase.Engine.UI
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;

        private IWallet _wallet;

        public void Subscribe(IWallet wallet)
        {
            _wallet = wallet;
            _wallet.Changed += OnScoreChanged;
        }

        public void UnSubscribe() =>
            _wallet.Changed -= OnScoreChanged;

        private void OnScoreChanged() =>
            _label.text = $"{_wallet.Score.ToString()}";
    }
}