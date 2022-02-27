namespace EnglishQuiz
{
    public sealed class Initializer
    {
        private readonly IInitialize[] _initializes;

        public Initializer(IInitialize[] initializes)
        {
            _initializes = initializes;
        }

        public void InitGame()
        {
            foreach (var item in _initializes)
            {
                item.InitGame();
            }
            InitWord();
        }

        public void InitWord()
        {
            foreach (var item in _initializes)
            {
                item.InitWord();
            }
        }

        public void Clear()
        {
            foreach (var item in _initializes)
            {
                item.Clear();
            }
        }
    }
}
