using System;
namespace KewlEngine
{
    public class Vector
    {
        public float x, y;
        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector operator +(float a, Vector b) => new Vector(a + b.x, a + b.y);
        public static Vector operator -(float a, Vector b) => new Vector(a - b.x, a - b.y);
        public static Vector operator *(float a, Vector b) => new Vector(a * b.x, a * b.y);
        public static Vector operator /(float a, Vector b) => new Vector(a / b.x, a / b.y);
        public static Vector operator %(float a, Vector b) => new Vector(a % b.x, a % b.y);

        public static Vector operator +(Vector a, float b) => new Vector(a.x + b, a.y + b);
        public static Vector operator -(Vector a, float b) => new Vector(a.x - b, a.y - b);
        public static Vector operator *(Vector a, float b) => new Vector(a.x * b, a.y * b);
        public static Vector operator /(Vector a, float b) => new Vector(a.x / b, a.y / b);
        public static Vector operator %(Vector a, float b) => new Vector(a.x % b, a.y % b);

        public static Vector operator +(Vector a, Vector b) => new Vector(a.x + b.x, a.y + b.y);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.x - b.x, a.y - b.y);
        public static Vector operator *(Vector a, Vector b) => new Vector(a.x * b.x, a.y * b.y);
        public static Vector operator /(Vector a, Vector b) => new Vector(a.x / b.x, a.y / b.y);
        public static Vector operator %(Vector a, Vector b) => new Vector(a.x % b.x, a.y % b.y);

        public override string ToString() => $"{x} {y}";

        public float DistanceTo(Vector other) =>
            (float)Math.Sqrt(Math.Pow(other.x - x, 2) + Math.Pow(other.y - y, 2));
        public float GetAngle() => (float)Math.Tan(y / x);
        public Vector Normalize() => new Vector((float)Math.Cos(GetAngle()), (float)Math.Sin(GetAngle()));
        public static Vector Towards(float angle) => new Vector((float)Math.Cos(angle), (float)Math.Sin(angle));

        public static readonly Vector zero = new Vector(0, 0);
        public static readonly Vector one = new Vector(1, 1);
        public static readonly Vector right = new Vector(1, 0);
        public static readonly Vector left = new Vector(-1, 0);
        public static readonly Vector up = new Vector(0, 1);
        public static readonly Vector down = new Vector(0, -1);
    }
}
