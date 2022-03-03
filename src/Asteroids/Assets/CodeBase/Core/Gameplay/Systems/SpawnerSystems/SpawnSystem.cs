using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Services;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.SpawnerSystems
{
    public class SpawnSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = default;
        private readonly EcsFilter<SpawnInfo> _spawnFilter = default;
        private readonly IFactory _factory;

        public SpawnSystem(IFactory factory) => 
            _factory = factory;

        public void Run()
        {
            if (_spawnFilter.IsEmpty())
                return;

            foreach (var index in _spawnFilter)
            {
                ref var entity = ref _spawnFilter.GetEntity(index);
                var info = entity.Get<SpawnInfo>();
                _factory.Create(info, _world);
                entity.Del<SpawnInfo>();
            }
        }
    }
}