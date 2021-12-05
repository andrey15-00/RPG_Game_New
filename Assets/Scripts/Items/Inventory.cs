using System.Collections.Generic;

namespace UnityGame.Items
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        public List<ItemDefinition> GetDefinitions()
        {
            List<ItemDefinition> definitions = new List<ItemDefinition>();
            foreach(var item in _items)
            {
                definitions.Add(item.Definition);
            }
            return definitions;
        }

        public void Add(ItemDefinition definition)
        {
            Item item = new Item(definition);
            _items.Add(item);
        }

        public void RemoveAll(string id)
        {
            _items.RemoveAll(item => item.Id == id);
        }
    }
}
