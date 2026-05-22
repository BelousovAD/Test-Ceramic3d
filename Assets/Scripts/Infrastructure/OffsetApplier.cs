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
            _target.SetLocalPositionAndRotation(_offsets.Current.GetPosition(), _offsets.Current.rotation);
            _target.localScale = _offsets.Current.lossyScale;
        }
    }
}