using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Components.Meta;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Services.Meta;
using CodeBase.Core.Gameplay.Systems.InputSystems;
using CodeBase.Core.Gameplay.Systems.LifecycleSystems;
using CodeBase.Core.Gameplay.Systems.MetaSystems;
using CodeBase.Core.Gameplay.Systems.MovementSystems;
using CodeBase.Core.Gameplay.Systems.PhysicsSystems;
using CodeBase.Core.Gameplay.Systems.PhysicsSystems.Strategies;
using CodeBase.Core.Gameplay.Systems.ShootSystems;
using CodeBase.Core.Gameplay.Systems.SpawnerSystems;
using Leopotam.Ecs;

namespace CodeBase.Core
{
    public class SystemBuilder
    {
        private readonly EcsWorld _world;

        private readonly IInput _input;
        private readonly IFactory _factory;
        private readonly ITime _time;
        private readonly IGameScreen _gameScreen;
        private readonly IRandom _random;
        private readonly IWallet _wallet;

        public SystemBuilder(EcsWorld world, IInput input, IFactory factory, 
            ITime time, IGameScreen gameScreen, IRandom random, IWallet wallet)
        {
            _world = world;
            _input = input;
            _factory = factory;
            _time = time;
            _gameScreen = gameScreen;
            _random = random;
            _wallet = wallet;
        }
        
        public EcsSystems Input() =>
            new EcsSystems(_world, "Input Systems")
                .OneFrame<FireButtonPressedTag>()
                .Add(new KeyboardInputSystem(_input))
                .Add(new MouseInputSystem(_input));
        
        public EcsSystems Movement() =>
            new EcsSystems(_world, "Movement Systems")
                .Add(new ForwardMovementSystem())
                .Add(new BlockPlayerMovementOutsideScreen(_gameScreen))
                .Add(new MoveSystem(_time))
                .Add(new UpdateBodySystem());

        public EcsSystems Spawn() =>
            new EcsSystems(_world, "Spawn Systems")
                .Add(new SpawnPlayer())
                .Add(new SpawnAsteroids(_time, _gameScreen, _random))
                .Add(new SpawnBullet())
                .Add(new SpawnSystem(_factory));

        public EcsSystems Shoot() =>
            new EcsSystems(_world, "Shoot Systems")
                .OneFrame<ShootPoint>()
                .Add(new PlayerShoot());

        public EcsSystems Lifecycle() =>
            new EcsSystems(_world, "Lifecycle Systems")
                .Add(new LifecycleSystem(_time))
                .Add(new KillOutOfBorderObjects(_gameScreen))
                .Add(new DestroySystem())
                .OneFrame<DestroyTag>();

        public EcsSystems Meta() =>
            new EcsSystems(_world, "Meta Systems")
                .Add(new DestructionBonusSystem(_wallet))
                .Add(new GameOverSystem());

        public IEcsSystem Physics() =>
            new EcsSystems(_world, "Physics Systems")
                .Add(new TriggerSystemBetween<PlayerTag, AsteroidTag>(new DestroyTriggeredEntities()))
                .Add(new TriggerSystemBetween<AsteroidTag, BulletTag>(new PlayerDestroyTriggeredEntities()))
                .Add(new TriggerSystemBetween<AsteroidTag, AsteroidTag>(new SumAndInverseMovementDirection()))
                .OneFrame<OnTriggerEnter>();
    }
}