using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Engine.Services.AssetManagement.Pool
{
    public class PoolAssets : IAssets
    {
        private readonly IAssets _assets;
        private readonly Dictionary<string, GamePool> _pools;

        public PoolAssets(IAssets assets)
        {
            _assets = assets;
            _pools = new Dictionary<string, GamePool>();
        }

        public void Initialize() =>
            _assets.Initialize();

        public Task<TAsset> Load<TAsset>(string address) where TAsset : Object =>
            _assets.Load<TAsset>(address);

        public async Task<GameObject> InstantiateAsync(string address, Vector3 position, Quaternion rotation)
        {
            if (_pools.TryGetValue(address, out var pool) == false)
            {
                pool = CreatePool(address);
                _pools.Add(address, pool);
            }
            
            if (pool.HasObjects) 
                return pool.Pull();
            
            return await CreateObject(address, position, rotation);
        }

        public void Cleanup()
        {
            _assets.Cleanup();

            foreach (var pool in _pools) 
                pool.Value.Cleanup();
            _pools.Clear();
        }

        private static GamePool CreatePool(string objectId) =>
            new GamePool(new GameObject($"[POOL] {objectId}").transform);

        private async Task<GameObject> CreateObject(string address, Vector3 position, Quaternion rotation)
        {
            var instance = await _assets.InstantiateAsync(address, position, rotation);
            if (instance.TryGetComponent(out IPoolObject poolingObject))
                poolingObject.Register(_pools[address]);
            return instance;
        }
    }
}