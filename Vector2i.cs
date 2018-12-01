using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vectors
{
    [Serializable]
    public struct Vector2i
    {
        public int x;
        public int y;

        public Vector2i(int x) 
            : this(x, x) { }

        public Vector2i(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }

        public override int GetHashCode()
        {
            return (x << 16) ^ (y << 0);
        }

        public override bool Equals(object obj)
        {
            if(obj == null || obj.GetType() != typeof(Vector2i))
            {
                return false;
            }

            return this == (Vector2i) obj;
        }

        public static bool operator==(Vector2i lhs, Vector2i rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }

        public static bool operator!=(Vector2i lhs, Vector2i rhs)
        {
            return !(lhs == rhs);
        }

    }
}