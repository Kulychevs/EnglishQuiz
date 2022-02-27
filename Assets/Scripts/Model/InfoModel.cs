namespace EnglishQuiz
{
    public sealed class InfoModel
    {
        #region Fields

        public int Score;
        private readonly int _maxAttempts;
        private int _attempts;

        #endregion


        #region Properties

        public int GetAttempts => _attempts;

        #endregion


        #region ClassLifeCycles

        public InfoModel(int maxAttempts)
        {
            _maxAttempts = maxAttempts;
        }

        #endregion


        #region Methods

        public void DecreaseAttempts()
        {
            _attempts--;
        }

        public void ResetAttempts()
        {
            _attempts = _maxAttempts;
        }

        public void InitGame()
        {
            Score = 0;
        }

        #endregion
    }
}
