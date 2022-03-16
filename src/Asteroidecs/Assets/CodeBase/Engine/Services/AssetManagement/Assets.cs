using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CodeBase.Engine.Services.AssetManagement
{
    public class Assets : IAssets
    {
        private readonly Dictionary<string, AsyncOperationHandle> _cache =
            new Dictionary<string, AsyncOperationHandle>();

        public async void Initialize() =>
            await Addressables.InitializeAsync().Task;

        public async Task<TAsset> Load<TAsset>(string address) where TAsset : Object =>
            _cache.TryGetValue(address, out var cachedHandle)
                ? cachedHandle.Result as TAsset
                : await ResourceLoading<TAsset>(address);

        public async Task<GameObject> InstantiateAsync(string address, Vector3 position, Quaternion rotation)
        {
            var prefab = await Load<GameObject>(address);
            var instance = Object.Instantiate(prefab, position, rotation);
            return instance;
        }

        public void Cleanup()
        {
            foreach (var pair in _cache)
                Addressables.Release(pair.Value);
            _cache.Clear();
        }

        private async Task<TResource> ResourceLoading<TResource>(string address)
        {
            var handle = Addressables.LoadAssetAsync<TResource>(address);
            handle.Completed += operationHandle => _cache[address] = operationHandle;
            return await handle.Task;
        }
    }
}