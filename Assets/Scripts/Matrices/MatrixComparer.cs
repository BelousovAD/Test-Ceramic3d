using System.Collections.Generic;
using UnityEngine;

namespace Matrices
{
    public class MatrixComparer : IEqualityComparer<Matrix4x4>
    {
        public bool Equals(Matrix4x4 first, Matrix4x4 second) =>
            first == second;

        public int GetHashCode(Matrix4x4 matrix) =>
            matrix.GetHashCode();
    }
}