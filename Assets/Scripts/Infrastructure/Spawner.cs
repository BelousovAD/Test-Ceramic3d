using Matrices;
using UnityEngine;

namespace Infrastructure
{
    internal class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private Transform _prefab;
        
        private MatrixCollection _collection;

        public void Initialize(MatrixCollection collection) =>
            _collection = collection;

        public void Spawn()
        {
            foreach (Matrix4x4 matrix in _collection.Matrices)
            {
                Transform instance = Instantiate(_prefab, _parent);
                instance.SetLocalPositionAndRotation(matrix.GetPosition(), matrix.rotation);
                instance.localScale = matrix.lossyScale;
            }
        }
    }
}