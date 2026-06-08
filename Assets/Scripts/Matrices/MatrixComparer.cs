using System.Collections.Generic;
using UnityEngine;

namespace Matrices
{
    public readonly struct MatrixComparer : IEqualityComparer<Matrix4x4>
    {
        private const int Rank = 4;
        
        private readonly float _epsilon;

        public MatrixComparer(float epsilon) =>
            _epsilon = epsilon;
        
        public bool Equals(Matrix4x4 first, Matrix4x4 second)
        {
            for (int i = 0; i < Rank * Rank; i++)
            {
                if (Mathf.Abs(first[i] - second[i]) > _epsilon)
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHashCode(Matrix4x4 matrix)
        {
            return
                GetHashCode(matrix.GetColumn(0)) ^
                GetHashCode(matrix.GetColumn(1)) << 2 ^
                GetHashCode(matrix.GetColumn(2)) >> 2 ^
                GetHashCode(matrix.GetColumn(3)) >> 1;
        }

        private int GetHashCode(Vector4 vector) =>
            (vector / _epsilon).GetHashCode();
    }
}