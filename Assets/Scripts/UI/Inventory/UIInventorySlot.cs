using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityGame.Items;
using UnityEngine.EventSystems;

namespace UnityGame.UI
{
    public class UIInventorySlot : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _name;
        private Action<UIInventorySlot> _clicked;

        public Item Item { get; private set; }

        public void Init(Item item)
        {
            Item = item;
            
            _icon.sprite = item.Definition.icon;
            _name.text = item.Definition.name;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _clicked?.Invoke(this);
        }

        public void SetClickEvent(Action<UIInventorySlot> clicked)
        {
            _clicked = clicked;
        }
    }
}
