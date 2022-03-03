using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Engine.Services
{
    public class Assets : IAssets
    {
        public void Initialize() => 
            Addressables.InitializeAsync();

        public Task<GameObject> Instantiate(string address) =>
            Instantiate(address, Vector3.zero, Quaternion.identity);

        public Task<GameObject> Instantiate(string address, Vector3 at) =>
            Instantiate(address, at, Quaternion.identity);

        public Task<GameObject> Instantiate(string address, Vector3 position, Quaternion rotation) => 
            Addressables.InstantiateAsync(address, position, rotation).Task;
    }
}