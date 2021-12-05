using System.Collections.Generic;
using UnityEngine;

namespace UnityGame.Items
{
    [CreateAssetMenu(fileName = "ItemList", menuName = "Data/ItemList", order = 1)]
    internal class ItemList : ScriptableObject
    {
        public List<ItemDefinition> items;
    }
}