using CodeBase.Core.Common;

namespace CodeBase.Core.Gameplay.Components
{
    public interface IBody
    {
        void Move(Vector2Data movement);
        void Rotate(float angle);
    }
}