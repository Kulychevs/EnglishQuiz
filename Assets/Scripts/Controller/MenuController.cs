using System;
using UnityEngine;


namespace EnglishQuiz
{
    public sealed class MenuController
    {
        #region Fields

        public Action OnRetryButtonClick = delegate { };

        private const string WIN_TEXT = "YOU WIN!!!";
        private const string LOSE_TEXT = "Attempts are over...";

        private readonly MenuView _menuView;

        #endregion


        #region ClassLifeCycles

        public MenuController()
        {
            _menuView = GameObject.FindObjectOfType<MenuView>();
            _menuView.OnRetryButtonClick += RetryButtonClick;
        }

        #endregion


        #region Methods

        public void ActivateWinMenu()
        {
            ActivateMenu(WIN_TEXT);
        }

        public void ActivateLoseMenu()
        {
            ActivateMenu(LOSE_TEXT);
        }

        private void DeactivateMenu()
        {
            _menuView.SetActive(false);
        }

        private void ActivateMenu(string text)
        {
            _menuView.SetActive(true);
            _menuView.SetText(text);
        }

        private void RetryButtonClick()
        {
            DeactivateMenu();
            OnRetryButtonClick.Invoke();
        }

        #endregion
    }
}
