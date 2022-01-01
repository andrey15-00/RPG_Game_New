using System;
using UnityEngine;
using Zenject;

namespace UnityGame.GameLogic
{
    public class InputSystem : MonoBehaviour
    {
        [Inject] private InteractablesSearcher _interactablesSearcher;
        private IInteractable _currentInteractable;

        private bool Interacting => _currentInteractable != null;

        public event Action OpenInventory;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))// && !Interacting)
            {
                _currentInteractable = _interactablesSearcher.GetClosestInteractable();
                _currentInteractable?.StartInteract();
            }

            if (Input.GetKeyDown(KeyCode.Escape) && Interacting)
            {
                _currentInteractable.StopInteract();
                _currentInteractable = null;
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                OpenInventory?.Invoke();
            }
        }
    }
}
