using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Systems;
using CodeBase.Core.Gameplay.Systems.InputSystems;
using CodeBase.Core.Gameplay.Systems.LifecycleSystems;
using CodeBase.Core.Gameplay.Systems.MovementSystems;
using CodeBase.Core.Gameplay.Systems.ShootSystems;
using CodeBase.Core.Gameplay.Systems.SpawnerSystems;
using Leopotam.Ecs;

namespace CodeBase.Core
{
    public class Game
    {
        private readonly IDebug _debug;
        private readonly EcsWorld _world;
        private readonly EcsSystems _systems;
        private readonly SystemBuilder _builder;
        
        public Game(IInput input, IFactory factory, ITime time, IDebug debug)
        {
            _debug = debug;
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _builder = new SystemBuilder(_world, input, factory, time);
        }
        
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
                .Init();
        }

        public void Update() => 
            _systems.Run();
    }
}
