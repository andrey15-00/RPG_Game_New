
using System;
using UnityEngine;

namespace UnityGame.Items
{
    [Serializable]
    public class ItemDefinition
    {
        public ItemType type;
        public string id;
        public string name;
        public string description;
        public Sprite icon;
    }
}