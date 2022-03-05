using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Services.Meta;
using Leopotam.Ecs;

namespace CodeBase.Core
{
    public class Game
    {
        private readonly IDebug _debug;
        private readonly EcsWorld _world;
        private readonly EcsSystems _systems;
        private readonly SystemBuilder _builder;

        public Game(IInput input, IFactory factory, ITime time, IDebug debug, IGameScreen gameScreen, IRandom random)
        {
            _debug = debug;
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            Wallet = new WalletService();
            _builder = new SystemBuilder(_world, input, factory, time, gameScreen, random, Wallet);
        }

        public IWallet Wallet { get; }

        public void Start()
        {
            _debug.Register(_world);
            _debug.Register(_systems);
            _systems
                .Add(_builder.Input())
                .Add(_builder.Movement())
                .Add(_builder.Spawn())
                .Add(_builder.Shoot())
                .Add(_builder.Lifecycle())
                .Add(_builder.Physics())
                .Init();
        }

        public void Update() => 
            _systems.Run();
    }
}
