using System.Collections.Generic;
using UnityGame.Items;

namespace UnityGame.GameLogic
{
    public class GetItemsResponse : AbstractInventoryMessage
    {
        public List<ItemDefinition> items;

        public GetItemsResponse(List<ItemDefinition> items)
        {
            this.items = items;
        }
    }
}