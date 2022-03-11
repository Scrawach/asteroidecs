using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Services.Meta
{
    public class RestartService : IRestartService
    {
        private readonly EcsWorld _world;

        public RestartService(EcsWorld world) => _world = world;

        public void Restart()
        {
            var pool = _world.GetPool<RestartButtonPressedTag>();
            pool.Add(_world.NewEntity());
        }
    }
}