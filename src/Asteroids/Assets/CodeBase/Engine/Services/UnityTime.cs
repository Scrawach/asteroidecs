using CodeBase.Core.Gameplay.Services;

namespace CodeBase.Engine.Services
{
    public class UnityTime : ITime
    {
        public float Elapsed => 
            UnityEngine.Time.time;
        
        public float DeltaFrame => 
            UnityEngine.Time.deltaTime;
    }
}