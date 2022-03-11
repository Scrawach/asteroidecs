using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Services;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.SpawnerSystems
{
    public class SpawnSystem : IEcsRunSystem
    {
        private readonly IFactory _factory;

        public SpawnSystem(IFactory factory) =>
            _factory = factory;

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<SpawnInfo>().End();

            var infos = world.GetPool<SpawnInfo>();
            foreach (var index in filter)
            {
                ref var info = ref infos.Get(index);
                _factory.Create(info, world);
                world.DelEntity(index);
                //infos.Del(index);
            }
        }
    }
}