using System;


namespace EnglishQuiz
{
    public sealed class LetterButtonController
    {
        #region Fields

        public Action<char> OnButtonPressed = delegate { };

        private readonly LetterButtonModel _buttonModel;
        private readonly LetterButtonView _buttonView;

        #endregion


        #region Properties

        public char GetLetter => _buttonModel.Letter;

        #endregion


        #region ClassLifeCycles

        public LetterButtonController(char letter, GOCreator<LetterButtonView> creator)
        {
            _buttonModel = new LetterButtonModel
            {
                Letter = letter
            };

            _buttonView = creator.CreateButton();
            _buttonView.OnClick += OnButtonClick;
            _buttonView.SetButtonText(_buttonModel.Letter.ToString());
        }

        #endregion


        #region Methods

        public void SetActive(bool isActive)
        {
            _buttonView.SetActive(isActive);
        }

        private void OnButtonClick()
        {
            OnButtonPressed.Invoke(_buttonModel.Letter);
        }

        #endregion
    }
}
