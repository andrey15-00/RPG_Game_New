using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityGame.Items;
using UnityGame.Units;

namespace UnityGame.GameLogic
{
    public class InteractablesSearcher : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _searchLayers;
        private bool _enabled;
        private Player _player;

        public void Init(Player player)
        {
            _player = player;
        }

        public void Activate()
        {
            _enabled = true;
        }

        public void Deactivate()
        {
            _enabled = false;
        }

        private HashSet<IInteractable> _currentInteractables = new HashSet<IInteractable>();
        private void Update()
        {
            if (!_enabled) return;
            if (_player == null) return;

            StopInteractWithAll();

            Vector3 playerPos = _player.transform.position;

            Collider[] interactables = Physics.OverlapSphere(playerPos, _radius, _searchLayers);

            if(interactables != null && interactables.Length > 0)
            {
                foreach(var inter in interactables)
                {
                    //TODO: Optimize these get component
                    IInteractable interactable = inter.gameObject.GetComponent<IInteractable>();
                    interactable.ShowUI();
                    _currentInteractables.Add(interactable);
                }
            }
            else
            {
              //  LogWrapper.Log("[InteractablesSearcher] Found interactables: " + interactables.Length);
            }
        }

        internal IInteractable GetClosestInteractable()
        {
            if (_currentInteractables.Count == 0) return null;

            //TODO: get real closest interactable.
            return _currentInteractables.First();
        }

        private void StopInteractWithAll()
        {
            foreach (var interactable in _currentInteractables)
            {
                interactable.HideUI();
            }
            _currentInteractables.Clear();
        }
    }
}
