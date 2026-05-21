using TMPro;
using UnityEngine;

namespace Offsets
{
    [RequireComponent(typeof(TMP_Text))]
    internal class OffsetTextView : MonoBehaviour
    {
        [SerializeField] private OffsetContainer _offset;
        [SerializeField] private string _format = "{0}/{1}";

        private TMP_Text _textField;

        private void Awake() =>
            _textField = GetComponent<TMP_Text>();

        private void OnEnable()
        {
            _offset.Calculated += UpdateView;
            _offset.NumberChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable()
        {
            _offset.Calculated -= UpdateView;
            _offset.NumberChanged -= UpdateView;
        }

        private void UpdateView() =>
            _textField.text = string.Format(_format, _offset.Number, _offset.Max);
    }
}