using UnityEngine;


namespace EnglishQuiz
{
    public sealed class GOCreator<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly Transform _parent;

        public GOCreator(T prefab, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }

        public T CreateButton()
        {
            return Object.Instantiate<T>(_prefab, _parent);
        }
    }
}
