using CodeBase.Core.Gameplay.Systems;
using CodeBase.Core.Infrastructure.Systems;
using Leopotam.Ecs;

namespace CodeBase.Core
{
    public class Game
    {
        private readonly EcsWorld _world;
        private readonly ISystemBuilder[] _builders;
        private EcsSystems _systems;

        public Game(EcsWorld world, params ISystemBuilder[] systemBuilders)
        {
            _world = world;
            _builders = systemBuilders;
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

            foreach (var builder in _builders)
                _systems.Add(builder.Build(_world));

            _systems.Add(new GameCleanUpSystem(this, _world));
            
            _systems.Init();
        }
    }
}
