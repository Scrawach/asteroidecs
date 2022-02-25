using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Services;
using UnityEngine;

namespace CodeBase.Engine.Services
{
    public class UnityInput : MonoBehaviour, IInput
    {
        public Vector2Data MousePosition { get; }
        
        public Vector2Data MovementDirection { get; }
        
        public bool IsFireButtonPressed() => 
            Input.GetKeyDown(KeyCode.A);
    }
}
