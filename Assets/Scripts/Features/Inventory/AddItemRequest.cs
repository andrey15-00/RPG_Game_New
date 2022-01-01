using UnityGame.Items;
using UnityGame.Mediation;

namespace UnityGame.GameLogic
{
    public class AddItemRequest
    {
        public Item item;

        public AddItemRequest(Item item)
        {
            this.item = item;
        }
    }
}