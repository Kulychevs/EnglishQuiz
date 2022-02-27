using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace EnglishQuiz
{
    public sealed class TextReader
    {
        #region Fields

        private const int FIRST_SEPARATORS_BEGIN = 32;
        private const int FIRST_SEPARATORS_END = 64;
        private const int SECOND_SEPARATORS_BEGIN = 91;
        private const int SECOND_SEPARATORS_END = 96;

        private readonly char[] _separators;
        private readonly HashSet<string> _usedWords;
        private StreamReader _streamReader;
        private List<string> _workWords;
        private readonly string _path;
        private readonly int _minLength;

        #endregion


        #region ClassLifeCycles

        public TextReader(string path, int minLength)
        {
            int count = FIRST_SEPARATORS_END - FIRST_SEPARATORS_BEGIN + 1;
            count += SECOND_SEPARATORS_END - SECOND_SEPARATORS_BEGIN + 1;
            _separators = new char[count];
            int i = 0;
            for (int j = FIRST_SEPARATORS_BEGIN; j < FIRST_SEPARATORS_END; j++, i++)
            {
                _separators[i] = (char)j;
            }
            for (int j = SECOND_SEPARATORS_BEGIN; j < SECOND_SEPARATORS_END; j++, i++)
            {
                _separators[i] = (char)j;
            }

            _usedWords = new HashSet<string>();
            _workWords = new List<string>();
            _minLength = minLength;
            _path = Application.streamingAssetsPath + "/" + path;
        }

        #endregion


        #region Methods

        public string GetWord()
        {
            var isEOF = false;
            while (_workWords.Count == 0)
            {
                if (!GetNewWorkWords())
                {
                    isEOF = true;
                    break;
                }
                CheckWorkWordsLength();
            }

            string word = null;
            if (!isEOF)
            {
                word = _workWords[0];
                _workWords.RemoveAt(0);
            }

            return word;
        }

        public void Init()
        {
            _usedWords.Clear();
            _workWords.Clear();
            _streamReader?.Close();
            _streamReader = new StreamReader(_path);
        }

        private bool GetNewWorkWords()
        {
            string line;
            if ((line = _streamReader.ReadLine()) != null)
            {
                line = line.ToUpper();
                _workWords.AddRange(line.Split(_separators));
                return true;
            }
            return false;
        }

        private void CheckWorkWordsLength()
        {
            _workWords = _workWords.FindAll((s) => s.Length >= _minLength && _usedWords.Add(s));
        }

        #endregion
    }
}
