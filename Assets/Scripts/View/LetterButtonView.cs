using System;
using UnityEngine;
using UnityEngine.UI;


namespace EnglishQuiz
{
    public sealed class LetterButtonView : MonoBehaviour
    {
        #region Fields

        public Action OnClick = delegate { };

        [SerializeField] private Text _text;
        private Button _button;
        private Image _image;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        #endregion


        #region Methods

        public void SetButtonText(string text)
        {
            _text.text = text;
        }

        public void SetActive(bool isActive)
        {
            _text.enabled = isActive;
            _button.enabled = isActive;
            _image.enabled = isActive;
        }

        private void OnButtonClick()
        {
            OnClick.Invoke();
        }

        #endregion
    }
}
