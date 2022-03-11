using System.Threading.Tasks;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Services.Meta;
using CodeBase.Engine.Services.AssetManagement;
using CodeBase.Engine.UI;
using Leopotam.EcsLite;
using UnityEngine;

namespace CodeBase.Engine.Services.Factory
{
    public class UiFactory : IUiFactory
    {
        private readonly IAssets _assets;
        private readonly IWallet _wallet;
        private GameOverWindow _gameOverWindow;

        private GameplayHud _gameplayHud;

        public UiFactory(IAssets assets, IWallet wallet)
        {
            _assets = assets;
            _wallet = wallet;
        }

        public async void OpenGameplayHud()
        {
            const string address = "GameplayHud";
            var instance = await InstantiateAsync(address);
            _gameplayHud = instance.GetComponent<GameplayHud>();
            _gameplayHud.Construct(_wallet);
        }

        public void CloseGameplayHud() =>
            Object.Destroy(_gameplayHud.gameObject);

        public async void OpenGameOverWindow(EcsWorld world)
        {
            const string address = "GameOverWindow";
            var instance = await InstantiateAsync(address);
            _gameOverWindow = instance.GetComponent<GameOverWindow>();
            _gameOverWindow.Construct(world);
        }

        public void CloseGameOverWindow() =>
            Object.Destroy(_gameOverWindow.gameObject);

        private async Task<GameObject> InstantiateAsync(string address)
        {
            var prefab = await _assets.Load<GameObject>(address);
            return Object.Instantiate(prefab);
        }
    }
}