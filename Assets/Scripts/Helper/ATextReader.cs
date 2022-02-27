using System.Collections.Generic;


namespace EnglishQuiz
{
    public abstract class ATextReader
    {
        #region Fields

        private const int SEPARATORS_BEGIN = 0;
        private const int SEPARATORS_END = 127;
        private const int ALPHAS_AMOUNT = 52;

        private readonly char[] _separators;
        private readonly HashSet<string> _usedWords;
        private List<string> _workWords;
        private readonly int _minLength;

        #endregion


        #region ClassLifeCycles

        public ATextReader(int minLength)
        {
            int count = SEPARATORS_END - SEPARATORS_BEGIN + 1 - ALPHAS_AMOUNT;
            _separators = new char[count];
            int i = 0;
            for (int j = SEPARATORS_BEGIN; j <= SEPARATORS_END; j++)
            {
                if (!IsAlpha((char)j))
                {
                    _separators[i] = (char)j;
                    i++;
                }
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
        private bool IsAlpha(char c)
        {
            if ((c >= 'a' && c <= 'z')
                || (c >= 'A' && c <= 'Z'))
                return true;
            return false;
        }

        #endregion
    }
}
