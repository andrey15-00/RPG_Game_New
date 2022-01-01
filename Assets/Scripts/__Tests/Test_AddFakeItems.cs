using UnityEngine;
using UnityGame.GameLogic;
using UnityGame.Items;
using UnityGame.ResponseRequestCommunication;
using Zenject;

namespace Test
{
    public class Test_AddFakeItems : MonoBehaviour
    {
        private IRequestCaller<AddItemRequest, bool> _addItemCaller;

        [Inject]
        private void Constructor(IRequestCaller<AddItemRequest, bool> addItemCaller)
        {
            _addItemCaller = addItemCaller;
        }

        private void Start()
        {
            Item item = new Item(new ItemDefinition() { id = "1", name = "FakeItem 1" });
            _addItemCaller.Call(new AddItemRequest(item));

            Item item_2 = new Item(new ItemDefinition() { id = "2", name = "FakeItem 2" });
            _addItemCaller.Call(new AddItemRequest(item_2));

            Item item_3 = new Item(new ItemDefinition() { id = "3", name = "FakeItem 3" });
            _addItemCaller.Call(new AddItemRequest(item_3));

            Item item_4 = new Item(new ItemDefinition() { id = "4", name = "FakeItem 4" });
            _addItemCaller.Call(new AddItemRequest(item_4));
        }
    }
}
