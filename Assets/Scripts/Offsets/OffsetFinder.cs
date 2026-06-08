using System.Collections.Generic;
using Matrices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Offsets
{
    public static class OffsetFinder
    {
        private const int Batch = 500;
        
        public static IEnumerable<Matrix4x4> Find(IReadOnlyList<Matrix4x4> model, IReadOnlyList<Matrix4x4> space,
            float epsilon)
        {
            NativeList<Matrix4x4> modelNative = new (model.Count, Allocator.TempJob);

            foreach (Matrix4x4 matrix in model)
            {
                modelNative.AddNoResize(matrix);
            }
            
            NativeList<Matrix4x4> spaceNative = new (space.Count, Allocator.TempJob);
            
            foreach (Matrix4x4 matrix in space)
            {
                spaceNative.AddNoResize(matrix);
            }
            
            MatrixComparer comparer = new (epsilon);
            NativeList<Matrix4x4> offsetsNative = new (space.Count, Allocator.TempJob);
            
            FindOffsetJob job = new ()
            {
                Model = modelNative,
                Space = spaceNative,
                Comparer = comparer,
                Offsets = offsetsNative.AsParallelWriter(),
            };
            JobHandle handle = job.Schedule(space.Count, Batch);
            handle.Complete();

            HashSet<Matrix4x4> offsets = new (comparer);
            
            foreach (Matrix4x4 matrix in offsetsNative)
            {
                offsets.Add(matrix);
            }

            modelNative.Dispose();
            spaceNative.Dispose();
            offsetsNative.Dispose();

            return offsets;
        }
    }
}