using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Services;
using UnityEngine;

namespace CodeBase.Engine.Services
{
    public class UnityInput : IInput
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        private readonly Camera _camera;

        public UnityInput(Camera camera) =>
            _camera = camera;

        public Vector2Data MousePosition => 
            new Vector2Data(Input.mousePosition.x, Input.mousePosition.y);

        public Vector2Data WorldMousePosition
        {
            get
            {
                var position = _camera.ScreenToWorldPoint(Input.mousePosition);
                return new Vector2Data(position.x, position.y);
            }
        }

        public Vector2Data MovementDirection
        {
            get
            {
                var xDirection = Input.GetAxis(HorizontalAxis);
                var yDirection = Input.GetAxis(VerticalAxis);
                return new Vector2Data(xDirection, yDirection);
            }
        }

        public bool IsFireButtonPressed() =>
            Input.GetKeyDown(KeyCode.Mouse0);

        public bool IsLaserButtonPressed() =>
            Input.GetKeyDown(KeyCode.Mouse1);
    }
}
