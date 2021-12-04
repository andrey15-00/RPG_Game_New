using System.Collections.Generic;

namespace UnityGame.Items
{
    public class ItemList
    {
        private List<Item> _items = new List<Item>();

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public void RemoveAll(string id)
        {
            _items.RemoveAll(item => item.id == id);
        }
    }
}
