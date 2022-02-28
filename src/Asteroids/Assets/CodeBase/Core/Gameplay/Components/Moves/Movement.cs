using System;
using CodeBase.Core.Common;

namespace CodeBase.Core.Gameplay.Components
{
    [Serializable]
    public struct Movement
    {
        public Vector2Data Direction;
        public float Speed;
    }
}