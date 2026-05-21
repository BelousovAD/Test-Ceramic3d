using System;
using System.Collections.Generic;
using InputOutput;
using Matrices;
using UnityEngine;

namespace Offsets
{
    internal class OffsetContainer : MonoBehaviour
    {
        private const int Min = 0;
        private readonly Matrix4x4 Default = Matrix4x4.identity;
    
        [SerializeField] private string _filename;
        [SerializeField] private MatrixContainer _model;
        [SerializeField] private MatrixContainer _space;
    
        private List<Matrix4x4> _offsets = new ();
        private int _index;

        public event Action Calculated;
        public event Action NumberChanged;
    
        public int Max => _offsets.Count;

        public int Number => Max > Min ? _index + 1 : Min;

        public Matrix4x4 Current => Max > Min ? _offsets[_index] : Default;

        private void OnEnable()
        {
            _model.Initialized += Calculate;
            _space.Initialized += Calculate;
            Calculate();
        }

        private void OnDisable()
        {
            _model.Initialized -= Calculate;
            _space.Initialized -= Calculate;
        }

        public void Next()
        {
            if (Max <= Min)
            {
                return;
            }

            _index = (_index + 1) % Max;
            NumberChanged?.Invoke();
        }

        public void Previous()
        {
            if (Max <= Min)
            {
                return;
            }

            _index = (_index - 1 + Max) % Max;
            NumberChanged?.Invoke();
        }

        private void Calculate()
        {
            if (_model.IsInitialized && _space.IsInitialized)
            {
                _offsets = new List<Matrix4x4>(OffsetFinder.Find(_model.Matrices, _space.Matrices));
                Writer.WriteMatrices(_filename, _offsets);
                Calculated?.Invoke();
            }
        }
    }
}