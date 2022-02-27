using System;
using UnityEngine;


namespace EnglishQuiz
{
    public sealed class InfoController : IInitialize
    {
        #region Fields

        public Action OnAttemptsAreOver = delegate { };

        private readonly InfoModel _infoModel;
        private readonly InfoView _infoView;

        #endregion


        #region ClassLifeCycles

        public InfoController(int attempts)
        {
            _infoModel = new InfoModel(attempts);
            _infoView = GameObject.FindObjectOfType<InfoView>();
            _infoView.SetActive(false);
        }

        #endregion


        #region Methods

        public void AddScore()
        {
            _infoModel.Score += _infoModel.GetAttempts;
            _infoView.SetScore(_infoModel.Score);
        }

        public void DecreaseAttempts()
        {
            _infoModel.DecreaseAttempts();
            if (_infoModel.GetAttempts < 0)
                OnAttemptsAreOver.Invoke();
            else
                _infoView.SetAttempts(_infoModel.GetAttempts);
        }

        #endregion


        #region IInitialize

        public void InitWord()
        {
            _infoModel.ResetAttempts();
            _infoView.SetAttempts(_infoModel.GetAttempts);
        }

        public void InitGame()
        {
            _infoModel.InitGame();
            _infoView.SetScore(_infoModel.Score);
            _infoView.SetActive(true);
        }

        public void Clear()
        {
            _infoView.SetActive(false);
        }

        #endregion
    }
}
