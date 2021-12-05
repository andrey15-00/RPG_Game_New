using System.Collections.Generic;
using UnityGame.Items;

namespace UnityGame.GameLogic
{
    public class AddItemsRequest : AbstractInventoryMessage
    {
        public List<ItemDefinition> items = new List<ItemDefinition>();

        public AddItemsRequest(List<ItemDefinition> items)
        {
            this.items = items;
        }
    }
}