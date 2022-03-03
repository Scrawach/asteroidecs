using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Engine.Services
{
    public interface IAssets
    {
        void Initialize();
        Task<GameObject> Instantiate(string address);
        Task<GameObject> Instantiate(string address, Vector3 at);
        Task<GameObject> Instantiate(string address, Vector3 position, Quaternion rotation);
    }
}