using UnityEngine;
using UnityGame.UI;
using Zenject;

namespace UnityGame.GameLogic
{
    public class InteractablesSystem : MonoBehaviour
    {
        [Inject] private UISystem _uiSystem;

        public void RegisterContainer(Container container)
        {
            container.InteractStarted += OnInteractStarted;
            container.InteractFinished += OnInteractFinished;
        }

        public void UnregisterContainer(Container container)
        {
            container.InteractStarted -= OnInteractStarted;
            container.InteractFinished -= OnInteractFinished;
        }

        private void OnInteractStarted(Container container)
        {
            UIContainerScreen screen = _uiSystem.GetScreen<UIContainerScreen>();
            screen.Init(container);
            screen.Show();
        }

        private void OnInteractFinished(Container container)
        {
            _uiSystem.ShowScreen<UIGameplayScreen>();
        }
    }
}
