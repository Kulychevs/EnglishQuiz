using UnityEngine;
using UnityEngine.UI;


namespace EnglishQuiz
{
    public sealed class WordView : BaseUiView
    {
        [SerializeField] private GridLayoutGroup _gridLayout;

        public Transform GetGridTransform => _gridLayout.transform;
    }
}
