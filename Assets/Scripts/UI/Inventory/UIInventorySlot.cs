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

        public ItemDefinition ItemDefinition { get; private set; }

        public void Init(ItemDefinition definition, Action<UIInventorySlot> clicked = null)
        {
            ItemDefinition = definition;
            _clicked = clicked;
            
            _icon.sprite = definition.icon;
            _name.text = definition.name;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _clicked?.Invoke(this);
        }
    }
}
