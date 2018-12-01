using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vectors
{
    [Serializable]
    public struct Vector3i : IEnumerable<Vector3i>, IEquatable<Vector3i>
    {
        public int x;
        public int y;
        public int z;

        public Vector3i(int x)
            : this(x, x, x) { }

        public Vector3i(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }

        /// <summary>
        /// Return the number of elements we need for creating a flat array.
        /// </summary>
        /// <returns></returns>
        public int GetArrayCount()
        {
            return x * y * z;
        }

        /// <summary>
        /// Additon of two vector.
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns></returns>
        public static Vector3i operator +(Vector3i lhs, Vector3i rhs)
        {
            return new Vector3i(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        /// <summary>
        /// Subtracts two vectors.
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns></returns>
        public static Vector3i operator -(Vector3i lhs, Vector3i rhs)
        {
            return new Vector3i(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        /// <summary>
        /// Turn an int vector into a enumerator iterating over all three dimensions
        /// from 0 to the value of each component. 
        /// We have to iterate over chunks quite often, this helps to reduce boilerplate code.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Vector3i> GetEnumerator()
        {
            for(int a = 0; a < x; a++)
            {
                for(int b = 0; b < y; b++)
                {
                    for(int c = 0; c < z; c++)
                    {
                        yield return new Vector3i(a, b, c);
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns the position inside a flattend 3d array given the three components.
        /// Since the voxel layout of a chunk is expressed as vector3i this method
        /// is only called on the corredponding VoxelLayout vector, that handles the voxel layout.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public int GetIndex(int x, int y, int z)
        {
            return (z * this.x * this.y) + (y * this.x) + x;
        }

        public int GetIndex(Vector3i v)
        {
            return GetIndex(v.x, v.y, v.z);
        }

        /// <summary>
        /// Return the vector representing an index inside a chunk and turn it into a vector again.
        /// Since the voxel layout of a chunk is expressed as vector3i this method
        /// is only called on the corredponding VoxelLayout vector, that handles the voxel layout.
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns></returns>
        public Vector3i GetVector(int i)
        {
            int idx = i;
            int z = idx / (this.x * this.y);
            idx -= z * this.x * this.y;
            int y = idx / this.x;
            int x = idx % this.x;

            return new Vector3i(x, y, z);
        }

        public static bool operator==(Vector3i lhs, Vector3i rhs)
        {
            return 
                lhs.x == rhs.x &&
                lhs.y == rhs.y &&
                lhs.z == rhs.x;
        }

        public static bool operator!=(Vector3i lhs, Vector3i rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            if(obj is Vector3i)
            {
                var other = (Vector3i) obj;
                return 
                    x == other.x &&
                    y == other.y &&
                    z == other.z;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (x << 20) ^ (y << 10) ^ (z);
        }

        public bool Equals(Vector3i other)
        {
            // Debug.Log($"Called {this} -> {other}");
            return 
                x == other.x &&
                y == other.y &&
                z == other.z;
        }
    }
}
