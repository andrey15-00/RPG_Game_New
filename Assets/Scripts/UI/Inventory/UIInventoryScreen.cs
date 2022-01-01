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
    public class UIInventoryScreen : UIAbstractScreen
    {
        [SerializeField] UIInventorySlot _slotPrefab;
        [SerializeField] Transform _slotsParent;
        [SerializeField] Button _close;
        [SerializeField] Button _equip;
        private List<UIInventorySlot> _slots = new List<UIInventorySlot>();
        private IRequestCaller<GetItemsRequest, List<Item>> _getItemsCaller;
        private IRequestCaller<AddItemRequest, bool> _addItemCaller;

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
            List<Item> items = _getItemsCaller.Call(new GetItemsRequest());
            LogWrapper.Log("[InventoryScreen] Received inventory items. Count: " + items.Count);
            Clear();
            SpawnSlots(items);
        }

        [Inject]
        private void Constructor(IRequestCaller<GetItemsRequest, List<Item>> getItemsCaller,
            IRequestCaller<AddItemRequest, bool> addItemCaller)
        {
            _getItemsCaller = getItemsCaller;
            _addItemCaller = addItemCaller;

            LogWrapper.Log("[InventoryScreen] Constructor called!");
        }

        private void OnCloseClicked()
        {
            _uiSystem.ChangeScreen<UIMainScreen>();
        }

        private void OnEquipClicked()
        {
            //TODO:
            Item item = new Item(new ItemDefinition() { name = "item la" });
            AddItemRequest request = new AddItemRequest(item);
            _addItemCaller.Call(request);
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
    }
}
