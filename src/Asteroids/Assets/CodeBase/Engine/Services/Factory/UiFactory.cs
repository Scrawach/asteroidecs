using System.Threading.Tasks;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Services.Meta;
using CodeBase.Engine.Services.AssetManagement;
using CodeBase.Engine.UI;
using UnityEngine;

namespace CodeBase.Engine.Services.Factory
{
    public class UiFactory : IUiFactory
    {
        private readonly IAssets _assets;
        private readonly IWallet _wallet;

        public UiFactory(IAssets assets, IWallet wallet)
        {
            _assets = assets;
            _wallet = wallet;
        }
        
        public async void CreateHud()
        {
            const string address = "GameplayHud";
            var instance = await InstantiateAsync(address);
            instance.GetComponent<GameplayHud>().Construct(_wallet);
        }

        public async void CreateGameOverWindow()
        {
            const string address = "GameOverWindow";
            var instance = await InstantiateAsync(address);
        }

        private async Task<GameObject> InstantiateAsync(string address)
        {
            var prefab = await _assets.Load<GameObject>(address);
            return Object.Instantiate(prefab);
        }
    }
}