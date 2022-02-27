using UnityEngine;


namespace EnglishQuiz
{
    public sealed class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] GameSettings _settings;

        #endregion


        #region UnityMethods

        private void Start()
        {
            new Controllers(_settings);
        }

        #endregion

    }
}
