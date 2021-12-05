using System.Collections.Generic;
using UnityEngine;
using UnityGame.GameLogic;
using UnityGame.Mediation;
using Zenject;

namespace UnityGame.Items
{
    public class InventorySystem : MonoBehaviour, 
        IMediatorMessageHandler<GetItemsRequest>,
        IMediatorMessageHandler<AddItemsRequest>
    {
        private ItemList _itemList;
        private IMediator<AbstractInventoryMessage> _inventoryMediator;


        public void Handle(GetItemsRequest message)
        {
            //_inventoryMediator.Publish(new GetItemsResponse(_itemList.items));
        }

        public void Handle(AddItemsRequest message)
        {
           // throw new System.NotImplementedException();
        }


        [Inject]
        private void Init(IMediator<AbstractInventoryMessage> inventoryMediator, ItemList itemList)
        {
           // inventoryMediator.SubscribeHandler<InventorySystem, GetItemsRequest>(this);

            _inventoryMediator = inventoryMediator;
            _itemList = itemList;
        }

        private ItemDefinition GetRandomItem()
        {
            int index = Random.Range(0, _itemList.items.Count);
            return _itemList.items[index];
        }

        private void Equip(Inventory inventory, ItemDefinition definition)
        {
            inventory.Add(definition);
        }

        private void RemoveAll(Inventory inventory, string id)
        {
            inventory.RemoveAll(id);
        }
    }
}
