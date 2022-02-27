using System;
using UnityEngine;


namespace EnglishQuiz
{
    public sealed class AlphabetController : IInitialize
    {
        #region Fields

        public Action<char> OnButtonPressed = delegate { };

        private readonly AlphabetModel _alphabetModel;
        private readonly AlphabetView _alphabetView;

        #endregion


        #region ClassLifeCycles

        public AlphabetController(LetterButtonView prefab)
        {
            _alphabetView = GameObject.FindObjectOfType<AlphabetView>();
            _alphabetView.SetActive(false);
            _alphabetModel = new AlphabetModel(
                new GOCreator<LetterButtonView>(prefab, _alphabetView.GetGridTransform), ButtonPressed);
        }

        #endregion


        #region Methods

        private void ButtonPressed(char letter)
        {
            _alphabetModel.RemoveButton(letter);
            OnButtonPressed.Invoke(letter);
        }

        #endregion


        #region IInitialize

        public void InitWord()
        {
            _alphabetModel.Init();
        }

        public void InitGame()
        {
            _alphabetView.SetActive(true);
        }

        public void Clear()
        {
            _alphabetView.SetActive(false);
        }

        #endregion
    }
}
