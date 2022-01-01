using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGame.GameLogic;
using UnityGame.Items;
using UnityGame.Mediation;
using UnityGame.ResponseRequestCommunication;
using Zenject;

namespace UnityGame.UI
{
    public class UIContainerScreen : UIAbstractScreen
    {
        [SerializeField] UIInventorySlot _slotPrefab;
        [SerializeField] Transform _containerSlotsParent;
        [SerializeField] Transform _inventorySlotsParent;
        [SerializeField] Button _exit;
        private List<UIInventorySlot> _containerSlots = new List<UIInventorySlot>();
        private List<UIInventorySlot> _inventorySlots = new List<UIInventorySlot>();
        private IRequestCaller<AddItemRequest, bool> _addItemCaller;
        private IRequestCaller<GetItemsRequest, List<Item>> _getItemsCaller;
        private IRequestCaller<RemoveItemRequest, bool> _removeItemCaller;
        private Container _container;


        public void Init(Container container)
        {
            _container = container;

            List<Item> inventoryItems = _getItemsCaller.Call(new GetItemsRequest());

            Clear();
            _containerSlots = SpawnSlots(container.items, _containerSlotsParent, OnContainerSlotClicked);
            _inventorySlots = SpawnSlots(inventoryItems, _inventorySlotsParent, OnInventorySlotClicked);
        }

        [Inject]
        private void Constructor(IRequestCaller<AddItemRequest, bool> addItemCaller, 
            IRequestCaller<GetItemsRequest, List<Item>> getItemsCaller,
            IRequestCaller<RemoveItemRequest, bool> removeItemCaller
            )
        {
            _getItemsCaller = getItemsCaller;
            _addItemCaller = addItemCaller;
            _removeItemCaller = removeItemCaller;
        }

        protected override void InitInternal()
        {
            _exit.onClick.AddListener(OnExitClicked);
        }

        private void Clear()
        {
            foreach(var slot in _containerSlots)
            {
                Destroy(slot.gameObject);
            }
            _containerSlots.Clear();

            foreach (var slot in _inventorySlots)
            {
                Destroy(slot.gameObject);
            }
            _containerSlots.Clear();
        }

        private List<UIInventorySlot> SpawnSlots(List<Item> items, Transform parent, Action<UIInventorySlot> action)
        {
            List<UIInventorySlot> result = new List<UIInventorySlot>();
            foreach(var item in items)
            {
                UIInventorySlot slot = Instantiate(_slotPrefab, parent);
                slot.Init(item);
                slot.SetClickEvent(action);
                result.Add(slot);
            }
            return result;
        }

        private void OnContainerSlotClicked(UIInventorySlot slot)
        {
            AddItemRequest request = new AddItemRequest(slot.Item);
            bool success = _addItemCaller.Call(request);

            if (success)
            {
                slot.SetClickEvent(OnInventorySlotClicked);
                _container.items.Remove(slot.Item);
                slot.transform.SetParent(_inventorySlotsParent);
            }
        }

        private void OnInventorySlotClicked(UIInventorySlot slot)
        {
            RemoveItemRequest request = new RemoveItemRequest(slot.Item);
            bool success = _removeItemCaller.Call(request);

            if (success)
            {
                slot.SetClickEvent(OnContainerSlotClicked);
                _container.items.Add(slot.Item);
                slot.transform.SetParent(_containerSlotsParent);
            }
        }

        private void OnExitClicked()
        {
            _container.StopInteract();
        }
    }
}
