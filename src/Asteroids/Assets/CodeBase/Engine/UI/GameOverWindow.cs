using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Engine.UI
{
    public class GameOverWindow : MonoBehaviour
    {
        [SerializeField] private Button _restart;

        private EcsWorld _world;

        public void Construct(EcsWorld world) =>
            _world = world;

        private void OnEnable() =>
            _restart.onClick.AddListener(OnRestartClicked);

        private void OnDisable() =>
            _restart.onClick.RemoveListener(OnRestartClicked);

        private void OnRestartClicked() =>
            _world.NewEntityWith<RestartButtonPressedTag>();
    }
}