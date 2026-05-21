using System;
using System.Collections.Generic;
using InputOutput;
using UnityEngine;

namespace Matrices
{
    public class MatrixContainer : MonoBehaviour
    {
        [SerializeField] private string _filename;
    
        private List<Matrix4x4> _matrices;
        private bool _isInitialized;

        public event Action Initialized;

        public IReadOnlyList<Matrix4x4> Matrices => _matrices;

        public bool IsInitialized
        {
            get => _isInitialized;

            private set
            {
                if (value)
                {
                    _isInitialized = true;
                    Initialized?.Invoke();
                }
            }
        }
    
        private void Start()
        {
            _matrices = new List<Matrix4x4>(Reader.ReadMatrices(_filename));
            IsInitialized = true;
        }
    }
}