using System.Collections.Generic;
using UnityEngine;
using UnityGame.Items;
using UnityGame.Mediation;
using UnityGame.ResponseRequestCommunication;
using UnityGame.Units;
using Zenject;

namespace UnityGame.GameLogic
{
    public class InventorySystem : MonoBehaviour,
        IRequestProcessor<GetItemsRequest, List<Item>>, 
        IRequestProcessor<AddItemRequest, bool>,
        IRequestProcessor<RemoveItemRequest, bool>
    {
        private Inventory _playerInventory = new Inventory();

        /// <summary>
        /// Get items from player's inventory.
        /// </summary>
        public List<Item> Handle(GetItemsRequest request)
        {
            return _playerInventory.GetAll();
        }

        /// <summary>
        /// Add item in player inventory.
        /// </summary>
        public bool Handle(AddItemRequest request)
        {
            _playerInventory.Add(request.item);
            return true;
        }

        public bool Handle(RemoveItemRequest request)
        {
            _playerInventory.RemoveAll(request.item.Definition.id);
            return true;
        }
    }
}
