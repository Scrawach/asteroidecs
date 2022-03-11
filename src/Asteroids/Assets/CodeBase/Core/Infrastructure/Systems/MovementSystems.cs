using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Systems.MovementSystems;
using CodeBase.Core.Infrastructure.Systems.Abstract;
using Leopotam.EcsLite;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class MovementSystems : IConnectableSystem
    {
        private readonly IGameScreen _gameScreen;
        private readonly ITime _time;

        public MovementSystems(IGameScreen gameScreen, ITime time)
        {
            _gameScreen = gameScreen;
            _time = time;
        }

        public EcsSystems ConnectTo(EcsSystems systems) =>
            systems
                .Add(new ForwardMovementSystem())
                .Add(new BlockPlayerMovementOutsideScreen(_gameScreen))
                .Add(new MoveSystem(_time))
                .Add(new UpdateBodySystem());
    }
}