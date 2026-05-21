using System.Collections.Generic;
using UnityEngine;

namespace Offsets
{
    internal class ComparerMatrix4X4 : IEqualityComparer<Matrix4x4>
    {
        public bool Equals(Matrix4x4 first, Matrix4x4 second) =>
            first.GetColumn(0) == second.GetColumn(0) &&
            first.GetColumn(1) == second.GetColumn(1) &&
            first.GetColumn(2) == second.GetColumn(2) &&
            first.GetColumn(3) == second.GetColumn(3);

        public int GetHashCode(Matrix4x4 matrix)
        {
            Vector4 column = matrix.GetColumn(0);
            int hashCode = column.GetHashCode();
            column = matrix.GetColumn(1);
            int num1 = column.GetHashCode() << 2;
            int num2 = hashCode ^ num1;
            column = matrix.GetColumn(2);
            int num3 = column.GetHashCode() >> 2;
            int num4 = num2 ^ num3;
            column = matrix.GetColumn(3);
            int num5 = column.GetHashCode() >> 1;
            
            return num4 ^ num5;
        }
    }
}