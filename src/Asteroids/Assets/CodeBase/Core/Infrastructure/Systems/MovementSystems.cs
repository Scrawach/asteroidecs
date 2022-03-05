using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Systems.MovementSystems;
using Leopotam.Ecs;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class MovementSystems : ISystemBuilder
    {
        private readonly IGameScreen _gameScreen;
        private readonly ITime _time;

        public MovementSystems(IGameScreen gameScreen, ITime time)
        {
            _gameScreen = gameScreen;
            _time = time;
        }
        
        public EcsSystems Build(EcsWorld world) =>
            new EcsSystems(world, nameof(MovementSystems))
                .Add(new ForwardMovementSystem())
                .Add(new BlockPlayerMovementOutsideScreen(_gameScreen))
                .Add(new MoveSystem(_time))
                .Add(new UpdateBodySystem());
    }
}