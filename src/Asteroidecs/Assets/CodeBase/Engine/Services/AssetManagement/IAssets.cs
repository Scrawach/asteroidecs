using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Engine.Services.AssetManagement
{
    public interface IAssets
    {
        void Initialize();
        Task<TAsset> Load<TAsset>(string address) where TAsset : Object;
        void Cleanup();
    }
}