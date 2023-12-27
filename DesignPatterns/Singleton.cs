using UnityEngine;

namespace AdaBrain.DesignPatterns
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = (T)FindObjectOfType(typeof(T));
                if (_instance == null)
                {
                    SetupInstance();
                }

                return _instance;
            }
        }

        private static void SetupInstance()
        {
            _instance = (T)FindObjectOfType(typeof(T));
            if (_instance == null)
            {
                var gameObj = new GameObject
                {
                    name = typeof(T).Name
                };
                _instance = gameObj.AddComponent<T>();
                DontDestroyOnLoad(gameObj);
            }
        }

        private void Awake()
        {
            RemoveDuplicates();
        }

        private void RemoveDuplicates()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
