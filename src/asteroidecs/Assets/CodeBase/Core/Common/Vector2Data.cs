using System;

namespace CodeBase.Core.Common
{
    [Serializable]
    public struct Vector2Data
    {
        public float X;
        public float Y;

        public Vector2Data(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() =>
            $"({X}, {Y})";

        public static Vector2Data Lerp(Vector2Data a, Vector2Data b, float t) =>
            new Vector2Data(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t);

        public static Vector2Data operator +(Vector2Data left, Vector2Data right) =>
            new Vector2Data(left.X + right.X, left.Y + right.Y);

        public static Vector2Data operator -(Vector2Data left, Vector2Data right) =>
            new Vector2Data(left.X - right.X, left.Y - right.Y);

        public static Vector2Data operator *(Vector2Data left, float value) =>
            new Vector2Data(left.X * value, left.Y * value);

        public static Vector2Data operator /(Vector2Data left, float value) =>
            new Vector2Data(left.X / value, left.Y / value);
    }
}