using CodeBase.Core.Common;
using UnityEngine;

namespace CodeBase.Engine.Common
{
    public static class Vector2DataExtensions
    {
        public static Vector3 ToVector3(this Vector2Data self) =>
            new Vector3(self.X, self.Y, 0f);

        public static Vector2Data ToVector2Data(this Vector3 self) =>
            new Vector2Data(self.x, self.y);

        public static Quaternion ToQuaternion(this Vector2Data self)
        {
            var angle = Mathf.Atan2(self.Y, self.X) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}