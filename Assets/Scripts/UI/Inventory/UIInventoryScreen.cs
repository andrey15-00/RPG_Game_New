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
    public class UIInventoryScreen : UIAbstractScreen, IMediatorMessageHandler<GetItemsResponse>
    {
        [SerializeField] UIInventorySlot _slotPrefab;
        [SerializeField] Transform _slotsParent;
        [SerializeField] Button _close;
        [SerializeField] Button _equip;
        private IMediator<AbstractInventoryMessage> _inventoryMediator;
        private List<UIInventorySlot> _slots = new List<UIInventorySlot>();

        public void Handle(GetItemsResponse message)
        {
            LogWrapper.Log("Received inventory items. Count: " + message.items.Count);
            Clear();
            SpawnSlots(message.items);
            base.Show();
        }

        protected override void InitInternal()
        {
            _close.onClick.AddListener(OnCloseClicked);
            _equip.onClick.AddListener(OnEquipClicked);
        }

        public async override void Show()
        {
            while (_inventoryMediator == null)
            {
                await Task.Yield();
            }


            _inventoryMediator.Publish(new GetItemsRequest());
        }

        [Inject]
        private void Constructor(IMediator<AbstractInventoryMessage> inventoryMediator)
        {
            inventoryMediator.SubscribeHandler<UIInventoryScreen, GetItemsResponse>(this);

            _inventoryMediator = inventoryMediator;
        }

        private void OnCloseClicked()
        {
            _uiSystem.ChangeScreen<UIMainScreen>();
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
