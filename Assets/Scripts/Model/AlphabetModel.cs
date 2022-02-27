using System;
using System.Collections.Generic;


namespace EnglishQuiz
{
    public sealed class AlphabetModel
    {
        private const char FIRST_LETTER = 'A';
        private const char LAST_LETTER = 'Z';

        private readonly List<LetterButtonController> _buttons;

        public AlphabetModel(GOCreator<LetterButtonView> buttonCreator, Action<char> buttonPressed)
        {
            _buttons = new List<LetterButtonController>();
            _buttons.Capacity = LAST_LETTER - FIRST_LETTER + 1;

            for (char i = FIRST_LETTER; i <= LAST_LETTER; i++)
            {
                var button = new LetterButtonController(i, buttonCreator);
                button.OnButtonPressed += buttonPressed;
                _buttons.Add(button);
            }
        }

        public void Init()
        {
            foreach (var button in _buttons)
            {
                button.SetActive(true);
            }
        }

        public void RemoveButton(char letter)
        {
            var button = _buttons.Find((b) => b.GetLetter == letter);
            button?.SetActive(false);
        }
    }
}
