using UnityEngine;
using UnityGame.GameLogic;
using UnityGame.Items;
using UnityGame.Mediation;
using UnityGame.States;
using UnityGame.UI;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private UISystem _uiSystem;
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private ItemList _itemList;

    public override void InstallBindings()
    {
        // Container.BindInterfacesAndSelfTo<GameFlowMediator>().AsSingle();

        Container.Bind<IMediator<AbstractGameFlowMessage>>().FromInstance(new GameFlowMediator()).AsCached();

        Container.Bind<UISystem>().FromInstance(_uiSystem).AsSingle();

        Container.Bind<StateMachine>().FromInstance(_stateMachine).AsSingle();

        Container.Bind<IMediator<AbstractInventoryMessage>>().FromInstance(new InventoryMediator()).AsSingle();

        Container.Bind<ItemList>().FromInstance(_itemList).AsSingle();
    }
}