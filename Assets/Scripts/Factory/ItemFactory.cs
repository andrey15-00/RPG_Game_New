using UnityEngine;
using UnityGame.Items;

namespace UnityGame.Spawning
{
    public class ItemFactory : MonoBehaviour
    {
        [SerializeField] private ItemList _itemList;

        public ItemDefinition GetRandomItem()
        {
            int index = Random.Range(0, _itemList.items.Count);
            return _itemList.items[index];
        }
    }
}
