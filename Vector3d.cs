using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zeta
{
    [Serializable]
    public struct Vector3d : IEquatable<Vector3d>
    {
        public double x;
        public double y;
        public double z;

        public Vector3d(Vector3 copy)
            : this(copy.x, copy.y, copy.z) { }

        public Vector3d(Vector3d copy)
            : this(copy.x, copy.y, copy.z) { }

        public Vector3d(double x)
            : this(x, x, x) { }

        public Vector3d(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3d Zero { get { return new Vector3d(0); } }
        public static Vector3d One { get { return new Vector3d(1); } }
        public static Vector3d Forward { get { return new Vector3d(1, 0, 0); } }
        public static Vector3d Up { get { return new Vector3d(0, 1, 0); } }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", x, y, z);
        }

        #region Operator+
        public static Vector3d operator +(Vector3d lhs, Vector3d rhs)
        {
            return new Vector3d(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        public static Vector3d operator +(Vector3 lhs, Vector3d rhs)
        {
            return new Vector3d(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        public static Vector3d operator +(Vector3d lhs, Vector3 rhs)
        {
            return new Vector3d(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }
        #endregion

        #region Operator-
        public static Vector3d operator -(Vector3d lhs, Vector3d rhs)
        {
            return new Vector3d(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        public static Vector3d operator -(Vector3 lhs, Vector3d rhs)
        {
            return new Vector3d(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        public static Vector3d operator -(Vector3d lhs, Vector3 rhs)
        {
            return new Vector3d(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }
        #endregion

        #region Operator*
        public static Vector3d operator *(double lhs, Vector3d rhs)
        {
            return new Vector3d(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }

        public static Vector3d operator *(Vector3d lhs, double rhs)
        {
            return new Vector3d(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }

        public static Vector3d operator /(Vector3d a, double d)
        {
            return new Vector3d(a.x / d, a.y / d, a.z / d);
        }
        #endregion

        public double SqrMagnitude()
        {
            return (x * x) + (y * y) + (z * z);
        }

        public double Magnitude()
        {
            return System.Math.Sqrt(SqrMagnitude());
        }

        public static Vector3d Cross(Vector3d lhs, Vector3d rhs)
        {
            return new Vector3d(
                lhs.y * rhs.z - lhs.z * rhs.y,
                lhs.z * rhs.x - lhs.x * rhs.z,
                lhs.x * rhs.y - lhs.y * rhs.x);
        }

        public Vector3d Normalize()
        {
            double num = Magnitude();
            if(num > 9.99999974737875E-06)
                return this / num;
            else
                return Zero;
        }

        public override int GetHashCode()
        {
            return
                (x.GetHashCode() << 20) ^
                (y.GetHashCode() << 10) ^
                (z.GetHashCode() << 0);
        }

        public static bool operator ==(Vector3d lhs, Vector3d rhs)
        {
            return
                Math.Abs(lhs.x - rhs.x) < double.Epsilon &&
                Math.Abs(lhs.y - rhs.y) < double.Epsilon &&
                Math.Abs(lhs.z - rhs.z) < double.Epsilon;
        }

        public static bool operator !=(Vector3d lhs, Vector3d rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            if(obj is Vector3d)
            {
                return (Vector3d)obj == this;
            }

            return false;
        }

        public bool Equals(Vector3d other)
        {
            return this == other;
        }
    }
}
