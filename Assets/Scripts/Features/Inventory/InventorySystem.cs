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
        private IMediator<InventoryUpdated> _mediator;


        [Inject]
        private void Constructor(IMediator<InventoryUpdated> mediator)
        {
            _mediator = mediator;

            LogWrapper.Log("[InventorySystem] Constructor called!");
            //TODO: load inventory from elsewhere.
            _playerInventory.Add(new Item(new ItemDefinition() { name = "FakeItem 1", id = "1" }));
            _playerInventory.Add(new Item(new ItemDefinition() { name = "FakeItem 2", id = "2" }));
            _playerInventory.Add(new Item(new ItemDefinition() { name = "FakeItem 3", id = "3" }));
        }

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
            _mediator.Publish(new InventoryUpdated());
            return true;
        }

        public bool Handle(RemoveItemRequest request)
        {
            _playerInventory.RemoveAll(request.item.Definition.id);
            return true;
        }
    }
}
