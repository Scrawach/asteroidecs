namespace CodeBase.Core.Gameplay.Services
{
    public interface ITime
    {
        float Elapsed { get; }
        float DeltaFrame { get; }
    }
}