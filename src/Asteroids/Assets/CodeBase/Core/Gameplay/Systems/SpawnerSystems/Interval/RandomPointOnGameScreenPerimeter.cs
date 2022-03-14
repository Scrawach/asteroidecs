using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Services;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.SpawnerSystems.Interval
{
    public class RandomPointOnGameScreenPerimeter : ISpawnPositionPolicy
    {
        private readonly IGameScreen _gameScreen;
        private readonly IRandom _random;

        public RandomPointOnGameScreenPerimeter(IGameScreen gameScreen, IRandom random)
        {
            _gameScreen = gameScreen;
            _random = random;
        }
        
        public Vector2Data SpawnPosition(EcsWorld world) =>
            RandomOnRectangle(_gameScreen.Size.X, _gameScreen.Size.Y) - _gameScreen.Size / 2f;

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
    }
}