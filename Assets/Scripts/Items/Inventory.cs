using System.Collections.Generic;

namespace UnityGame.Items
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        public List<Item> GetAll()
        {
            return _items;
        }

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public void RemoveAll(string id)
        {
            _items.RemoveAll(item => item.Id == id);
        }
    }
}
