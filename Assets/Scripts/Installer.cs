using UnityEngine;
using UnityGame.GameLogic;
using UnityGame.Items;
using UnityGame.Mediation;
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

    public override void InstallBindings()
    {
        // Container.BindInterfacesAndSelfTo<GameFlowMediator>().AsSingle();

        Container.Bind<IMediator<AbstractGameFlowMessage>>().FromInstance(new GameFlowMediator()).AsCached();

        Container.Bind<UISystem>().FromInstance(_uiSystem).AsSingle();

        Container.Bind<StateMachine>().FromInstance(_stateMachine).AsSingle();

        Container.Bind<IMediator<AbstractInventoryMessage>>().FromInstance(new InventoryMediator()).AsSingle();

        Container.Bind<ItemList>().FromInstance(_itemList).AsSingle();

        Container.Bind<UnitFactory>().FromInstance(_unitFactory).AsSingle();

        Container.Bind<ItemFactory>().FromInstance(_itemFactory).AsSingle();

        Container.Bind<LevelInitializer>().FromInstance(_levelInitializer).AsSingle();

        Container.Bind<InteractablesSearcher>().FromInstance(_interactablesSearcher).AsSingle();

        Container.Bind<InteractablesSystem>().FromInstance(_interactablesSystem).AsSingle();

        Container.Bind<InputSystem>().FromInstance(_inputSystem).AsSingle();

        Container.Bind<Installer>().FromInstance(this).AsSingle();
    }

    public DiContainer GetContainer()
    {
        return Container;
    }
}