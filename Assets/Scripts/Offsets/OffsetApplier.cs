using UnityEngine;

namespace Offsets
{
    internal class OffsetApplier : MonoBehaviour
    {
        [SerializeField] private OffsetContainer _offset;

        private void OnEnable()
        {
            _offset.Calculated += Apply;
            _offset.NumberChanged += Apply;
            Apply();
        }

        private void OnDisable()
        {
            _offset.Calculated -= Apply;
            _offset.NumberChanged -= Apply;
        }

        private void Apply()
        {
            transform.SetLocalPositionAndRotation(_offset.Current.GetPosition(), _offset.Current.rotation);
            transform.localScale = _offset.Current.lossyScale;
        }
    }
}