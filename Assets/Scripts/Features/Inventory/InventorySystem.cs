using System.Collections.Generic;
using UnityEngine;
using UnityGame.Items;
using UnityGame.ResponseRequestCommunication;
using UnityGame.Units;
using Zenject;

namespace UnityGame.GameLogic
{
    public class InventorySystem : MonoBehaviour,
        IRequestProcessor<int, List<Item>>, 
        IRequestProcessor<Item, bool>
    {
        private Inventory _playerInventory = new Inventory();
        private Mediator<InventoryUpdated> _mediator;


        [Inject]
        private void Constructor(Mediator<InventoryUpdated> mediator)
        {
            _mediator = mediator;

            LogWrapper.Log("[InventorySystem] Constructor called!");
            //TODO: load inventory from elsewhere.
            _playerInventory.Add(new Item(new ItemDefinition() { name = "FakeItem 1" }));
            _playerInventory.Add(new Item(new ItemDefinition() { name = "FakeItem 2" }));
            _playerInventory.Add(new Item(new ItemDefinition() { name = "FakeItem 3" }));
        }

        /// <summary>
        /// Get items from player's inventory.
        /// </summary>
        public List<Item> Handle(int input)
        {
            return _playerInventory.GetAll();
        }

        /// <summary>
        /// Add item in player inventory.
        /// </summary>
        public bool Handle(Item input)
        {
            _playerInventory.Add(input);
            _mediator.Publish(new InventoryUpdated());
            return true;
        }
    }
}
