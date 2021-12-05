
namespace UnityGame.Items
{
    public class Item
    {
        public int count;
        private ItemDefinition _definition;

        public string Id => _definition.id;
        public ItemDefinition Definition => _definition;

        public Item(ItemDefinition definition)
        {
            _definition = definition;
        }
    }
}