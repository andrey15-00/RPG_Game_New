
using System;
using UnityEngine;

namespace UnityGame.Items
{
    [Serializable]
    public class Item
    {
        [SerializeField] private int _count;
        [SerializeField] private ItemDefinition _definition;

        public int Count => _count;
        public string Id => _definition.id;
        public ItemDefinition Definition => _definition;

        public Item(ItemDefinition definition, int count = 1)
        {
            _definition = definition;
            _count = count;
        }
    }
}