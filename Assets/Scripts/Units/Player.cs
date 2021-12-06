using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGame.GameLogic;
using UnityGame.Items;
using UnityGame.Mediation;
using UnityGame.Stats;
using Zenject;

namespace UnityGame.Units
{
    public class Player : MonoBehaviour, IUnit,
       IMediatorMessageHandler<GetItemsRequest>,
       IMediatorMessageHandler<AddItemsRequest>
    {
        private Dictionary<StatType, IStat> _stats;
        private Inventory _inventory = new Inventory();
        private IMediator<AbstractInventoryMessage> _inventoryMediator;

        public void Init(HashSet<IStat> stats)
        {
            _stats = new Dictionary<StatType, IStat>();
            foreach (var stat in stats)
            {
                _stats[stat.Type] = stat;
            }
        }

        public void ApplyStat(IStat stat)
        {
            _stats[stat.Type].Add(stat.Count);
        }

        public void Handle(GetItemsRequest message)
        {
            LogWrapper.Log("[Player] GetItemsRequest received. Items count: " + _inventory.GetAll().Count);
            _inventoryMediator.Publish(new GetItemsResponse(_inventory.GetAll()));
        }

        public void Handle(AddItemsRequest message)
        {
            LogWrapper.Log("[Player] AddItemsRequest received. Items count: " + message.items.Count);
            foreach(var item in message.items)
            {
                _inventory.Add(item);
            }
            _inventoryMediator.Publish(new GetItemsResponse(_inventory.GetAll()));
        }

        [Inject]
        private void Init(IMediator<AbstractInventoryMessage> inventoryMediator)
        {
            inventoryMediator.SubscribeHandler<Player, GetItemsRequest>(this);
            inventoryMediator.SubscribeHandler<Player, AddItemsRequest>(this);

            _inventoryMediator = inventoryMediator;
        }
    }
}
