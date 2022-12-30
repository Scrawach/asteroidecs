using CodeBase.Core.Gameplay.Services.Time;
using UnityEngine;

namespace CodeBase.Engine.Services
{
    public class UnityTime : ITime
    {
        public float Elapsed => Time.time;

        public float DeltaFrame => Time.deltaTime;
    }
}