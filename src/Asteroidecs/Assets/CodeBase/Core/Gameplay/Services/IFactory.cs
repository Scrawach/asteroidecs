using System.Threading.Tasks;
using CodeBase.Core.Gameplay.Components;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Services
{
    public interface IFactory
    {
        Task<int> Create(SpawnInfo info, EcsWorld world);
    }
}