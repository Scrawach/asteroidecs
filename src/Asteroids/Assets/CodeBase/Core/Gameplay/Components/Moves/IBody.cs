using CodeBase.Core.Common;

namespace CodeBase.Core.Gameplay.Components.Moves
{
    public interface IBody
    {
        void Move(Vector2Data movement);
        void Rotate(Vector2Data direction);
    }
}