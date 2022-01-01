using System.Collections.Generic;
using UnityEngine;
using UnityGame.GameLogic;
using UnityGame.Items;
using UnityGame.Mediation;
using UnityGame.ResponseRequestCommunication;
using UnityGame.Spawning;
using UnityGame.States;
using UnityGame.UI;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private UISystem _uiSystem;
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private ItemList _itemList;
    [SerializeField] private LevelInitializer _levelInitializer;
    [SerializeField] private UnitFactory _unitFactory;
    [SerializeField] private ItemFactory _itemFactory;
    [SerializeField] private InteractablesSearcher _interactablesSearcher;
    [SerializeField] private InteractablesSystem _interactablesSystem;
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private InventorySystem _inventorySystem;

    public override void InstallBindings()
    {
        // Container.BindInterfacesAndSelfTo<GameFlowMediator>().AsSingle();

       // Container.Bind<IMediator<AbstractGameFlowMessage>>().FromInstance(new GameFlowMediator()).AsCached();
        Container.Bind<IMediator<AbstractGameFlowMessage>>().FromInstance(new Mediator<AbstractGameFlowMessage>()).AsCached();

        Container.Bind<UISystem>().FromInstance(_uiSystem).AsSingle();

        Container.Bind<StateMachine>().FromInstance(_stateMachine).AsSingle();

        Container.Bind<ItemList>().FromInstance(_itemList).AsSingle();

        Container.Bind<UnitFactory>().FromInstance(_unitFactory).AsSingle();

        Container.Bind<ItemFactory>().FromInstance(_itemFactory).AsSingle();

        Container.Bind<LevelInitializer>().FromInstance(_levelInitializer).AsSingle();

        Container.Bind<InteractablesSearcher>().FromInstance(_interactablesSearcher).AsSingle();

        Container.Bind<InteractablesSystem>().FromInstance(_interactablesSystem).AsSingle();

        Container.Bind<InputSystem>().FromInstance(_inputSystem).AsSingle();

        Container.Bind<Installer>().FromInstance(this).AsSingle();


        InitInventorySystem();
    }

    private void InitInventorySystem()
    {
        IRequestCaller<GetItemsRequest, List<Item>> getItemsCaller = new RequestCaller<GetItemsRequest, List<Item>>(_inventorySystem);
        IRequestCaller<AddItemRequest, bool> addItemCaller = new RequestCaller<AddItemRequest, bool>(_inventorySystem);
        IRequestCaller<RemoveItemRequest, bool> removeItemCaller = new RequestCaller<RemoveItemRequest, bool>(_inventorySystem);

        Container.Bind<IRequestCaller<GetItemsRequest, List<Item>>>().FromInstance(getItemsCaller).AsSingle();
        Container.Bind<IRequestCaller<AddItemRequest, bool>>().FromInstance(addItemCaller).AsSingle();
        Container.Bind<IRequestCaller<RemoveItemRequest, bool>>().FromInstance(removeItemCaller).AsSingle();
    }

    public DiContainer GetContainer()
    {
        return Container;
    }
}