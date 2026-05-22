using System.Collections.Generic;
using InputOutput;
using UnityEngine;

namespace Matrices
{
    public class MatrixCollection
    {
        private readonly List<Matrix4x4> _matrices;

        public MatrixCollection(string fileName) =>
            _matrices = new List<Matrix4x4>(Reader.ReadMatrices(fileName));

        public IReadOnlyList<Matrix4x4> Matrices => _matrices;
    }
}