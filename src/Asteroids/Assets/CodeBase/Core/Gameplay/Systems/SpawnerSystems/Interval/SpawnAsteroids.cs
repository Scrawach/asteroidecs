using CodeBase.Core.Common;
using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Services;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.SpawnerSystems.Interval
{
    public class SpawnAsteroids : ISpawnStrategy
    {
        private readonly IGameScreen _gameScreen;
        private readonly IRandom _random;
        
        public SpawnAsteroids(IGameScreen gameScreen, IRandom random)
        {
            _random = random;
            _gameScreen = gameScreen;
        }

        public void Spawn(EcsWorld world)
        {
            var spawnPoint = RandomOnRectangle(_gameScreen.Size.X, _gameScreen.Size.Y) - _gameScreen.Size / 2f;
            var direction = TargetPoint(1f) - spawnPoint;
            world.NewEntityWith(new SpawnInfo(ObjectId.Asteroid, spawnPoint, direction.Normalize()));
        }

        private Vector2Data RandomOnRectangle(float width, float height)
        {
            var perimeter = (width + height) * 2f;
            var randomPointOnPerimeter = _random.Range(0, perimeter);

            if (randomPointOnPerimeter <= height)
                return new Vector2Data(0, randomPointOnPerimeter);

            if (randomPointOnPerimeter <= height + width)
                return new Vector2Data(randomPointOnPerimeter - height, height);

            if (randomPointOnPerimeter <= height * 2 + width)
                return new Vector2Data(width, randomPointOnPerimeter - width - height);

            return new Vector2Data(perimeter - randomPointOnPerimeter, 0);
        }

        private Vector2Data TargetPoint(float withOffset) =>
            RandomOnRectangle(_gameScreen.Size.X - withOffset, _gameScreen.Size.Y - withOffset) -
            new Vector2Data(_gameScreen.Size.X - withOffset, _gameScreen.Size.Y - withOffset) / 2f;
    }
}