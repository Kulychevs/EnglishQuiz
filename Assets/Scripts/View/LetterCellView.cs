using UnityEngine;
using UnityEngine.UI;


namespace EnglishQuiz
{
    public sealed class LetterCellView : MonoBehaviour
    {
        [SerializeField] private Color _closeColor;
        [SerializeField] private Color _openColor;
        [SerializeField] private Text _text;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void SetLetter(char letter)
        {
            _text.text = letter.ToString();
            _text.enabled = false;
            _image.color = _closeColor;
        }

        public void ShowLetter()
        {
            _image.color = _openColor;
            _text.enabled = true;
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}
