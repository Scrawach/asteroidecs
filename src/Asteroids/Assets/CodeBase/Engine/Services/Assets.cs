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
            Instantiate(address, Vector3.zero);
        
        public Task<GameObject> Instantiate(string address, Vector3 at) => 
            Addressables.InstantiateAsync(address, at, Quaternion.identity).Task;
    }
}