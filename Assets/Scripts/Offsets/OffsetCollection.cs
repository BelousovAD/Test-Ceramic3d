using System;
using System.Collections.Generic;
using UnityEngine;

namespace Offsets
{
    public class OffsetCollection
    {
        private List<Matrix4x4> _offsets = new ();
        private int _index;

        public event Action CurrentChanged;
    
        public int Count => _offsets.Count;

        public int CurrentNumber => Count > 0 ? _index + 1 : 0;

        public Matrix4x4 Current => Count > 0 ? _offsets[_index] : Matrix4x4.identity;

        public void Initialize(IEnumerable<Matrix4x4> offsets)
        {
            _offsets = new List<Matrix4x4>(offsets);
            _index = 0;
            CurrentChanged?.Invoke();
        }

        public void Next() =>
            MoveBy(1);

        public void Previous() =>
            MoveBy(-1);

        private void MoveBy(int offset)
        {
            if (Count == 0)
            {
                return;
            }

            _index = (_index + offset + Count) % Count;
            CurrentChanged?.Invoke();
        }
    }
}