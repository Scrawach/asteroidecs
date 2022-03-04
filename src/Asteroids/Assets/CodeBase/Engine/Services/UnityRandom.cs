using CodeBase.Core.Gameplay.Services;

namespace CodeBase.Engine.Services
{
    public class UnityRandom : IRandom
    {
        public int Range(int @from, int to) => 
            UnityEngine.Random.Range(@from, to);

        public float Range(float @from, float to) => 
            UnityEngine.Random.Range(@from, to);
    }
}