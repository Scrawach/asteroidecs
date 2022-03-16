using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Engine.Services.AssetManagement
{
    public interface IAssets
    {
        void Initialize();
        Task<TAsset> Load<TAsset>(string address) where TAsset : Object;
        Task<GameObject> InstantiateAsync(string address, Vector3 position, Quaternion rotation);
        void Cleanup();
    }
}