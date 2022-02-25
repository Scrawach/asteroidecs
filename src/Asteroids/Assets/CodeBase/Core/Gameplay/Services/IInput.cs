using CodeBase.Core.Common;

namespace CodeBase.Core.Gameplay.Services
{
    public interface IInput
    {
        Vector2Data MousePosition { get; }
        Vector2Data MovementDirection { get; }
        bool IsFireButtonPressed();
    }
}