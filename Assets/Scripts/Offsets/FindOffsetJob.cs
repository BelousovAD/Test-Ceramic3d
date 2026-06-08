using Matrices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Offsets
{
    [BurstCompile]
    internal struct FindOffsetJob : IJobParallelFor
    {
        [ReadOnly] public NativeList<Matrix4x4> Model;
        [ReadOnly] public NativeList<Matrix4x4> Space;
        [ReadOnly] public MatrixComparer Comparer;
        [WriteOnly] public NativeList<Matrix4x4>.ParallelWriter Offsets;
        
        public void Execute(int index)
        {
            Matrix4x4 offset = Space[index] * Model[0].inverse;
            bool isForAll = true;

            foreach (Matrix4x4 modelMatrix in Model)
            {
                bool contains = false;

                foreach (Matrix4x4 spaceMatrix in Space)
                {
                    if (Comparer.Equals(spaceMatrix, offset * modelMatrix))
                    {
                        contains = true;
                        break;
                    }
                }

                if (contains == false)
                {
                    isForAll = false;
                    break;
                }
            }

            if (isForAll)
            {
                Offsets.AddNoResize(offset);
            }
        }
    }
}