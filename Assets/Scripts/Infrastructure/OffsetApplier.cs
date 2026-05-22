using Offsets;
using UnityEngine;

namespace Infrastructure
{
    internal class OffsetApplier : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        
        private OffsetCollection _offsets;

        public void Initialize(OffsetCollection offsets)
        {
            _offsets = offsets;
            _offsets.CurrentChanged += Apply;
            Apply();
        }

        private void OnDestroy() =>
            _offsets.CurrentChanged -= Apply;

        private void Apply()
        {
            transform.SetLocalPositionAndRotation(_offsets.Current.GetPosition(), _offsets.Current.rotation);
            transform.localScale = _offsets.Current.lossyScale;
        }
    }
}