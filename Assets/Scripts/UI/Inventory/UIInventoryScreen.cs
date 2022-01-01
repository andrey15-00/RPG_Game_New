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
        private InputSystem _inputSystem;

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
            IRequestCaller<AddItemRequest, bool> addItemCaller, InputSystem inputSystem)
        {
            _getItemsCaller = getItemsCaller;
            _addItemCaller = addItemCaller;
            _inputSystem = inputSystem;

            _inputSystem.OpenInventory += OnNeedOpen;

            LogWrapper.Log("[InventoryScreen] Constructor called!");
        }

        private void OnNeedOpen()
        {
            Show();
        }

        private void OnCloseClicked()
        {
            Hide();
        }

        private void OnEquipClicked()
        {
            //TODO:
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
