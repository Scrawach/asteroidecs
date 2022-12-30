namespace CodeBase.Core.Gameplay.Services.Time
{
    public interface ITime
    {
        float Elapsed { get; }
        float DeltaFrame { get; }
    }
}