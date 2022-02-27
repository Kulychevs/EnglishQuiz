using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace EnglishQuiz
{
    public sealed class TextReader : ATextReader
    {
        #region Fields

        private StreamReader _streamReader;
        private readonly string _path;

        #endregion


        #region ClassLifeCycles

        public TextReader(string path, int minLength) : base(minLength)
        {
            path += ".txt";
            _path = Path.Combine(Application.streamingAssetsPath, path);
        }

        #endregion


        #region Methods

        public override void Init()
        {
            base.Init();
            _streamReader?.Close();
            _streamReader = new StreamReader(_path);
        }

        protected override bool GetNewWorkWords()
        {
            string line;
            if ((line = _streamReader.ReadLine()) != null)
            {
                AddToWorkWords(line);
                return true;
            }
            return false;
        }

        #endregion
    }
}
