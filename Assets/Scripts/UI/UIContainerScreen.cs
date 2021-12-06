using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGame.GameLogic;
using UnityGame.Items;
using UnityGame.Mediation;
using Zenject;

namespace UnityGame.UI
{
    public class UIContainerScreen : UIAbstractScreen
    {
        [SerializeField] UIInventorySlot _slotPrefab;
        [SerializeField] Transform _slotsParent;
        [SerializeField] Button _exit;
        private List<UIInventorySlot> _slots = new List<UIInventorySlot>();
        private IMediator<AbstractInventoryMessage> _inventoryMediator;
        private Container _container;


        public void Init(Container container)
        {
            _container = container;
            Clear();
            SpawnSlots(container.items);
        }

        [Inject]
        private void Constructor(IMediator<AbstractInventoryMessage> inventoryMediator)
        {
            _inventoryMediator = inventoryMediator;
        }

        protected override void InitInternal()
        {
            _exit.onClick.AddListener(OnExitClicked);
        }

        private void Clear()
        {
            foreach(var slot in _slots)
            {
                Destroy(slot.gameObject);
            }
            _slots.Clear();
        }

        private void SpawnSlots(List<Item> items)
        {
            foreach(var item in items)
            {
                UIInventorySlot slot = Instantiate(_slotPrefab, _slotsParent);
                slot.Init(item, OnSlotClicked);
                _slots.Add(slot);
            }
        }

        private void OnSlotClicked(UIInventorySlot slot)
        {
            _inventoryMediator.Publish(new AddItemsRequest(new List<Item>() { slot.Item }));

            _slots.Remove(slot);

            _container.items.Remove(slot.Item);
            
            Destroy(slot.gameObject);
        }

        private void OnExitClicked()
        {
            _container.StopInteract();
        }
    }
}
