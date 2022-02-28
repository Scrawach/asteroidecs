using System;

namespace CodeBase.Core.Common
{
    public static class Vector2DataExtensions
    {
        public static float Magnitude(this Vector2Data self) => 
            (float) Math.Sqrt(self.X * self.X + self.Y * self.Y);

        public static Vector2Data Normalize(this Vector2Data self)
        {
            var magnitude = self.Magnitude();
            return magnitude > 0.001f 
                ? new Vector2Data(self.X / magnitude, self.Y / magnitude) 
                : self;
        }
    }
}