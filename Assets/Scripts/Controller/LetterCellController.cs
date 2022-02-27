namespace EnglishQuiz
{
    public sealed class LetterCellController
    {
        #region Fields

        private readonly LetterCellModel _cellModel;
        private readonly LetterCellView _cellView;

        #endregion


        #region Properties

        public char GetLetter => _cellModel.Letter;
        public bool IsActive => _cellModel.IsActive;
        public bool IsOpen => _cellModel.IsOpen;

        #endregion


        #region ClassLifeCycles

        public LetterCellController(GOCreator<LetterCellView> creator)
        {
            _cellModel = new LetterCellModel
            {
                IsActive = false,
                IsOpen = false
            };

            _cellView = creator.CreateButton();
        }

        #endregion


        #region Methods

        public void Activate(char letter)
        {
            _cellModel.Letter = letter;
            _cellModel.IsActive = true;
            _cellModel.IsOpen = false;
            _cellView.SetActive(true);
            _cellView.SetLetter(_cellModel.Letter);
        }

        public void OpenCell()
        {
            _cellModel.IsOpen = true;
            _cellView.ShowLetter();
        }

        public void Deactivate()
        {
            _cellModel.IsActive = false;
            _cellModel.IsOpen = false;
            _cellView.SetActive(false);
        }

        #endregion
    }
}
