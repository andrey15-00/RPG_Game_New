using System.Collections.Generic;
using UnityGame.Items;

namespace UnityGame.GameLogic
{
    public class AddItemsRequest : AbstractInventoryMessage
    {
        public List<Item> items = new List<Item>();

        public AddItemsRequest(List<Item> items)
        {
            this.items = items;
        }
    }
}