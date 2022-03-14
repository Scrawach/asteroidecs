using CodeBase.Core.Gameplay.Systems;
using CodeBase.Core.Infrastructure.Systems.Abstract;
using Leopotam.EcsLite;

namespace CodeBase.Core
{
    public class Game
    {
        private readonly IConnectableSystem[] _externalSystems;
        private readonly EcsWorld _world;
        private EcsSystems _systems;

        public Game(params IConnectableSystem[] externalSystems)
        {
            _world = new EcsWorld();
            _externalSystems = externalSystems;
        }

        public bool IsPlaying { get; private set; }

        public void Start()
        {
            InitSystems();
            IsPlaying = true;
        }

        public void Update() =>
            _systems.Run();

        public void Quit() =>
            IsPlaying = false;

        public void Restart()
        {
            _systems.Destroy();
            InitSystems();
        }

        private void InitSystems()
        {
            _systems = new EcsSystems(_world);

            foreach (var system in _externalSystems)
                system.ConnectTo(_systems);

            _systems.Add(new GameRestartSystem(this));
            _systems.Init();
        }
    }
}