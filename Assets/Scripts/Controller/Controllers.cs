namespace EnglishQuiz
{
    public sealed class Controllers
    {
        #region ClassLyfeCycles

        public Controllers(GameSettings settings)
        {
            var alphabetController = new AlphabetController(settings.GetLetterButtonPrefab);
            var wordController = new WordController(settings.GetLetterCellPrefab, settings.GetPathToFile, settings.GetMinLength);
            var infoController = new InfoController(settings.GetAttempts);
            var menuController = new MenuController();

            var initializes = new IInitialize[]
            {
                alphabetController,
                wordController,
                infoController
            };
            var initializer = new Initializer(initializes);

            menuController.OnRetryButtonClick += initializer.InitGame;
            alphabetController.OnButtonPressed += wordController.OpenLetter;
            wordController.OnWrongLetter += infoController.DecreaseAttempts;

            wordController.OnWordGuessed += infoController.AddScore;
            wordController.OnWordGuessed += initializer.InitWord;

            wordController.OnEndOfWords += menuController.ActivateWinMenu;
            wordController.OnEndOfWords += initializer.Clear;

            infoController.OnAttemptsAreOver += menuController.ActivateLoseMenu;
            infoController.OnAttemptsAreOver += initializer.Clear;

            initializer.InitGame();
        }

        #endregion
    }
}

