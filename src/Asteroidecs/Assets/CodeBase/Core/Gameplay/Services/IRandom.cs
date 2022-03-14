namespace CodeBase.Core.Gameplay.Services
{
    public interface IRandom
    {
        int Range(int from, int to);
        float Range(float from, float to);
    }
}