using UnityEngine;


namespace EnglishQuiz
{
    [CreateAssetMenu(fileName = nameof(GameSettings), menuName = "Data/" + nameof(GameSettings))]
    public sealed class GameSettings : ScriptableObject
    {
        [SerializeField] private LetterButtonView _letterButtonPrefab;
        [SerializeField] private LetterCellView _letterCellPrefab; 
        [SerializeField][Tooltip("In StreamingAssets")] private string _pathToFile;
        [SerializeField][Min(1)] private int _minWordLength = 1;
        [SerializeField][Min(0)] private int _attempts = 5;

        public LetterButtonView GetLetterButtonPrefab => _letterButtonPrefab;
        public LetterCellView GetLetterCellPrefab => _letterCellPrefab;
        public string GetPathToFile => _pathToFile;
        public int GetMinLength => _minWordLength;
        public int GetAttempts => _attempts;
    }
}
