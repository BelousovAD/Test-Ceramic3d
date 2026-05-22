using System.Collections.Generic;
using System.Linq;
using Matrices;
using UnityEngine;

namespace Offsets
{
    internal static class OffsetFinder
    {
        public static IEnumerable<Matrix4x4> Find(IReadOnlyList<Matrix4x4> model, IReadOnlyList<Matrix4x4> space)
        {
            HashSet<Matrix4x4> offsets = new ();

            foreach (Matrix4x4 spaceMatrix in space)
            {
                Matrix4x4 offset = spaceMatrix * model[0].inverse;

                if (model.All(modelMatrix => space.Contains(offset * modelMatrix, new MatrixComparer())))
                {
                    offsets.Add(offset);
                }
            }

            return offsets;
        }
    }
}