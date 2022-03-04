using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Services;
using UnityEngine;

namespace CodeBase.Engine.Services
{
    public class CameraGameScreen : IGameScreen
    {
        public CameraGameScreen(Camera camera)
        {
            var verticalSize = camera.orthographicSize;
            var horizontalSize = Camera.VerticalToHorizontalFieldOfView(verticalSize, camera.aspect);
            Size = new Vector2Data(horizontalSize * 2, verticalSize * 2);
        }

        public Vector2Data Size { get; }
        
        public bool IsOutOfBorder(Vector2Data point) =>
            point.X > Size.X ||
            point.X < -Size.X ||
            point.Y > Size.Y ||
            point.Y < -Size.Y;
    }
}