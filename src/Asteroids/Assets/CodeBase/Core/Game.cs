using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Systems;
using CodeBase.Core.Gameplay.Systems.InputSystems;
using CodeBase.Core.Gameplay.Systems.MovementSystems;
using CodeBase.Core.Gameplay.Systems.ShootSystems;
using CodeBase.Core.Gameplay.Systems.SpawnerSystems;
using Leopotam.Ecs;

namespace CodeBase.Core
{
    public class Game
    {
        private readonly IInput _input;
        private readonly IFactory _factory;
        private readonly ITime _time;
        private readonly EcsWorld _world;
        private readonly EcsSystems _systems;
        
        public Game(IInput input, IFactory factory, ITime time)
        {
            _input = input;
            _factory = factory;
            _time = time;
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
        }
        
        public void Start()
        {
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif

            _systems
                .Add(InputSystems(_world, _input))
                .Add(MovementSystems(_world, _time))
                .Add(SpawnSystems(_world, _factory))
                .Add(ShootSystems(_world))
                .Init();
        }

        public void Update()
        {
            _systems.Run();
        }

        private EcsSystems InputSystems(EcsWorld world, IInput input) =>
            new EcsSystems(world, "Input Systems")
                .OneFrame<FireButtonPressedTag>()
                .Inject(input)
                .Add(new KeyboardInputSystem())
                .Add(new MouseInputSystem());

        private EcsSystems MovementSystems(EcsWorld world, ITime time) =>
            new EcsSystems(world, "Movement Systems")
                .Inject(time)
                .Add(new ForwardMovementSystem())
                .Add(new MoveSystem())
                .Add(new UpdateBodySystem());

        private EcsSystems SpawnSystems(EcsWorld world, IFactory factory) =>
            new EcsSystems(world, "Spawn Systems")
                .Inject(factory)
                .Add(new SpawnPlayer())
                .Add(new SpawnBullet())
                .Add(new SpawnSystem());

        private EcsSystems ShootSystems(EcsWorld world) =>
            new EcsSystems(world, "Shoot Systems")
                .OneFrame<ShootPoint>()
                .Add(new PlayerShoot());
    }
}
