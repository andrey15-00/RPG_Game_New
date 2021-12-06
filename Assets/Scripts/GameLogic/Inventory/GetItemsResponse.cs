using System.Collections.Generic;
using UnityGame.Items;

namespace UnityGame.GameLogic
{
    public class GetItemsResponse : AbstractInventoryMessage
    {
        public List<Item> items;

        public GetItemsResponse(List<Item> items)
        {
            this.items = items;
        }
    }
}