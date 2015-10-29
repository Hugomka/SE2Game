using System;

namespace SE2Game.Utils
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector(Vector v) : this(v.X, v.Y) {}
        public Vector() : this(0.0f, 0.0f) {}

        public void Identity()
        {
            this.X = 0;
            this.Y = 0;
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public Vector Normalize()
        {
            double length = Length();
            if (length != 0)
            {
                return new Vector(X / length, Y / length);
            }
            return this;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }
        public static Vector operator +(Vector a, double b)
        {
            return new Vector(a.X + b, a.Y + b);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }
        public static Vector operator -(Vector a, double b)
        {
            return new Vector(a.X - b, a.Y - b);
        }

        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(a.X * b.X, a.Y * b.Y);
        }
        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.X * b, a.Y * b);
        }

        public static Vector operator /(Vector a, Vector b)
        {
            return new Vector(a.X / b.X, a.Y / b.Y);
        }
        public static Vector operator /(Vector a, double b)
        {
            return new Vector(a.X / b, a.Y / b);
        }

        public System.Drawing.PointF ToPointF()
        {
            return new System.Drawing.PointF(Convert.ToSingle(X), Convert.ToSingle(Y));
        }

        public override string ToString()
        {
            return String.Format("X = {0:0.00} Y = {1:0.00}", X, Y);
        }
    }
}
