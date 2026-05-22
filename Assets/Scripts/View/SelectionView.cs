using Offsets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class SelectionView : MonoBehaviour
    {
        [SerializeField] private string _format = "{0}/{1}";
        [SerializeField] private TMP_Text _textField;
        [SerializeField] private Button _previousButton;
        [SerializeField] private Button _nextButton;

        private OffsetCollection _offsets;

        public void Initialize(OffsetCollection offsets)
        {
            _offsets = offsets;
            _offsets.CurrentChanged += UpdateView;
            UpdateView();
        }

        private void OnEnable()
        {
            _previousButton.onClick.AddListener(() => _offsets.Previous());
            _nextButton.onClick.AddListener(() => _offsets.Next());
        }

        private void OnDisable()
        {
            _previousButton.onClick.RemoveListener(() => _offsets.Previous());
            _nextButton.onClick.RemoveListener(() => _offsets.Next());
        }

        private void OnDestroy() =>
            _offsets.CurrentChanged -= UpdateView;

        private void UpdateView() =>
            _textField.text = string.Format(_format, _offsets.CurrentNumber, _offsets.Count);
    }
}