using UnityEngine;


namespace EnglishQuiz
{
    public sealed class TextReaderAndroid : ATextReader
    {
        #region Fields

        private readonly TextAsset _textAsset;
        private int _index;
        private bool _canGetNewWords;

        #endregion


        #region ClassLifeCycles

        public TextReaderAndroid(string path, int minLength) : base(minLength)
        {
            _textAsset = Resources.Load<TextAsset>(path);
            _index = 0;
            _canGetNewWords = true;
        }

        #endregion


        #region Methods


        public override void Init()
        {
            base.Init();
            _index = 0;
            _canGetNewWords = true;
        }

        protected override bool GetNewWorkWords()
        {
            if (!_canGetNewWords) 
                return false;

            string line;
            var endl = _textAsset.text.IndexOf('\n', _index);
            if (endl == -1)
            {
                line = _textAsset.text.Substring(_index);
                _canGetNewWords = false;
            }
            else
                line = _textAsset.text.Substring(_index, endl - _index);
            _index = endl + 1;
            AddToWorkWords(line);

            return true;
        }

        #endregion
    }
}
