using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    [RequireComponent(typeof(Button))]
    public abstract class AbstractButton : MonoBehaviour
    {
        private Button _button;

        protected virtual void Awake() =>
            _button = GetComponent<Button>();

        protected virtual void OnEnable() =>
            _button.onClick.AddListener(HandleClick);

        protected virtual void OnDisable() =>
            _button.onClick.RemoveListener(HandleClick);

        protected abstract void HandleClick();
    }
}