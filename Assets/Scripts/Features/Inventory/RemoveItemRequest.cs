using UnityGame.Items;

namespace UnityGame.GameLogic
{
    public class RemoveItemRequest
    {
        public Item item;

        public RemoveItemRequest(Item item)
        {
            this.item = item;
        }
    }
}