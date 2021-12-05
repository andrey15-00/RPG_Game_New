using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityGame.GameLogic;
using UnityGame.States;
using UnityGame.UI;
using Zenject;

namespace Assets.Scripts
{
    internal class BootLoader : MonoBehaviour
    {
        [Inject]
        private async void Init(UISystem uISystem, StateMachine stateMachine, GameFlowMediator gameFlowMediator)
        {
            LogWrapper.Log("[BootLoader] Started init.");

            uISystem.ChangeScreen<UILoadingScreen>();

            stateMachine.Init(new List<IState>()
            {
                new LoadingState(),
                new MainMenuState(),
                new GameplayState(),
            }, nameof(LoadingState));

            await Task.Delay(1000);//TODO: test

            uISystem.ChangeScreen<UIMainScreen>();

            LogWrapper.Log("[BootLoader] Finished init.");
        }
    }
}
