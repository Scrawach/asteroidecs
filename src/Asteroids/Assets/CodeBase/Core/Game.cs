using CodeBase.Core.Gameplay.Systems;
using CodeBase.Core.Infrastructure.Systems.Abstract;
using Leopotam.EcsLite;

namespace CodeBase.Core
{
    public class Game
    {
        private readonly ISystemConnect[] _externalSystems;
        private readonly EcsWorld _world;

        private EcsSystems _systems;

        public Game(EcsWorld world, params ISystemConnect[] externalSystems)
        {
            _world = world;
            _externalSystems = externalSystems;
        }

        public bool IsPlaying { get; private set; }

        public void Start()
        {
            InitWorld();
            IsPlaying = true;
        }

        public void Update() =>
            _systems.Run();

        public void Quit() =>
            IsPlaying = false;

        public void Restart()
        {
            _systems.Destroy();
            InitWorld();
        }

        private void InitWorld()
        {
            _systems = new EcsSystems(_world);

            foreach (var system in _externalSystems)
                system.ConnectTo(_systems);

            _systems.Add(new GameRestartSystem(this));
            _systems.Init();
        }
    }
}