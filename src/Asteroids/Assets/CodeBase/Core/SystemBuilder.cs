using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Systems.InputSystems;
using CodeBase.Core.Gameplay.Systems.LifecycleSystems;
using CodeBase.Core.Gameplay.Systems.MovementSystems;
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

        public SystemBuilder(EcsWorld world, IInput input, IFactory factory, ITime time)
        {
            _world = world;
            _input = input;
            _factory = factory;
            _time = time;
        }
        
        public EcsSystems Input() =>
            new EcsSystems(_world, "Input Systems")
                .OneFrame<FireButtonPressedTag>()
                .Add(new KeyboardInputSystem(_input))
                .Add(new MouseInputSystem(_input));
        
        public EcsSystems Movement() =>
            new EcsSystems(_world, "Movement Systems")
                .Add(new ForwardMovementSystem())
                .Add(new MoveSystem(_time))
                .Add(new UpdateBodySystem());

        public EcsSystems Spawn() =>
            new EcsSystems(_world, "Spawn Systems")
                .Add(new SpawnPlayer())
                .Add(new SpawnBullet())
                .Add(new SpawnSystem(_factory));

        public EcsSystems Shoot() =>
            new EcsSystems(_world, "Shoot Systems")
                .OneFrame<ShootPoint>()
                .Add(new PlayerShoot());

        public EcsSystems Lifecycle() =>
            new EcsSystems(_world, "Lifecycle Systems")
                .Add(new LifecycleSystem(_time))
                .Add(new DestroySystem());
    }
}