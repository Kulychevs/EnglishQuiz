using System;
using UnityEngine;
using UnityEngine.UI;


namespace EnglishQuiz
{
    public sealed class MenuView: BaseUiView
    {
        public Action OnRetryButtonClick = delegate { };

        [SerializeField] private Text _text;
        [SerializeField] private Button _retryButton;

        private void OnEnable()
        {
            _retryButton.onClick.AddListener(ButtonClick);
        }

        private void OnDisable()
        {
            _retryButton.onClick.RemoveListener(ButtonClick);
        }

        public void SetText(string text)
        {
            _text.text = text;
        }

        private void ButtonClick()
        {
            OnRetryButtonClick.Invoke();
        }
    }
}
