using System;
using System.Collections.Generic;
using UnityEngine;


namespace EnglishQuiz
{
    public sealed class WordController : IInitialize
    {
        #region Fields

        public Action OnEndOfWords = delegate { };
        public Action OnWrongLetter = delegate { };
        public Action OnWordGuessed = delegate { };

        private string _word;
        private readonly List<LetterCellController> _cells;
        private readonly WordView _wordView;
        private readonly GOCreator<LetterCellView> _creator;
        private readonly ATextReader _textReader;

        #endregion


        #region ClassLifeCycles

        public WordController(LetterCellView prefab, string pathToFile, int minWordLength)
        {
            _cells = new List<LetterCellController>();
            _wordView = GameObject.FindObjectOfType<WordView>();
            _creator = new GOCreator<LetterCellView>(prefab, _wordView.GetGridTransform);
#if UNITY_ANDROID || UNITY_WEBGL
            _textReader = new TextReaderAndroid(pathToFile, minWordLength);
#else
            _textReader = new TextReader(pathToFile, minWordLength);
#endif
            _wordView.SetActive(false);
        }

        #endregion


        #region Methods

        public void OpenLetter(char letter)
        {
            letter = ToUpper(letter);
            var cells = _cells.FindAll((c) => c.IsActive && c.GetLetter == letter);
            foreach (var cell in cells)
            {
                cell.OpenCell();
            }
            if (cells.Count == 0)
                OnWrongLetter.Invoke();
            CheckIsWordGuessed();
        }

        private char ToUpper(char c)
        {
            if (c >= 'a' && c <= 'z')
            {
                int i = c - 32;
                return (char)i;
            }
            return c;
        }

        private void ConstructCells()
        {
            var size = _word.Length - _cells.Count;
            for (int i = 0; i < size; i++)
            {
                _cells.Add(new LetterCellController(_creator));
            }
        }

        private void ActivateCells()
        {
            for (int i = 0; i < _word.Length; i++)
            {
                _cells[i].Activate(_word[i]);
            }
        }

        private void DeactivateExtraCells()
        {
            for (int i = _word.Length; i < _cells.Count; i++)
            {
                _cells[i].Deactivate();
            }
        }

        private void CheckIsWordGuessed()
        {
            var isGuessed = true;
            for (int i = 0; i < _word.Length; i++)
            {
                if (!_cells[i].IsOpen)
                {
                    isGuessed = false;
                    break;
                }
            }
            if (isGuessed)
                OnWordGuessed.Invoke();
        }

        #endregion


        #region IInitialize

        public void InitWord()
        {
            _word = _textReader.GetWord();
            if (_word == null)
            {
                OnEndOfWords.Invoke();
                return;
            }
            ConstructCells();
            ActivateCells();
            DeactivateExtraCells();
        }
        public void InitGame()
        {
            _wordView.SetActive(true);
            _textReader.Init();
        }

        public void Clear()
        {
            _wordView.SetActive(false);
        }

        #endregion
    }
}
