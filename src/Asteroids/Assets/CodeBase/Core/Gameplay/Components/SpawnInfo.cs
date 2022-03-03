using CodeBase.Core.Common;

namespace CodeBase.Core.Gameplay.Components
{
    public readonly struct SpawnInfo
    {
        public readonly ObjectId Id;
        public readonly Vector2Data Position;
        public readonly Vector2Data Direction;

        public SpawnInfo(ObjectId id, Vector2Data position, Vector2Data direction)
        {
            Id = id;
            Position = position;
            Direction = direction;
        }
    }
}