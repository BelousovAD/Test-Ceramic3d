using UnityEngine;

namespace Matrices
{
    internal class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private Transform _prefab;
        [SerializeField] private MatrixContainer _container;

        private void OnEnable() =>
            _container.Initialized += Spawn;

        private void OnDisable() =>
            _container.Initialized -= Spawn;

        private void Spawn()
        {
            foreach (Matrix4x4 matrix in _container.Matrices)
            {
                Transform instance = Instantiate(_prefab, _parent);
                instance.SetLocalPositionAndRotation(matrix.GetPosition(), matrix.rotation);
                instance.localScale = matrix.lossyScale;
            }
        }
    }
}