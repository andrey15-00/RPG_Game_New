using UnityEngine;
using UnityGame.GameLogic;
using UnityGame.States;
using UnityGame.UI;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private UISystem _uiSystem;
    [SerializeField] private GameFlowMediator gameFlowMediator;
    [SerializeField] private StateMachine stateMachine;

    public override void InstallBindings()
    {
        // Container.BindInterfacesAndSelfTo<GameFlowMediator>().AsSingle();

        Container.Bind<GameFlowMediator>().FromInstance(gameFlowMediator).AsCached();

        Container.Bind<UISystem>().FromInstance(_uiSystem).AsSingle();

        Container.Bind<StateMachine>().FromInstance(stateMachine).AsSingle();
    }
}