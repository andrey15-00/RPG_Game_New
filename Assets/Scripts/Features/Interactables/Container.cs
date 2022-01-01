using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGame.Items;

namespace UnityGame.GameLogic
{
    public class Container : MonoBehaviour, IInteractable
    {
        [SerializeField] private Canvas _ui;
        public List<Item> items = new List<Item>();

        public event Action<Container> InteractStarted;
        public event Action<Container> InteractFinished;

        public void ShowUI()
        {
            _ui.enabled = true;
        }

        public void HideUI()
        {
            _ui.enabled = false;
        }

        public void StartInteract()
        {
            InteractStarted?.Invoke(this);
        }

        public void StopInteract()
        {
            InteractFinished?.Invoke(this);
        }
    }
}
