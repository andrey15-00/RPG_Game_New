using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UnityGame.UI
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private ScreenList _screenPrefabs; 
        [SerializeField] private Transform _screensParent; 
        private Dictionary<Type, UIAbstractScreen> _spawnedScreens = new Dictionary<Type, UIAbstractScreen>();

        public void HideScreen<T>() where T : UIAbstractScreen
        {
            Type type = typeof(T);
            if (_spawnedScreens.ContainsKey(type))
            {
                T screen = GetScreen<T>();
                screen.Hide();
                LogWrapper.Log("[UISystem] Hide screen. Type: " + type);
            }
        }

        public void ShowScreen<T>() where T: UIAbstractScreen
        {
            T screen;
            Type type = typeof(T);
            if (_spawnedScreens.ContainsKey(type))
            {
                screen = GetScreen<T>();
            }
            else
            {
                screen = CreateScreen<T>();
                _spawnedScreens[type] = screen;
            }
            screen.Show();

            LogWrapper.Log("[UISystem] Shown screen. Type: " + type);
        }

        internal void LoadScreen<T>() where T : UIAbstractScreen
        {
            T screen;
            Type type = typeof(T);
            if (_spawnedScreens.ContainsKey(type))
            {
                screen = GetScreen<T>();
            }
            else
            {
                screen = CreateScreen<T>();
                _spawnedScreens[type] = screen;
            }
            screen.Hide();
        }

        internal T GetScreen<T>() where T : UIAbstractScreen
        {
            T screen;
            Type type = typeof(T);
            if (_spawnedScreens.ContainsKey(type))
            {
                screen = GetScreen<T>();
            }
            else
            {
                screen = CreateScreen<T>();
            }
            return screen as T;
        }

        [Inject] private Installer _installer;
        private T CreateScreen<T>() where T : UIAbstractScreen
        {
            Type type = typeof(T);

            T prefab = _screenPrefabs.screens.Find(screen=>screen.GetType() == type) as T;

            //T screen = Instantiate(prefab, _screensParent);
            T screen = _installer.GetContainer().InstantiatePrefabForComponent<T>(prefab, _screensParent);
            screen.Init(this);

            return screen;
        }
    }
}