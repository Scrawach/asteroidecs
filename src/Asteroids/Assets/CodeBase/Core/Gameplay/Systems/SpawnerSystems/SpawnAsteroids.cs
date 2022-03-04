using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Components;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.SpawnerSystems
{
    public class SpawnAsteroids : IEcsInitSystem
    {
        private readonly EcsWorld _world = default;
        
        public void Init()
        {
            var newEntity = _world.NewEntity();
            newEntity.Get<SpawnInfo>() = new SpawnInfo(ObjectId.Asteroid, new Vector2Data(5, 0), new Vector2Data(0, 0));
        }
    }
}