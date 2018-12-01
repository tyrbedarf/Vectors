using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vectors
{
    [Serializable]
    public struct Vector2d
    {
        public double x;
        public double y;

        public Vector2d(Vector2d copy) 
            : this(copy.x, copy.y) { }

        public Vector2d(Vector2 copy) 
            : this(copy.x, copy.y) { }

        public Vector2d(double x) 
            : this(x, x) { }

        public Vector2d(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2d Zero { get { return new Vector2d(0); } }
        public static Vector2d One  { get { return new Vector2d(1); } }

        #region Operator+
        public static Vector2d operator+(Vector2d lhs, Vector2d rhs)
        {
            return new Vector2d(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Vector2d operator+(Vector2 lhs, Vector2d rhs)
        {
            return new Vector2d(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Vector2d operator+(Vector2d lhs, Vector2 rhs)
        {
            return new Vector2d(lhs.x + rhs.x, lhs.y + rhs.y);
        }
        #endregion

        #region Operator-
        public static Vector2d operator-(Vector2d lhs, Vector2d rhs)
        {
            return new Vector2d(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2d operator-(Vector2 lhs, Vector2d rhs)
        {
            return new Vector2d(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2d operator-(Vector2d lhs, Vector2 rhs)
        {
            return new Vector2d(lhs.x - rhs.x, lhs.y - rhs.y);
        }
        #endregion

        #region Operator*
        public static Vector2d operator*(double lhs, Vector2d rhs)
        {
            return new Vector2d(lhs * rhs.x, lhs * rhs.y);
        }

        public static Vector2d operator*(Vector2d lhs, double rhs)
        {
            return new Vector2d(lhs.x * rhs, lhs.y * rhs);
        }
        #endregion

        public double SqrMagnitude()
        {
            return (x * x) + (y * y);
        }

        public double Magnitude()
        {
            return System.Math.Sqrt(SqrMagnitude());
        }

        public override int GetHashCode()
        {
            return 
                (x.GetHashCode() << 16) ^ 
                (y.GetHashCode() <<  0);
        }

        public static bool operator==(Vector2d lhs, Vector2d rhs)
        {
            return 
                System.Math.Abs(lhs.x - rhs.x) < double.Epsilon &&
                System.Math.Abs(lhs.y - rhs.y) < double.Epsilon;
        }

        public static bool operator!=(Vector2d lhs, Vector2d rhs)
        {
            return lhs != rhs;
        }

        public override bool Equals(object obj)
        {
            if(obj is Vector2d)
            {
                var vec = (Vector2d) obj;
                return vec == this;
            }

            return false;
        }
    }
}
