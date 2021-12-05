using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGame.UI
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private ScreenList _screenPrefabs; 
        [SerializeField] private Transform _screensParent; 
        private Dictionary<Type, UIAbstractScreen> _spawnedScreens = new Dictionary<Type, UIAbstractScreen>();
        private UIAbstractScreen _currentScreen;

        public T ChangeScreen<T>() where T: UIAbstractScreen
        {
            if(_currentScreen != null)
            {
                _currentScreen.Hide();
            }

            Type type = typeof(T);
            if (_spawnedScreens.ContainsKey(type))
            {
                _currentScreen = GetScreen<T>();
            }
            else
            {
                _currentScreen = CreateScreen<T>();
                _spawnedScreens[type] = _currentScreen;
            }
            _currentScreen.Show();

            LogWrapper.Log("[UISystem] Shown screen. Type: " + type);

            return _currentScreen as T;
        }

        private T GetScreen<T>() where T : UIAbstractScreen
        {
            Type type = typeof(T);
            return _spawnedScreens[type] as T;
        }

        private T CreateScreen<T>() where T : UIAbstractScreen
        {
            Type type = typeof(T);

            T prefab = _screenPrefabs.screens.Find(screen=>screen.GetType() == type) as T;

            T screen = Instantiate(prefab, _screensParent);
            screen.Init(this);

            return screen;
        }
    }
}