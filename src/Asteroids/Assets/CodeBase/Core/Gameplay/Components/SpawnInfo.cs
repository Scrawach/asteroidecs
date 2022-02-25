using CodeBase.Core.Common;

namespace CodeBase.Core.Gameplay.Components
{
    public readonly struct SpawnInfo
    {
        public readonly ObjectId Id;
        public readonly Vector2Data Position;

        public SpawnInfo(ObjectId id, Vector2Data position)
        {
            Id = id;
            Position = position;
        }
    }
}