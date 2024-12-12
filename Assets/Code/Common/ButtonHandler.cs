using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Common
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonHandler : MonoBehaviour
    {
        private Button _button;

        protected virtual void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        protected abstract void OnClicked();
    }
}