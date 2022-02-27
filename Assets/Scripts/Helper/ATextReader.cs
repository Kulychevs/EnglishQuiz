using System.Collections.Generic;


namespace EnglishQuiz
{
    public abstract class ATextReader
    {
        #region Fields

        private const int FIRST_SEPARATORS_BEGIN = 32;
        private const int FIRST_SEPARATORS_END = 64;
        private const int SECOND_SEPARATORS_BEGIN = 91;
        private const int SECOND_SEPARATORS_END = 96;

        private readonly char[] _separators;
        private readonly HashSet<string> _usedWords;
        private List<string> _workWords;
        private readonly int _minLength;

        #endregion


        #region ClassLifeCycles

        public ATextReader(int minLength)
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

        public virtual void Init()
        {
            _usedWords.Clear();
            _workWords.Clear();
        }

        protected abstract bool GetNewWorkWords();

        protected void AddToWorkWords(string line)
        {
            line = line.ToUpper();
            _workWords.AddRange(line.Split(_separators));
        }

        private void CheckWorkWordsLength()
        {
            _workWords = _workWords.FindAll((s) => s.Length >= _minLength && _usedWords.Add(s));
        }

        #endregion
    }
}
