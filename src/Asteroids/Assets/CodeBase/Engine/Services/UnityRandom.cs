using CodeBase.Core.Gameplay.Services;
using UnityEngine;

namespace CodeBase.Engine.Services
{
    public class UnityRandom : IRandom
    {
        public UnityRandom(int seed) =>
            Random.InitState(seed);

        public int Range(int from, int to) =>
            Random.Range(from, to);

        public float Range(float from, float to) =>
            Random.Range(from, to);
    }
}