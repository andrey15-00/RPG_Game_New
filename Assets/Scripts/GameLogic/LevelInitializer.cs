using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityGame.Items;
using UnityGame.Spawning;
using UnityGame.Units;
using Zenject;

namespace UnityGame.GameLogic
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private List<Container> _containers = new List<Container>();
        [SerializeField] private int _itemsToSpawnInEachContainer = 3;
        [Inject] private UnitFactory _unitFactory;
        [Inject] private ItemFactory _itemFactory;
        [Inject] private InteractablesSystem _interactablesSystem;
        [Inject] private InteractablesSearcher _interactablesSearcher;
        private Player _player;

        public Player Player => _player;

        public void InitLevel()
        {
            _player = _unitFactory.SpawnPlayer();

            foreach(var container in _containers)
            {
                List<Item> items = new List<Item>();
                for(int a=0; a < _itemsToSpawnInEachContainer; ++a)
                {
                    ItemDefinition definition = _itemFactory.GetRandomItem();
                    definition.id = UnityEngine.Random.Range(1, 9999999).ToString(); 
                    items.Add(new Item(definition));
                }
                container.items = items;
                container.HideUI();

                _interactablesSystem.RegisterContainer(container);
            }

            _interactablesSearcher.Activate();

            LogWrapper.Log("[LevelInitializer] Initialized level.");
        }

        public void DestroyLevel()
        {
            _interactablesSearcher.Deactivate();

            if (_player != null)
            {
                Destroy(_player.gameObject);
                _player = null;
            }

            foreach (var container in _containers)
            {
                _interactablesSystem.UnregisterContainer(container);
                container.items.Clear();
                container.HideUI();
            }

            LogWrapper.Log("[LevelInitializer] Destroyed level.");
        }
    }
}