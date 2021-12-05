using System.Collections.Generic;
using System.Threading.Tasks;
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
        [SerializeField] Container _container;//TODO: tmp. test
        private List<UIInventorySlot> _slots = new List<UIInventorySlot>();
        private IMediator<AbstractInventoryMessage> _inventoryMediator;

        private void Start()
        {
        }

        public void Init(Container container)
        {
            Clear();
            SpawnSlots(container.items);
        }

        [Inject]
        private void Init(IMediator<AbstractInventoryMessage> inventoryMediator)
        {
            _inventoryMediator = inventoryMediator;
            Init(_container);
        }

        protected override void InitInternal()
        {
        }

        private void Clear()
        {
            foreach(var slot in _slots)
            {
                Destroy(slot.gameObject);
            }
            _slots.Clear();
        }

        private void SpawnSlots(List<ItemDefinition> definitions)
        {
            foreach(var def in definitions)
            {
                UIInventorySlot slot = Instantiate(_slotPrefab, _slotsParent);
                slot.Init(def, OnSlotClicked);
                _slots.Add(slot);
            }
        }

        private void OnSlotClicked(UIInventorySlot slot)
        {
            _inventoryMediator.Publish(new AddItemsRequest(new List<ItemDefinition>() { slot.ItemDefinition }));

            _slots.Remove(slot);
            Destroy(slot.gameObject);
        }
    }
}
