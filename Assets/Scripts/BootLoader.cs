using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityGame.GameLogic;
using UnityGame.Mediation;
using UnityGame.Spawning;
using UnityGame.States;
using UnityGame.UI;
using Zenject;

namespace Assets.Scripts
{
    internal class BootLoader : MonoBehaviour
    {
        [Inject]
        private void Init(UISystem uISystem, 
            StateMachine stateMachine, 
            IMediator<AbstractGameFlowMessage> gameFlowMediator, 
            LevelInitializer levelInitializer,
            InteractablesSearcher interactablesSearcher)
        {
            LogWrapper.Log("[BootLoader] Started init.");

            uISystem.ShowScreen<UILoadingScreen>();

            stateMachine.Init(new List<IState>()
            {
                new LoadingState(),
                new MainMenuState(),
                new GameplayState(levelInitializer, interactablesSearcher),
            }, nameof(LoadingState));

            uISystem.ShowScreen<UIMainScreen>();

            uISystem.LoadScreen<UIInventoryScreen>();

            LogWrapper.Log("[BootLoader] Finished init.");
        }
    }
}
