using CodeBase.Core.Gameplay.Services.Meta;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Engine.UI
{
    public class GameOverWindow : MonoBehaviour
    {
        [SerializeField] 
        private Button _restart;

        private IRestartService _restartService;

        public void Construct(IRestartService restartService) => 
            _restartService = restartService;

        private void OnEnable() => 
            _restart.onClick.AddListener(OnRestartClicked);

        private void OnDisable() => 
            _restart.onClick.RemoveListener(OnRestartClicked);

        private void OnRestartClicked() => 
            _restartService.Restart();
    }
}