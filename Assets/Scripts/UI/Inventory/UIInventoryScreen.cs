using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityGame.GameLogic;
using UnityGame.Items;
using UnityGame.Mediation;
using UnityGame.ResponseRequestCommunication;
using Zenject;

namespace UnityGame.UI
{
    public class UIInventoryScreen : UIAbstractScreen, IMediatorMessageHandler<InventoryUpdated>
    {
        [SerializeField] UIInventorySlot _slotPrefab;
        [SerializeField] Transform _slotsParent;
        [SerializeField] Button _close;
        [SerializeField] Button _equip;
        private List<UIInventorySlot> _slots = new List<UIInventorySlot>();
        private IRequestCaller<int, List<Item>> _getItemsCaller;
        private IRequestCaller<Item, bool> _addItemCaller;
        private Mediator<InventoryUpdated> _mediator;

        protected override void InitInternal()
        {
            _close.onClick.AddListener(OnCloseClicked);
            _equip.onClick.AddListener(OnEquipClicked);
        }

        public override void Show()
        {
            Refresh();
            base.Show();
        }

        private void Refresh()
        {
            List<Item> items = _getItemsCaller.Call(0);
            LogWrapper.Log("[InventoryScreen] Received inventory items. Count: " + items.Count);
            Clear();
            SpawnSlots(items);
        }

        [Inject]
        private void Constructor(IRequestCaller<int, List<Item>> getItemsCaller,
            IRequestCaller<Item, bool> addItemCaller,
            Mediator<InventoryUpdated> mediator)
        {
            _getItemsCaller = getItemsCaller;
            _addItemCaller = addItemCaller;
            _mediator = mediator;

            _mediator.SubscribeHandler<UIInventoryScreen, InventoryUpdated>(this);

            LogWrapper.Log("[InventoryScreen] Constructor called!");
        }

        private void OnCloseClicked()
        {
            _uiSystem.ChangeScreen<UIMainScreen>();
        }

        private void OnEquipClicked()
        {
            //TODO:
            _addItemCaller.Call(new Item(new ItemDefinition() { name = "item la" }));
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
                slot.Init(item);
                _slots.Add(slot);
            }
        }

        public void Handle(InventoryUpdated message)
        {
            Refresh();
        }
    }
}
