using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Services.Meta;
using CodeBase.Core.Infrastructure.Systems;
using Leopotam.Ecs;

namespace CodeBase.Core
{
    public class Game
    {
        private readonly IDebug _debug;
        private readonly EcsWorld _world;
        private readonly EcsSystems _systems;
        private readonly ISystemBuilder[] _builders;

        public Game(IInput input, IFactory factory, ITime time, IDebug debug, IGameScreen gameScreen, 
            IRandom random, IWallet wallet, IUiFactory uiFactory)
        {
            _debug = debug;
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _builders = new ISystemBuilder[]
            {
                new InputSystems(input),
                new MovementSystems(gameScreen, time),
                new SpawnSystems(factory, gameScreen, time, random),
                new ShootSystems(),
                new PhysicSystems(),
                new MetaSystems(wallet, uiFactory),
                new LifecycleSystems(time, gameScreen)
            };
        }
        
        public void Start()
        {
            _debug
                .Register(_world)
                .Register(_systems);

            foreach (var builder in _builders) 
                _systems.Add(builder.Build(_world));

            _systems.Init();
        }

        public void Update() => 
            _systems.Run();
    }
}
