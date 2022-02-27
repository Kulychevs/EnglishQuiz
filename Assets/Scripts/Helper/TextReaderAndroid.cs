using UnityEngine;


namespace EnglishQuiz
{
    public sealed class TextReaderAndroid : ATextReader
    {
        #region Fields

        private readonly TextAsset _textAsset;
        private int _index;

        #endregion


        #region ClassLifeCycles

        public TextReaderAndroid(string path, int minLength) : base(minLength)
        {
            _textAsset = Resources.Load<TextAsset>(path);
            _index = 0;
        }

        #endregion


        #region Methods


        public override void Init()
        {
            base.Init();
            _index = 0;
        }

        protected override bool GetNewWorkWords()
        {
            string line;
            var canGetNewWords = true;
            var endl = _textAsset.text.IndexOf('\n', _index);
            if (endl == -1)
            {
                line = _textAsset.text.Substring(_index);
                canGetNewWords = false;
            }
            else
                line = _textAsset.text.Substring(_index, endl - _index - 1);
            _index = endl + 1;
            AddToWorkWords(line);

            return canGetNewWords;
        }

        #endregion
    }
}
