using UnityEngine;
using UnityEngine.UI;


namespace EnglishQuiz
{
    public sealed class InfoView : BaseUiView
    {
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _attemptsText;

        public void SetScore(int score)
        {
            _scoreText.text = $"Score: {score}";
        }

        public void SetAttempts(int attempts)
        {
            _attemptsText.text = $"Attempts: {attempts}";
        }
    }
}
