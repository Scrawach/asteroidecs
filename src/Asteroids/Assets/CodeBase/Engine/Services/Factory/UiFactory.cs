using CodeBase.Core.Gameplay.Services.Meta;
using CodeBase.Engine.Services.AssetManagement;
using CodeBase.Engine.UI;
using UnityEngine;

namespace CodeBase.Engine.Services.Factory
{
    public class UiFactory
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
            var prefab = await _assets.Load<GameObject>(address);
            var instance = Object.Instantiate(prefab);
            instance.GetComponent<GameplayHud>().Construct(_wallet);
        }
    }
}