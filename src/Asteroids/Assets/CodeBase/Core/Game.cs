using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Systems;
using Leopotam.Ecs;

namespace CodeBase.Core
{
    public class Game
    {
        private readonly IInput _input;
        private readonly IFactory _factory;
        private readonly EcsWorld _world;
        private readonly EcsSystems _systems;
        
        public Game(IInput input, IFactory factory)
        {
            _input = input;
            _factory = factory;
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
                .Add(SpawnSystems(_world, _factory))
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
                .Add(new InputSystem());

        private EcsSystems SpawnSystems(EcsWorld world, IFactory factory) =>
            new EcsSystems(world, "Spawn Systems")
                .Inject(factory)
                .Add(new SpawnPlayer())
                .Add(new SpawnSystem());
    }
}
