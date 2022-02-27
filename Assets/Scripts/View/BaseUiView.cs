using UnityEngine;


namespace EnglishQuiz
{
    [RequireComponent(typeof(Canvas))]
    public class BaseUiView : MonoBehaviour
    {
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        public void SetActive(bool isActive)
        {
            _canvas.enabled = isActive;
        }
    }
}
