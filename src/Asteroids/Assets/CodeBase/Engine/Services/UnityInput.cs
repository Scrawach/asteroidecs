using System;
using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Services;
using UnityEngine;

namespace CodeBase.Engine.Services
{
    public class UnityInput : MonoBehaviour, IInput
    {
        public Vector2Data MousePosition => 
            new Vector2Data(Input.mousePosition.x, Input.mousePosition.y);

        public Vector2Data WorldMousePosition
        {
            get
            {
                var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                return new Vector2Data(position.x, position.y);
            }
        }

        public Vector2Data MovementDirection
        {
            get
            {
                var xDirection = Input.GetAxis("Horizontal");
                var yDirection = Input.GetAxis("Vertical");
                return new Vector2Data(xDirection, yDirection);
            }
        }
        
        public bool IsFireButtonPressed() => 
            Input.GetKeyDown(KeyCode.Mouse0);
    }
}
